using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class SponsorUI : Form
    {

        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public SponsorUI()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Donation_Request_Panel.Show();
            panel1.Hide();
            panel4.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Donation_Request_Panel.Hide();
            panel1.Show();
            panel4.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Donation_Request_Panel.Hide();
            panel1.Hide();
            panel4.Show();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SponsorUI_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update fund set state=:stat where id=:s";
            cmd.Parameters.Add("stat", "confirmed");

            cmd.Parameters.Add("s", comboBox2.SelectedItem);
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Fund Confirmed !", "Success !");
            }
            else
            {
                MessageBox.Show("Couldn't confirm request !", "Error !");

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO accepted_funds (ID,sponsor,fund_type) SELECT ID,sponsor,fund_type from fund where state=:stat";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("stat", "confirmed");
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "delete from fund where state=:stat";
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("stat", "confirmed");



                int rowsAffected = cmd.ExecuteNonQuery();
                int rowsAffected2 = cmd2.ExecuteNonQuery();

                if (rowsAffected > 0 && rowsAffected2>0)
                {
                    MessageBox.Show("Fund Confirmation Completed !", "Success !");
                }
                else
                {
                    MessageBox.Show("Couldn't confirm !", "Error !");
                }


            }


            catch
            {
                MessageBox.Show("Fund already confirmed !", "Duplicate...");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update fund set state=:stat where id=:s";
            cmd.Parameters.Add("stat", "rejected");
            cmd.Parameters.Add("s",comboBox2.SelectedItem);
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Fund Rejected !", "Success !");
            }
            else
            {
                MessageBox.Show("Couldn't reject request !", "Error !");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("stat", "pending");
            cmd.Parameters.Add("sp", textBox3.Text);
            cmd.Parameters.Add("id", OracleDbType.RefCursor,ParameterDirection.Output);


           // cmd.CommandType = CommandType.Text;
            OracleDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Donation_Request_Panel.Show();
            panel1.Hide();
            panel4.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand c = new OracleCommand();
                c.Connection = conn;

                c.CommandText = "INSERT INTO SPONSORDONATIONS (id, username, Donation_Type, Donation_method) VALUES (user_id_seq7.nextval, :username, :donationType, :donationMethod)";
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
        OracleDataAdapter ad;

        DataSet ds;
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM SPONSORDONATIONS ";
                ad = new OracleDataAdapter(query, ordb);

                ds = new DataSet();
                ad.Fill(ds);

                dataGridView3.DataSource = ds.Tables[0];

            }
            catch (OracleException ex)
            {
                string message = "An error occurred: " + ex.Message;
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommandBuilder bd = new OracleCommandBuilder(ad);
                ad.Update(ds.Tables[0]);
                MessageBox.Show("Data updated successfully !", "Success !");
            }
            catch
            {
                MessageBox.Show("Invalid Data !", "Error !");

            }
        }
    }
}
    


