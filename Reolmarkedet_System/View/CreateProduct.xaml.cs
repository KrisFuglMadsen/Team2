using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Reolmarkedet_System.ViewModel;
using Reolmarkedet_System.Model;

namespace Reolmarkedet_System.View
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window

    {
        public ViewModelTenant viewModelTenant = new ViewModelTenant();  
        public CreateProduct()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // Makes the Window dragable from any where in the window.
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e) // Minimize window without closing the application
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Close the application, and makes it stop running in VSC.
        {
            Application.Current.Shutdown();
        }

        private void btnCreateProduct_Click(object sender, RoutedEventArgs e)
        {
            /* Get values for the attributes */
            Product product = new Product();
            product.Price = Decimal.Parse(txtProductPrice.Text);
            product.Description = txtProductDescription.Text;
            product.InStock = int.Parse(txtProductQuantity.Text);
            product.TenantID = GetTenantID(ComboBoxTenantFullname.Text);
            product.ProductGroupID = GetSelectedProductGroupID();
            product.RackID = GetSelectedRackID();
                       
            /* Call the viewmodel method */
            ViewModelProduct.insertProduct(product);  
        } 

        private void cmboShowTenantFullname(object sender, EventArgs e)

        {
           
            
             ComboBoxTenantFullname.ItemsSource = viewModelTenant.GetTenantFullnameFromModel();
                    
        } 

       private int GetTenantID(string tenantFullName)
        {
            string connectionString = null;
            string getTenantIDWhereTenantFullname = null;

            connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";
            getTenantIDWhereTenantFullname = "SELECT TenantId FROM [TENANT] WHERE CONCAT(FirstName, ' ', LastName) = @TenantFullName";

            SqlConnection conn = new SqlConnection(connectionString);

            using(conn) 
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(getTenantIDWhereTenantFullname, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenantFullName", tenantFullName);

                        //Execute the query to get the TenantID
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            //Concert the result to an integer
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error GetTenantID" + ex.Message);
                }
            }
            return -1;
            
        } // for at sikre lagdeling skal denne metode nok også rykkes til Tenant-class eller viewmodel laget ?

        private Dictionary<string, int> GetProductGroupNamesAndIDs()
        {
            string connectionString = null;
            string ShowProductGroupNameAndID = null;
            Dictionary<string, int> productGroups = new Dictionary<string, int>();

            connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";
            ShowProductGroupNameAndID = "SELECT ProductGroupID, ProductGroupName FROM [PRODUCT_GROUP]";

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ShowProductGroupNameAndID, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productGroupID = reader.GetInt32(reader.GetOrdinal("ProductGroupID"));
                                string productGroupName = reader.GetString(reader.GetOrdinal("ProductGroupName"));                               
                                productGroups.Add(productGroupName, productGroupID);
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Der er sket en fejl:" + ex.Message);
                }
            }
            return productGroups;

        } //for at sikre lagdeling skal denne metode rykkes til ProductGroup-Class

        private Dictionary<string, int> ProductGropDictionary;
        
        private void ComboBoxProdutGroup_Loaded(object sender, EventArgs e)
        {
            try
            {
                //GetProductGroups
                 ProductGropDictionary = GetProductGroupNamesAndIDs();

                //Set the items source for the ComboBox to Display only hte ProductGroupName
                 ComboBoxProductGroup.ItemsSource = ProductGropDictionary.Keys.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error loading product groups: " + ex.Message);
            }
            
        }

        private int GetSelectedProductGroupID() 
        {
            string selectedProductGroupName = ComboBoxProductGroup.SelectedItem.ToString();

            if (ProductGropDictionary.TryGetValue(selectedProductGroupName, out int productGroupID)) 
            {
                return productGroupID;
            }
            return -1; //Handle the case where the ProductGroupID is not found - maybe look into return a erro message insted later
        }

        private void PopulatedRackComboBox(int tenantID)
        {
            string connectionString = null;
            string ShowRackIDAndRackTypeName = null;

            connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";
            ShowRackIDAndRackTypeName = "SELECT R.RackID, RT.RackTypeName FROM RACK R " +
                   "INNER JOIN Rack_Type RT ON R.Fk1_RackTypeID = RT.RackTypeID " +
                   "WHERE R.Fk2_TenantID = @TenantID";
            
            Dictionary<int,string> racks = new Dictionary<int,string>();

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(ShowRackIDAndRackTypeName, conn)) 
                    {
                        cmd.Parameters.Add("@TenantID",System.Data.SqlDbType.Int).Value = tenantID;

                        using(SqlDataReader reader = cmd.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                int rackID = reader.GetInt32(reader.GetOrdinal("RackID"));
                                string rackTypeName = reader.GetString(reader.GetOrdinal("RackTypeName"));
                                racks.Add(rackID, rackTypeName);
                            }
                        }
                    }

                    ComboBoxRack.ItemsSource = racks.Select(kv=>$"{kv.Key}: {kv.Value}").ToList();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error Populating Rack ComboBox: " + ex.Message);
                }
            }
        }

        private void ComboBoxTenantFullname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxTenantFullname.SelectedItem != null) 
            {
                string selectedTenantName = ComboBoxTenantFullname.SelectedItem.ToString();                
                int selectedTenantID = GetTenantID(selectedTenantName);

                if (selectedTenantID != -1)
                {
                    //populate the Rack ComboBox with data based on the selected tenant's ID
                    PopulatedRackComboBox(selectedTenantID);
                }
            }
        }

        private int GetSelectedRackID()
        {
            if(ComboBoxRack.SelectedItem != null)
            {
                string selectedRackItem = ComboBoxRack.SelectedItem.ToString();
                //Extract the RackID from the selected item
                int selectedRackID;

                if (int.TryParse(selectedRackItem.Split(':')[0], out selectedRackID))
                {
                    return selectedRackID;
                }
            }
            return -1; //handel the case where the selected Rack is not valid later
        }
        
       
    }

 }

