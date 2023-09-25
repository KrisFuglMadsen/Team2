using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reolmarkedet_System.Model;

public class Tenant
{
    private int TenantID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    
    public string Email { get; set; }
    public string AccountNumber { get; set; }

    public Tenant(int id, string firstName, string lastName, string phoneNunber, string email, string accountNumber) 
    {
        TenantID = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNunber;
        Email = email;
        AccountNumber = accountNumber;
    }

    
    /*
    public static List<string> GetTenantFullName()

    {
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
                            tenantNames.Add(fullName); 
                            
                        }
                    }

                    return tenantNames;
                    //ComboBoxTenantFullname.ItemsSource = tenantNames;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetTenantFullName: " + ex.Message);
                return null;
            }
        }

    } //for at sikre lagdeling skal denne metode rykkes til Tenant-class 
    */
}
