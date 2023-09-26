using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reolmarkedet_System.ViewModel;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.ComponentModel;


namespace Reolmarkedet_System.Model
{
    public class Product
    {
        public int ProductID { get; set; }        
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int InStock { get; set; }     
        public string BarcodeNumber { get; set; }
        public int ProductGroupID { get; set; }
        public int TenantID { get; set; }
        public int RackID { get; set; }
        public Product()
        { }
        public Product(int productID, decimal price, string description, int inStock, string barcodeNumber, int productGroupID, int TenantID, int RackID)
        {
            this.ProductID = productID;
            this.Price = price;
            this.Description = description;
            this.InStock = inStock;
            this.BarcodeNumber = barcodeNumber;
            this.ProductGroupID = productGroupID;
            this.TenantID = TenantID;
            this.RackID = RackID;
        }

        //public static void insertProductInDb(Product product)
        //{
        //    string connectionString = null;
        //    string CreateProduct = null;

        //    //connectionString = "Server=10.56.8.36;Database=DB_F23_TEAM:02;User ID=DB_F23_TEAM_02;Password=TEAMDB_DB_02;\r\n";
        //    connectionString= "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";

        //    CreateProduct = "insert into PRODUCT ([Price],[Decription], [InStock],[BarcodeNumber], [FK1_ProductGroupID], [FK2_TenantID], [FK3_RackID]) values(@Price, @Description, @InStock, @BarcodeNumber, @FK1_ProductGroupID, @FK2_TenantID, @FK3_RackID)";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    using (conn)
        //    {
        //        try
        //        {
        //            conn.Open();

        //            using (SqlCommand cmd = new SqlCommand(CreateProduct, conn))
        //            {
        //                //Creat and set the parametes values form textbox
        //                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Decimal).Value = product.Price;
        //                cmd.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar).Value = product.Description;
        //                cmd.Parameters.Add("@InStock", System.Data.SqlDbType.Int).Value = product.InStock;
        //                cmd.Parameters.Add("@FK2_TenantID", System.Data.SqlDbType.Int).Value = product.TenantID;

        //                //get the selected product group id from the combobox
        //                int selectedProductGroupName = product.ProductGroupID;
        //                cmd.Parameters.Add("@FK1_ProductGroupID", System.Data.SqlDbType.Int).Value = selectedProductGroupName;

        //                //get the selected RackID form the ComboBox
        //                int selectedRackID = product.RackID;
        //                cmd.Parameters.Add("@FK3_RackID", System.Data.SqlDbType.Int).Value = selectedRackID;

        //                // getting the barcodeNumber

                        

        //                cmd.Parameters.Add("@BarcodeNumber", System.Data.SqlDbType.NVarChar).Value = GenerateBarcodeNumber();


        //                // Tell the DB to execute the query
        //                int rowsAdded = cmd.ExecuteNonQuery();
        //                if (rowsAdded > 0)
        //                    MessageBox.Show("Vare oprettet");
        //                else
        //                    MessageBox.Show("Fejl varen blev ikke oprettet, prøv venligst igen");
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            MessageBox.Show("Error btnCreatProduct_Click: " + ex.Message);
                    
        //        }
                

        //    }


        //}

        //private static string GenerateBarcodeNumber()
        //{
        //    //int i = 0;
        //    Random random = new Random();
        //    string Chars = "123456789";


        //    char[] barcode = new char[Chars.Length];

        //    for (int i = 0; i < 9; i++)
        //    {
        //        int index = random.Next(0, 9);
        //        barcode[i] = Chars[index];
        //    }
        //    //i++;
    
        //    return new string(barcode);
        //}



    }



}
