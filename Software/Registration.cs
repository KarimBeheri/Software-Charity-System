using Microsoft.Win32;
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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Registration f1 = new User_Registration();
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee_Registration f1 = new Employee_Registration();
            f1.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sponsor_Registration f1 = new Sponsor_Registration();
            f1.Show();
            this.Close();

        }
    }
}
