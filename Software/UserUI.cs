using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Software
{
    public partial class UserUI : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;

        public UserUI()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Display Donation Request "PANEL"
           // panel1.SendToBack();
           
            Donation_Request_Panel.BringToFront();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // panel1.SendToBack();
            //Donation_Request_Panel.SendToBack();
            //Delete_Account_Panel.BringToFront();
            Donation_Request_Panel.SendToBack();
            panel1.SendToBack();
            panel4.BringToFront();
           // panel3.BringToFront();
            //panel3.BringToFront();





        }

        private void button5_Click(object sender, EventArgs e)
        {
            //  panel1.SendToBack();
            //Delete_Account_Panel.SendToBack();
            Donation_Request_Panel.SendToBack();
            panel1.BringToFront();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                try
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;

                    c.CommandText = "INSERT INTO UserDonations (id, username, Donation_Type, Donation_method) VALUES (user_id_seq4.nextval, :username, :donationType, :donationMethod)";
                    c.Parameters.Add("username", textBox1.Text);
                    c.Parameters.Add("donationType", comboBox3.Text);
                    c.Parameters.Add("donationMethod", comboBox1.Text);
                    int rowsAffected = c.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        string message = "Donation saved successfully!";
                        string title = "Success";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        string message = "Error! Unable to save donation.";
                        string title = "Save failed";
                        MessageBox.Show(message, title);
                    }
                }
                catch (OracleException ex)
                {
                    // Handle the OracleException here
                    string message = "An error occurred: " + ex.Message;
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
            }

        private void UserUI_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                string cs = textBox6.Text;
                DateTime date;
                DateTime.TryParse(cs, out date);

                c.CommandText = "INSERT INTO volunteersApp (id, u_name, username, email, phone, birthdate, address, gender, password)  VALUES (user_id_seq5.nextval, :name, :username, :email, :phone, :birthdate, :address, :gender, :password)";
                c.Parameters.Add("name", textBox3.Text);
                c.Parameters.Add("username", textBox5.Text);
                c.Parameters.Add("email", textBox9.Text);
                c.Parameters.Add("phone", textBox8.Text);
                c.Parameters.Add("birthdate", date);
                c.Parameters.Add("address", textBox7.Text);
                if (checkBox3.Checked)
                {
                    c.Parameters.Add("gender", "Female");
                }
                else
                {
                    c.Parameters.Add("gender", "Male");
                }
                c.Parameters.Add("password", textBox10.Text);
                int rowsAffected = c.ExecuteNonQuery();
                if (rowsAffected == 1)
                {

                    MessageBox.Show("Registered successfully !", "Success");
                }

            }
            catch 
            {
                // Handle the OracleException here
                string message = "Username or Email is already used ";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }
    }
    }

