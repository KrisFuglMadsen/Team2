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

namespace Reolmarkedet_System.View
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // Makes the Window dragable from any where in the window.
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCreateProduct_Click(object sender, RoutedEventArgs e)      {
           

            string connectionString = null;
            string CreateProduct = null;

            connectionString = "Server = (localdb)\\Reolmarkedet; Database=RM_DB";
            CreateProduct = "insert into PRODUCT ([Price],[Description], [Quantity], [FK1_ProductGroupID], [FK2_TenantID], [FK3_RackID]) values(@Price, @Description, @Quantity, @FK1_ProductGroupID, @FK2_TenantID, @FK3_RackID)";

            SqlConnection conn = new SqlConnection(connectionString);

            using(conn)
            {
                try
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand(CreateProduct, conn)) 
                    {
                        //Creat and set the parametes values form textbox

                        cmd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal).Value = txtProductPrice.Text;
                        cmd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = txtProductDescription.Text;
                        cmd.Parameters.Add("@Quantity", System.Data.SqlDbType.Int).Value = txtProductQuantity.Text;
                        cmd.Parameters.Add("@FK1_ProductGroupID", System.Data.SqlDbType.Int).Value = txtProductGroup.Text;
                        cmd.Parameters.Add("@FK2_TenantID", System.Data.SqlDbType.Int).Value = txtProductTenantID.Text;
                        cmd.Parameters.Add("@FK3_RackID", System.Data.SqlDbType.Int).Value = txtProductRackID.Text;

                        // Tell the DB to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Vare oprettet");
                        else
                            MessageBox.Show("Fejl varen blev ikke oprettet, prøv venligst igen");
                    }                      

                }
                catch (Exception)
                {

                    throw;
                }
            

            }

            
        }

    }
}
