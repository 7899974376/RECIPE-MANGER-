using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipemanger
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            //this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if username and password fields are empty
            if (string.IsNullOrEmpty(UnameTb.Text) || string.IsNullOrEmpty(PasswordTb.Text))
            {
                MessageBox.Show("Please enter both Username and Password.");
                return;
            }

            // Define the database connection
            using (SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    Con.Open();

                    // Use ExecuteScalar() to check if user exists
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@username", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordTb.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Get result as integer

                    if (count == 1)
                    {
                        MessageBox.Show("Login successful!");
                        RecipeView1 obj1 = new RecipeView1();
                        obj1.Show();
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterForm obj = new RegisterForm();
            obj.Show();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void UnameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
