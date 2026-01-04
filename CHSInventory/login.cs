using Guna.UI2.WinForms;
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
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;



namespace CHSInventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblsignup_Click(object sender, EventArgs e)
        {
           
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtemail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager
             .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            string email = txtemail1.Text.Trim();
            string password = txtpassword1.Text.Trim();
            string selectedRole = cmbrole1.Text; // Admin / Nurse / STA

            // 1️⃣ Validate inputs
            if (email == "" || password == "" || selectedRole == "")
            {
                MessageBox.Show("Please fill in all fields.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT role 
                             FROM users 
                             WHERE email = @email 
                             AND password = @password 
                             AND role = @role";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", selectedRole);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["role"].ToString();

                        MessageBox.Show("Login successful!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 🔀 ROLE REDIRECTION
                        if (role == "Admin")
                        {
                            Admin1 admin = new Admin1();
                            admin.Show();
                        }
                        else if (role == "Nurse")
                        {
                            Nurse nurse = new Nurse();
                            nurse.Show();
                        }
                        else if (role == "STA")
                        {
                            Sta sta = new Sta();
                            sta.Show();
                        }

                        this.Hide(); // hide login form
                    }
                    else
                    {
                        MessageBox.Show("Invalid email, password, or role.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        }
    }
