using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IRC
{
    public partial class Default : System.Web.UI.Page
    {
        readonly string connectionStrings = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null || Application["Users"] == null)
                {
                    Response.Redirect("Login.aspx");
                    Server.Transfer("Login.aspx", true);
                }
            }
            
            refreshData();
        }

        protected void B_Poslji_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                using (SqlCommand insertData = new SqlCommand("INSERT INTO Pogovor (username, besedilo, cas) VALUES (@username, @text, @time)", connection))
                {
                    LB_Pogovor.Items.Clear();
                    connection.Open();
                    insertData.Connection = connection;
                    insertData.CommandType = CommandType.Text;
                    insertData.Parameters.AddWithValue("@username", (string) Session["User"]);
                    insertData.Parameters.AddWithValue("@text", TB_Sporocilo.Text);
                    DateTime timeDate = DateTime.Now;
                    var culture = new CultureInfo("ru-RU");
                    double hour = 1.00;
                    insertData.Parameters.AddWithValue("@time", timeDate.AddHours(hour).ToString(culture));
                    insertData.ExecuteNonQuery();
                    connection.Close();
                    using (SqlCommand readData = new SqlCommand("SELECT * FROM Pogovor", connection))
                    {
                        connection.Open();
                        using (SqlDataReader myReader = readData.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                string username = myReader.GetString(1);
                                string text = myReader.GetString(2);
                                string time = myReader.GetString(3);
                                string input = "| " + time + " | " + username + ": " + text;
                                LB_Pogovor.Items.Add(input);
                            }
                        }
                        TB_Sporocilo.Text = "";
                        connection.Close();
                    }
                }
            }
        }

        protected void B_Osvezi_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        protected void LB_Odjava_Click(object sender, EventArgs e)
        {
            if (((ArrayList) Application["Users"]).Contains(Session["User"]))
            {
                ((ArrayList) Application["Users"]).Remove(Session["User"]);
            }
            Response.Redirect("Login.aspx");
            Server.Transfer("Login.aspx");
        }

        private void refreshData()
        {
            LB_Uporabniki.Items.Clear();
            LB_Pogovor.Items.Clear();

            for (int a = 0; a < ((ArrayList) Application["Users"]).Count; a++)
            {
                LB_Uporabniki.Items.Add( (string) ((ArrayList) Application["Users"])[a]);
            }

            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                using (SqlCommand getData = new SqlCommand("SELECT * FROM Pogovor", connection))
                {
                    SqlDataReader myReader = getData.ExecuteReader();

                    while (myReader.Read())
                    {
                        string data = "| " + myReader.GetString(3) + " | " + myReader.GetString(1) + ": " + myReader.GetString(2);
                        LB_Pogovor.Items.Add(data);
                    }
                }
                connection.Close();
            }
        }
    }
}