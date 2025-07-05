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
    public partial class RecipeDetails: Form
    {
        private string recipeName;

        public RecipeDetails(string name)
        {
            InitializeComponent();
            recipeName = name;
            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            string query = "SELECT Ingredients, Instructions FROM Recipes WHERE RecipeName = @name";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", recipeName);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                  label1.Text = "Recipe Name: " + recipeName;
                    txtIngredients.Text = reader["Ingredients"].ToString();
                    txtInstructions.Text = reader["Instructions"].ToString();
                }
                else
                {
                    MessageBox.Show("Recipe not found.");
                    this.Close();
                }

                reader.Close();
                con.Close();
            }
        }

        private void txtRecipeName_TextChanged(object sender, EventArgs e)
        {

        }


        private void lblLogout_Click(object sender, EventArgs e)
        {
            RecipeView1 obj = new RecipeView1();
            obj.Show();
            this.Hide();

            
        }

        private void lblInstructions_Click(object sender, EventArgs e)
        {

        }
    }
}
