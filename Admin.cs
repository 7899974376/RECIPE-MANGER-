using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipemanger
{
    public partial class Admin: Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string adminUsername = "Admin";  // Set your Admin username
            string adminPassword = "Pass";   // Set your Admin password

            if (string.IsNullOrEmpty(UsernameTb.Text))
            {
                MessageBox.Show("Enter Username");
            }
            else if (string.IsNullOrEmpty(PasswordTb.Text))
            {
                MessageBox.Show("Enter Password");
            }
            else if (UsernameTb.Text == adminUsername && PasswordTb.Text == adminPassword)
            {
                Recipemange rec = new Recipemange();
                rec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Admin username or password");
            }
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
