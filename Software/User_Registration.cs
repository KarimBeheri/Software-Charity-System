using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Software
{
    public partial class User_Registration : Form
    {
         string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public User_Registration()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void User_Registration_Load(object sender, EventArgs e)
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

                c.CommandText = "INSERT INTO Users (id, name, username, email, phone, birthdate, address, gender, password)  VALUES (user_id_seq1.nextval, :name, :username, :email, :phone, :birthdate, :address, :gender, :password)";
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
            catch 
            {
                // Handle the OracleException here
                string message = "Username or Email is already used " ;
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void User_Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
           conn.Close();
            conn.Dispose();

        }
    }
}
