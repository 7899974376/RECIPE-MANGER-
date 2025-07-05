using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Recipemanger
{
    public partial class Recipemange: Form
    {
        public Recipemange()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm obj = new LoginForm();
            obj.Show();
            this.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reci_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadRecipes()
        {
            string query = "SELECT * FROM Recipes";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecipes.DataSource = dt;
            }
        }

        private int selectedRecipeID = 0;  // Store selected RecipeID globally
        private void dgvRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Ensure the user clicks a valid row
            {
                DataGridViewRow row = dgvRecipes.Rows[e.RowIndex];

                selectedRecipeID = Convert.ToInt32(row.Cells[0].Value); // Get RecipeID
                txtRecipeName.Text = row.Cells[1].Value.ToString(); // Recipe Name
                txtIngredients.Text = row.Cells[2].Value.ToString(); // Ingredients
                txtInstructions.Text = row.Cells[3].Value.ToString(); // Instructions
            }
        }

        private void ClearFields()
        {
            txtRecipeName.Clear();
            txtIngredients.Clear();
            txtInstructions.Clear();
            selectedRecipeID = 0; // Reset selected ID after clearing
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (txtRecipeName.Text == "" || txtIngredients.Text == "" || txtInstructions.Text == "")
            {
                MessageBox.Show("Please fill all fields before adding a recipe.");
                return;
            }

            string query = "INSERT INTO Recipes (RecipeName, Ingredients, Instructions) VALUES (@name, @ingredients, @instructions)";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtRecipeName.Text);
                cmd.Parameters.AddWithValue("@ingredients", txtIngredients.Text);
                cmd.Parameters.AddWithValue("@instructions", txtInstructions.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Recipe added successfully!");
                LoadRecipes();
            }
        }

       

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            if (selectedRecipeID == 0)
            {
                MessageBox.Show("Please select a recipe to edit.");
                return;
            }

            if (txtRecipeName.Text == "" || txtIngredients.Text == "" || txtInstructions.Text == "")
            {
                MessageBox.Show("All fields are required.");
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf; Integrated Security = True; Connect Timeout = 30"))
                {
                    string query = "UPDATE Recipes SET RecipeName = @name, Ingredients = @ingredients, Instructions = @instructions WHERE RecipeID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtRecipeName.Text);
                    cmd.Parameters.AddWithValue("@ingredients", txtIngredients.Text);
                    cmd.Parameters.AddWithValue("@instructions", txtInstructions.Text);
                    cmd.Parameters.AddWithValue("@id", selectedRecipeID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Recipe updated successfully!");
                    LoadRecipes();  // Refresh the DataGridView
                    ClearFields();   // Clear textboxes after updating
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }



        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (selectedRecipeID == 0)
            {
                MessageBox.Show("Please select a recipe to Delete.");
                return;
            }

            if (txtRecipeName.Text == "" || txtIngredients.Text == "" || txtInstructions.Text == "")
            {
                MessageBox.Show("All fields are required.");
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\patil\\OneDrive\\Documents\\RecipeManagerDB.mdf; Integrated Security = True; Connect Timeout = 30"))
                {
                    string query = "Delete from Recipes WHERE RecipeID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtRecipeName.Text);
                    cmd.Parameters.AddWithValue("@ingredients", txtIngredients.Text);
                    cmd.Parameters.AddWithValue("@instructions", txtInstructions.Text);
                    cmd.Parameters.AddWithValue("@id", selectedRecipeID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Recipe Deleted successfully!");
                    LoadRecipes();  // Refresh the DataGridView
                    ClearFields();   // Clear textboxes after updating
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtRecipeName.Clear();
            txtIngredients.Clear();
            txtInstructions.Clear();
        }
    }
    }

