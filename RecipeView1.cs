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
    public partial class RecipeView1: Form
    {
        public RecipeView1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            string query = "SELECT RecipeID, RecipeName, Ingredients, Instructions FROM Recipes";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRecipes.DataSource = dt; // Bind data to DataGridView
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
           
            LoginForm obj = new LoginForm();
            obj.Show();
            this.Hide();

            
        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please enter a recipe name to search.");
                return;
            }

            string query = "SELECT RecipeID, RecipeName, Ingredients, Instructions FROM Recipes WHERE RecipeName LIKE @search";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvRecipes.DataSource = dt; // Bind search results to DataGridView
                }
                else
                {
                    MessageBox.Show("No recipes found with the given name.");
                    dgvRecipes.DataSource = null; // Clear DataGridView if no results
                }
            }
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            RecipeDetails obj = new RecipeDetails(txtSearch.Text);
            obj.Show();
            this.Hide();

        }
    }
}
