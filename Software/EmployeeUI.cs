using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CrystalDecisions.Shared;

namespace Software
{
    public partial class EmployeeUI : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        CrystalReport2 cr;
        public EmployeeUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            DashBoard.Show();
            Fund_Request.Hide();
            Control_Volunteers.Hide();
            flowLayoutPanel1.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();


        }


        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard.Hide();
            Fund_Request.Show();
            Control_Volunteers.Hide();
            flowLayoutPanel1.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DashBoard.Hide();
            Fund_Request.Hide();
            Control_Volunteers.Hide();
            flowLayoutPanel1.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            DashBoard.Hide();
            Fund_Request.Hide();
            Control_Volunteers.Hide();
            flowLayoutPanel1.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Control_Volunteers.Show();
            DashBoard.Hide();
            Fund_Request.Hide();
            flowLayoutPanel1.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();


        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Show();
            DashBoard.Hide();
            Control_Volunteers.Hide();
            Fund_Request.Hide();
            panel3.Hide();
            crystalReportViewer1.Hide();
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmployeeUI_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport2();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "GetTableCount";

            c.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = "Users";
            c.Parameters.Add("p_count", OracleDbType.Int32).Direction = ParameterDirection.Output;

            c.ExecuteNonQuery();

            int count = (int)((OracleDecimal)c.Parameters["p_count"].Value).Value;
            label4.Text = count.ToString();



            OracleCommand c1 = new OracleCommand();
            c1.Connection = conn;
            c1.CommandType = CommandType.StoredProcedure;
            c1.CommandText = "GetTableCount";

            c1.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = "Sponsors";
            c1.Parameters.Add("p_count", OracleDbType.Int32).Direction = ParameterDirection.Output;

            c1.ExecuteNonQuery();

            int count1 = (int)((OracleDecimal)c1.Parameters["p_count"].Value).Value;
            label10.Text = count1.ToString();



            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;
            c2.CommandType = CommandType.StoredProcedure;
            c2.CommandText = "GetTableCount";

            c2.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = "volunteers";
            c2.Parameters.Add("p_count", OracleDbType.Int32).Direction = ParameterDirection.Output;

            c2.ExecuteNonQuery();

            int count2 = (int)((OracleDecimal)c2.Parameters["p_count"].Value).Value;
            label7.Text = count2.ToString();



            OracleCommand c3 = new OracleCommand();
            c3.Connection = conn;
            c3.CommandType = CommandType.StoredProcedure;
            c3.CommandText = "GetTableCount";

            c3.Parameters.Add("p_table_name", OracleDbType.Varchar2).Value = "USERDONATIONS";
            c3.Parameters.Add("p_count", OracleDbType.Int32).Direction = ParameterDirection.Output;

            c3.ExecuteNonQuery();

            int count3 = (int)((OracleDecimal)c3.Parameters["p_count"].Value).Value;
            label13.Text = count3.ToString();


            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select username from volunteersapp";
            cmd.CommandType = CommandType.Text;
            OracleDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr[0]);
            }
            rdr.Close();


            
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select username from sponsors";
            cmd2.CommandType = CommandType.Text;
            OracleDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                comboBox1.Items.Add(rdr2[0]);
            }
            rdr2.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        OracleDataAdapter ad;

        DataSet ds;
        private void button7_Click(object sender, EventArgs e)
        {

            /* try
             {
                 conn = new OracleConnection(ordb);
                 conn.Open();
                 OracleCommand cmd = new OracleCommand();
                 cmd.Connection = conn;
                 cmd.CommandText = "GetUserByName";
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(":p_username", Username.Text);
                 cmd.Parameters.Add(":p_Cursor",OracleDbType.RefCursor,ParameterDirection.Output);

                 OracleDataReader dr = cmd.ExecuteReader();

                 if (dr.HasRows)
                 {
                     DataTable dataTable = new DataTable();

                     for (int i = 0; i < dr.FieldCount; i++)
                     {
                         dataTable.Columns.Add(dr.GetName(i));
                     }

                     while (dr.Read())
                     {
                         DataRow row = dataTable.NewRow();
                         for (int i = 0; i < dr.FieldCount; i++)
                         {
                             row[i] = dr[i];
                         }
                         dataTable.Rows.Add(row);
                     }

                     dataGridView3.DataSource = dataTable;

                     // Close the connection
                     // conn.Close();
                     dr.Close();
                 }
                 else
                 {
                         MessageBox.Show("User not found !", "Error !");
                 }
             }
             catch (OracleException ex)
             {
                 // Handle the OracleException here
                 string message = "An error occurred: " + ex.Message;
                 string title = "Error";
                 MessageBox.Show(message, title);
             }*/
            try
            {
                string query = "SELECT * FROM Users where UserName = :p_UserName ";

                ad = new OracleDataAdapter(query, ordb);
                ad.SelectCommand.Parameters.Add("p_UserName", Username.Text);

                ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView3.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("User not found !", "Error !");
                }

            }
            catch (OracleException ex)
            {
                string message = "An error occurred: " + ex.Message;
                string title = "Error";
                MessageBox.Show(message, title);
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           /* try
            {*/
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
               

                c.CommandText = "INSERT INTO fund (id,sponsor,fund_type) values (user_id_seq6.nextval,:sponsor,:fund_type)";
               // c.CommandType= CommandType.Text;
                c.Parameters.Add("sponsor",comboBox1.SelectedItem.ToString());
                c.Parameters.Add("fund_type",comboBox3.SelectedItem.ToString());
               
               
                int r = c.ExecuteNonQuery();
                if (r != -1)
                {

                    MessageBox.Show("Fund requested successfully !", "Success");
                }

           // }
           /* catch
            {
                // Handle the OracleException here
                string message = "Username or Email is already used ";
                string title = "Error";
                MessageBox.Show(message, title);
            }*/
        }

        private void Fund_Request_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Users ";
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

        private void button9_Click(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update volunteersapp set state=:stat where username=:s";
            cmd.Parameters.Add("stat", "confirmed");

            cmd.Parameters.Add("s", comboBox2.SelectedItem.ToString());
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Request Confirmed !", "Success !");
            }
            else
            {
                MessageBox.Show("Couldn't confirm request !", "Error !");

            }





        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update volunteersapp set state=:stat where username=:s";
            cmd.Parameters.Add("stat", "rejected");
            cmd.Parameters.Add("s", comboBox2.SelectedItem.ToString());
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Request Rejected !", "Success !");
            }
            else
            {
                MessageBox.Show("Couldn't reject request !", "Error !");

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO volunteers (ID, U_NAME, USERNAME, EMAIL, PHONE, BIRTHDATE, ADDRESS, GENDER, PASSWORD) SELECT ID, U_NAME, USERNAME, EMAIL, PHONE, BIRTHDATE, ADDRESS, GENDER, PASSWORD from volunteersapp where state=:stat";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("stat", "confirmed");



                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Volunteer Confirmed !", "Success !");
                }
                else
                {
                    MessageBox.Show("Couldn't confirm !", "Error !");
                }


            }


          catch{
                MessageBox.Show("Volunteer already confirmed !", "Duplicate...");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DashBoard.Hide();
            Fund_Request.Hide();
            Control_Volunteers.Hide();
            flowLayoutPanel1.Hide();
            panel3.Show();
            crystalReportViewer1.Show();
        }
       
        private void button12_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox4.Text);
            crystalReportViewer1.ReportSource = cr;
            

        }
    }
    
}
