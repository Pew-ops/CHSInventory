using CHSInventory.Admin;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Windows.Forms;
using CHSInventory.Admin;  // important
using MyUser = CHSInventory.Admin.User1;
using MyUserFactory = CHSInventory.Admin.UserFactory;








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

            // ✅ CREATE USER OBJECT USING FACTORY
            string connectionString = ConfigurationManager
             .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            string email = txtemail1.Text.Trim();
            string password = txtpassword1.Text.Trim();
            string roleSelected = cmbrole1.Text;

            // 1️⃣ Validate inputs
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(roleSelected))
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

                    MySqlCommand cmd = new MySqlCommand("sp_login_user", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_email", email);
                    cmd.Parameters.AddWithValue("p_password", password);
                    cmd.Parameters.AddWithValue("p_role", roleSelected);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string role = reader["role"].ToString();

                            MessageBox.Show(
                                $"Login successful! Welcome {firstName} {lastName}",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            MyUser user = MyUserFactory.CreateUser(role);


                            if (user != null)
                            {
                                this.Hide();   // hide login form
                                user.Login(); // 🔥 polymorphism (opens correct dashboard)
                            }
                            else
                            {
                                MessageBox.Show("Invalid role assigned to user.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid email, password, role, or inactive account.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,
                        "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
