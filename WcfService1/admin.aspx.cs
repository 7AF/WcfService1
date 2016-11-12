using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WcfService1
{
    public partial class admin : System.Web.UI.Page
    {
        string connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogInClick_Click(object sender, EventArgs e)
        {
            string username = name.Text;
            string password = pass.Text;
            string hashPassword = "";

            using (MD5 md5Hash = MD5.Create())
            {
                hashPassword = GetMd5Hash(md5Hash, password);
            }

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                using (SqlCommand getData = new SqlCommand("SELECT * FROM Uporabnik WHERE username='" + username + "' AND geslo='" + hashPassword + "' AND admin = 1", connection))
                {
                    connection.Open();
                    object data = getData.ExecuteScalar();
                    connection.Close();
                    if (data != null)
                    {
                        logError.Visible = false;
                        Session["admin"] = true;
                        Response.Redirect("Console.aspx");
                        Server.Transfer("Console.aspx", true);
                    }
                    else
                    {
                        logError.Visible = true;
                    }
                    name.Text = pass.Text = "";
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}