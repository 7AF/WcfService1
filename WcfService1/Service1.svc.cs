using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        public bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                using (SqlCommand getData = new SqlCommand("SELECT geslo FROM Uporabnik WHERE username='" + username + "'", connection))
                {
                    connection.Open();
                    object data = getData.ExecuteScalar();
                    connection.Close();
                    if (password != "" && data != null)
                    {
                        string hash = data.ToString();

                        if (hash.Equals(password))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public List<MessageEntity> GetMessages()
        {
            List<MessageEntity> a = new List<MessageEntity>();

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                using (SqlCommand getData = new SqlCommand("SELECT * FROM Pogovor", connection))
                {
                    SqlDataReader myReader = getData.ExecuteReader();

                    while (myReader.Read())
                    {
                        a.Add(new MessageEntity
                        {
                            Username = myReader.GetString(1),
                            Text = myReader.GetString(2),
                            Time = myReader.GetString(3)
                        });
                    }
                    connection.Close();
                }
            }
            return a;
        }

        public void AddMessage(string username, string text)
        {

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {

                using (
                    SqlCommand insertData =
                        new SqlCommand(
                            "INSERT INTO Pogovor (username, besedilo, cas) VALUES (@username, @text, @time)", connection)
                    )
                {
                    connection.Open();
                    insertData.CommandType = CommandType.Text;
                    insertData.Connection = connection;
                    insertData.Parameters.AddWithValue("@username", username);
                    insertData.Parameters.AddWithValue("@text", text);
					DateTime time = DateTime.Now;
                    var culture = new CultureInfo("ru-RU");
                    double hour = 1.00;
                    insertData.Parameters.AddWithValue("@time", time.AddHours(hour).ToString(culture));
                    insertData.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool Register(string username, string name, string surname, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                using (
                    SqlCommand checkUsername =
                        new SqlCommand("SELECT COUNT(*) FROM Uporabnik WHERE username='" + username + "'", connection))
                {
                    int count = (int) checkUsername.ExecuteScalar();
                    if (count == 0)
                    {
                        using (
                            SqlCommand insertCommand =
                                new SqlCommand(
                                    "INSERT INTO Uporabnik (username, ime, priimek, geslo, admin) VALUES (@username, @name, @surname, @password, @admin)",
                                    connection))
                        {
                            insertCommand.Connection = connection;
                            insertCommand.CommandType = CommandType.Text;
                            insertCommand.Parameters.AddWithValue("@username", username);
                            insertCommand.Parameters.AddWithValue("@name", name);
                            insertCommand.Parameters.AddWithValue("@surname", surname);
                            insertCommand.Parameters.AddWithValue("@password", password);
                            insertCommand.Parameters.AddWithValue("@admin", "0");
                            insertCommand.ExecuteNonQuery();
                            connection.Close();
                            return true;
                        }
                    }
                    connection.Close();
                }
            }
            return false;
        }
    }
}