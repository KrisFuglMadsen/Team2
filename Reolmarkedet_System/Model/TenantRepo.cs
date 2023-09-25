using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Reolmarkedet_System.Model
{
    public class TenantRepo
    {
        public static List<Tenant> Tenants = new List<Tenant>();
        public static List<string> FullNames = new List<string>();

        public TenantRepo()
        {
            InitializeRepo();

        }
        public void InitializeRepo()
        {
            // foreach entity in database, add to the lists
            //string connectionString = null;
            string AddTenant = "SELECT TOP (1000) [TenantID]\r\n      ,[FirstName]\r\n      ,[LastName]\r\n      ,[PhoneNumber]\r\n      ,[Email]\r\n      ,[AccountNumber]\r\n  FROM [DB_F23_TEAM_02].[dbo].[TENANT]";
            //List<string> tenantNames = new List<string>();
            //Tenant NewTenant = new Tenant();
            string IDstring = null;


            string connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(AddTenant, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int n = (int)reader["TenantID"];
                                //int IDInt = int.Parse(IDstring);
                                //NewTenant.TenantID = int.Parse(IDstring);
                                string FirstName = reader.GetString(1);
                                string LastName = reader.GetString(2);
                                string PhoneNumber = reader.GetString(3);
                                string Email = reader.GetString(4);
                                string AccountNumber = reader.GetString(5);

                                //string firstName = reader["FirstName"].ToString();
                                //string lastName = reader["LastName"].ToString();
                                //string fullName = $"{firstName} {lastName}";
                                
                                AddToLists(n, FirstName, LastName, PhoneNumber, Email, AccountNumber);

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



        public void AddToLists(int TenantID, string FirstName, string LastName, string PhoneNumber, string Email, string AccountNnumber) 
        {
            // logic goes here 
            string fullName = $"{FirstName} {LastName}";
            Tenant NewTenant = new Tenant(TenantID, FirstName, LastName, PhoneNumber, Email, AccountNnumber);
            //{
            //    TenantID = TenantID,
            //    FirstName = FirstName,
            //    LastName = LastName,
            //    PhoneNumber = PhoneNumber,
            //    Email = Email,
            //    AccountNumber = AccountNnumber
            //};
            Tenants.Add(NewTenant);
            FullNames.Add(fullName);
        }

        public List<Tenant> GetAllTenants()
        {
            return Tenants;
        }

        public  List<string> GetTenantFullName()

        {
            return FullNames;
            /*
            string connectionString = null;
            string ShowTenantName = null;
            List<string> tenantNames = new List<string>();


            connectionString = "Server = 10.56.8.36; Database = DB_F23_TEAM_02; User ID = DB_F23_TEAM_02; Password = TEAMDB_DB_02; TrustServerCertificate = true";

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ShowTenantName, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                string fullName = $"{firstName} {lastName}";
                                //tenantNames.Add(fullName);
                                this.FullNames.Add(fullName);
                            }
                        }

                        return FullNames;
                        // ComboBoxTenantFullname.ItemsSource = tenantNames;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error GetTenantFullName: " + ex.Message);
                    return null;
                } 
            }*/

        } //for at sikre lagdeling skal denne metode rykkes til Tenant-class 
    }
}

    