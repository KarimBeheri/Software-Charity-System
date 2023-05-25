using Microsoft.Win32;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Software
{
    public partial class Main : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration  f1 = new Registration();
            f1.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            bool Suc_Admin = false;

            if (checkBox1.Checked)
            {

                if (checkBox3.Checked )
                {

                   
                        try
                        {
                            OracleCommand c = new OracleCommand();
                            c.Connection = conn;

                            c.CommandText = "SELECT id FROM Users WHERE username = :username AND password = :password";
                            c.Parameters.Add("username", textBox1.Text);
                            c.Parameters.Add("password", textBox2.Text);
                            OracleDataReader reader = c.ExecuteReader();
                            if (reader.Read())
                            {
                            // User is signed in successfully, do something here
                            UserUI f1 = new UserUI();
                            f1.Show();
                            }
                            else
                            {
                                // Username or password is incorrect
                                string message = "Incorrect username or password.";
                                string title = "Sign in failed";
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
                else if (checkBox4.Checked)
                {
                    try
                    {
                        OracleCommand c = new OracleCommand();
                        c.Connection = conn;

                        c.CommandText = "SELECT id FROM Emps WHERE username = :username AND password = :password";
                        c.Parameters.Add("username", textBox1.Text);
                        c.Parameters.Add("password", textBox2.Text);
                        OracleDataReader reader = c.ExecuteReader();
                        if (reader.Read())
                        {
                            // User is signed in successfully, do something here
                            EmployeeUI f1 = new EmployeeUI();
                            f1.Show();
                        }
                        else
                        {
                            // Username or password is incorrect
                            string message = "Incorrect username or password.";
                            string title = "Sign in failed";
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
                else if (checkBox2.Checked)
                {
                    
                    try
                    {
                        OracleCommand c = new OracleCommand();
                        c.Connection = conn;

                        c.CommandText = "SELECT id FROM Sponsors WHERE username = :username AND password = :password";
                        c.Parameters.Add("username", textBox1.Text);
                        c.Parameters.Add("password", textBox2.Text);
                        OracleDataReader reader = c.ExecuteReader();
                        if (reader.Read())
                        {
                            // User is signed in successfully, do something here
                            SponsorUI f1 = new SponsorUI();
                            f1.Show();
                        }
                        else
                        {
                            // Username or password is incorrect
                            string message = "Incorrect username or password.";
                            string title = "Sign in failed";
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
                else
                {
                    string message = "Error! : You Should choose your role ";
                    string title = "Sign In Fail";
                    MessageBox.Show(message, title);
                }
            }
            else
            {
                string message = "Error! :You Should Accept our Terms and conditions ";
                string title = "Sign In Fail";
                MessageBox.Show(message, title);

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == " Username")
            {
                textBox1.Text = "";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = " Username";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
    }
}
