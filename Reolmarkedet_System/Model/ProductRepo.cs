using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reolmarkedet_System.Model
{
    public class ProductRepo
    {
        public List<Product> Products = new List<Product>();
        
        public ProductRepo() { InitilizeRepo(); }
        public void InitilizeRepo()
        { // foreach entity in database, add to the lists
            string AddProduct = "SELECT TOP (1000) [ProductID]\r\n      ,[Price]\r\n      ,[Decription]\r\n      ,[InStock]\r\n      ,[BarcodeNumber]\r\n      ,[FK1_ProductGroupID]\r\n      ,[FK2_TenantID]\r\n      ,[FK3_RackID]\r\n  FROM [DB_F23_TEAM_02].[dbo].[PRODUCT]";
           
            string IDstring = null;


            string connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(AddProduct, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ID = (int)reader["ProductID"];
                                //int IDInt = int.Parse(IDstring);
                                //NewTenant.TenantID = int.Parse(IDstring);
                                decimal Price = decimal.Parse(reader.GetString(1));
                                string Description = reader.GetString(2);
                                int Instock = int.Parse(reader.GetString(3));
                                string BarcodeNumber = reader.GetString(4);
                                int ProductGroupID = int.Parse(reader.GetString(5));
                                int TenantID = int.Parse(reader.GetString(6));
                                int RackID = int.Parse(reader.GetString(7));

                                //string firstName = reader["FirstName"].ToString();
                                //string lastName = reader["LastName"].ToString();
                                //string fullName = $"{firstName} {lastName}";

                                AddToProducts(ID, Price, Description, Instock, BarcodeNumber, ProductGroupID, TenantID, RackID);

                            }
                        }

                        //return tenantNames;
                        // ComboBoxTenantFullname.ItemsSource = tenantNames;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Initiallize Repo: " + ex.Message);
                    //return null;
                }
            }


            //AddToLists(Tenant tenant);
        }



        public void AddToProducts(int ProductID, decimal Price, string Description, int InStock, string BarcodeNumber, int ProductGroupID, int TenantID, int RackID)
        {
            // logic goes here 
            Product NewPRoduct = new Product(ProductID,Price, Description, InStock, BarcodeNumber, ProductGroupID, TenantID, RackID);
       
            Products.Add(NewPRoduct);
        }

        public static void insertProductInDb(Product product)
        {
            string connectionString = null;
            string CreateProduct = null;

            //connectionString = "Server=10.56.8.36;Database=DB_F23_TEAM:02;User ID=DB_F23_TEAM_02;Password=TEAMDB_DB_02;\r\n";
            connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";

            CreateProduct = "insert into PRODUCT ([Price],[Decription], [InStock],[BarcodeNumber], [FK1_ProductGroupID], [FK2_TenantID], [FK3_RackID]) values(@Price, @Description, @InStock, @BarcodeNumber, @FK1_ProductGroupID, @FK2_TenantID, @FK3_RackID)";
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(CreateProduct, conn))
                    {
                        //Creat and set the parametes values form textbox
                        cmd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal).Value = product.Price;
                        cmd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = product.Description;
                        cmd.Parameters.Add("@InStock", System.Data.SqlDbType.Int).Value = product.InStock;
                        cmd.Parameters.Add("@FK2_TenantID", System.Data.SqlDbType.Int).Value = product.TenantID;

                        //get the selected product group id from the combobox
                        int selectedProductGroupName = product.ProductGroupID;
                        cmd.Parameters.Add("@FK1_ProductGroupID", System.Data.SqlDbType.Int).Value = selectedProductGroupName;

                        //get the selected RackID form the ComboBox
                        int selectedRackID = product.RackID;
                        cmd.Parameters.Add("@FK3_RackID", System.Data.SqlDbType.Int).Value = selectedRackID;

                        // getting the barcodeNumber



                        cmd.Parameters.Add("@BarcodeNumber", System.Data.SqlDbType.NVarChar).Value = GenerateBarcodeNumber();


                        // Tell the DB to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Vare oprettet");
                        else
                            MessageBox.Show("Fejl varen blev ikke oprettet, prøv venligst igen");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error btnCreatProduct_Click: " + ex.Message);

                }


            }


        }

        private static string GenerateBarcodeNumber()
        {
            //int i = 0;
            Random random = new Random();
            string Chars = "123456789";


            char[] barcode = new char[Chars.Length];

            for (int i = 0; i < 9; i++)
            {
                int index = random.Next(0, 9);
                barcode[i] = Chars[index];
            }
            //i++;

            return new string(barcode);
        }

    }
    
}
