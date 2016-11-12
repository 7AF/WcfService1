using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace IRC
{
    public partial class Login : System.Web.UI.Page
    {
        readonly string connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["Users"] == null)
            {
                Application["Users"] = new ArrayList();
            }
        }

        protected void registerB_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || name.Text == "" || surname.Text == "" || password.Text == "")
            {
                username.Text = name.Text = surname.Text = password.Text = "";
                error.Text = "Complete all fields in section Registracija.";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionStrings))
                {
                    
                    using (SqlCommand checkUsername = new SqlCommand("SELECT COUNT(*) FROM Uporabnik WHERE username='" + username.Text + "'", connection))
                    {
                        connection.Open();
                        int count = (int)checkUsername.ExecuteScalar();
                        if(count == 0)
                        {
                            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Uporabnik (username, ime, priimek, geslo, admin) VALUES(@username, @name, @surname, @password, @admin)"))
                            {
                                insertCommand.Connection = connection;
                                insertCommand.CommandType = CommandType.Text;
                                insertCommand.Parameters.AddWithValue("@username", username.Text);
                                insertCommand.Parameters.AddWithValue("@name", name.Text);
                                insertCommand.Parameters.AddWithValue("@surname", surname.Text);
                                using (MD5 md5Hash = MD5.Create())
                                {
                                    string data = password.Text;
                                    string hash = GetMd5Hash(md5Hash, data);
                                    insertCommand.Parameters.AddWithValue("@password", hash);
                                    insertCommand.Parameters.AddWithValue("@admin", "0");
                                    insertCommand.ExecuteNonQuery();
                                }
                                Session["User"] = username.Text;
                                if(! ((ArrayList)Application["Users"]).Contains(Session["User"]))
                                {
                                    ((ArrayList)Application["Users"]).Add(Session["User"]);
                                }
                                connection.Close();
                                Response.Redirect("Default.aspx");
                                Server.Transfer("Default.aspx", true);
                            }
                        }
                        else
                        {
                            error.Text = "Username already exist. Type another one.";
                        }
                        username.Text = name.Text = surname.Text = password.Text = "";
                    }
                }
            }
        }
        protected void logInB_Click(object sender, EventArgs e)
        {
            if (username1.Text == "" || password1.Text == "")
            {
                username1.Text = password1.Text = "";
                error.Text = "Complete all fields in section Prijava.";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand getData = new SqlCommand("SELECT geslo FROM Uporabnik WHERE username='" + username1.Text + "'", connection))
                    {
                        connection.Open();
                        object data = getData.ExecuteScalar();
                        connection.Close();
                        if (data != null)
                        {
                            string getHashPassword = data.ToString();
                            using (MD5 md5Hash = MD5.Create())
                            {
                                string passwordInput = password1.Text;
                                if (VerifyMd5Hash(md5Hash, passwordInput, getHashPassword))
                                {
                                    Session["User"] = username1.Text;
                                    if (! ((ArrayList)Application["Users"]).Contains(Session["User"]))
                                    {
                                        ((ArrayList)Application["Users"]).Add(Session["User"]);
                                    }
                                    Response.Redirect("Default.aspx");
                                    Server.Transfer("Default.aspx");
                                }
                                else
                                {
                                    error.Text = "Wrong username or password.";
                                }
                            }
                        }
                        else
                        {
                            error.Text = "Wrong username or password.";
                        }
                        username1.Text = password1.Text = "";
                    }
                }
            }
        }

        // http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5(v=vs.110).aspx	
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

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            return false;
        }
    }
}