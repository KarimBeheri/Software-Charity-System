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

namespace Software
{
    public partial class Sponsor_Registration : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Sponsor_Registration()
        {
            InitializeComponent();
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

                c.CommandText = "INSERT INTO Sponsors (id, name, username, email, phone, birthdate, address, gender, password)  VALUES (user_id_seq2.nextval, :name, :username, :email, :phone, :birthdate, :address, :gender, :password)";
                c.Parameters.Add("name", textBox1.Text);
                c.Parameters.Add("username", textBox5.Text);
                c.Parameters.Add("email", textBox4.Text);
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
                c.Parameters.Add("password", textBox2.Text);
                int rowsAffected = c.ExecuteNonQuery();
                if (rowsAffected == 1)
                {

                    MessageBox.Show("Registered successfully !", "Success");
                }

            }
            catch (OracleException ex)
            {
                // Handle the OracleException here
                string message = "Username or Email is already used ";
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void Sponsor_Registration_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void Sponsor_Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn.Dispose();

        }
    }
}
