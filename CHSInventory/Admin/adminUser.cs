using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;



namespace CHSInventory
{
    public partial class AdminUser : UserControl
    {
        public AdminUser()
        {
            InitializeComponent(); 
            dataGridView1.CellClick += dataGridView1_CellClick_1; // <- attach event in code
        }
               
        private int selectedUserId = -1;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
             
        }


        private void txtfirstnameadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlastnameadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxemailadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbroleadmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtpasswordadmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnaddadmin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager
      .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            string firstName = txtfirstnameadmin.Text.Trim();
            string lastName = txtlastnameadmin.Text.Trim();
            string email = txtboxemailadmin.Text.Trim();
            string password = txtpasswordadmin.Text.Trim();
            string role = cmbroleadmin.Text;
            string status = "Active";

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("sp_add_user", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_first_name", firstName);
                    cmd.Parameters.AddWithValue("p_last_name", lastName);
                    cmd.Parameters.AddWithValue("p_email", email);
                    cmd.Parameters.AddWithValue("p_password", password);
                    cmd.Parameters.AddWithValue("p_role", role);
                    cmd.Parameters.AddWithValue("p_status", status);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User added successfully!");

                    ClearFields();
                    LoadUsers(); // 🔥 refresh grid after insert
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtfirstnameadmin.Clear();
            txtlastnameadmin.Clear();
            txtboxemailadmin.Clear();
            txtpasswordadmin.Clear();
            cmbroleadmin.SelectedIndex = -1;
        }
        private void ClearFields()
        {
            txtfirstnameadmin.Clear();
            txtlastnameadmin.Clear();
            txtboxemailadmin.Clear();
            txtpasswordadmin.Clear();
            cmbroleadmin.SelectedIndex = -1;
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Make sure your DB column is exactly 'user_id'
                selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);
                txtfirstnameadmin.Text = row.Cells["first_name"].Value.ToString();
                txtlastnameadmin.Text = row.Cells["last_name"].Value.ToString();
                txtboxemailadmin.Text = row.Cells["email"].Value.ToString();
                cmbroleadmin.Text = row.Cells["role"].Value.ToString();
                dataGridView1.Columns["user_id"].Visible = false;


                
            }
        }

        public void LoadUsers()
        {
            string connectionString = ConfigurationManager
       .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // 🔥 MAKE COLUMNS FILL THE GRID
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            string connectionString = ConfigurationManager
                .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Start building query
                    string query = @"UPDATE users 
                             SET first_name=@fname, 
                                 last_name=@lname, 
                                 email=@email, 
                                 role=@role";

                    // Add password update only if the textbox is not empty
                    if (!string.IsNullOrWhiteSpace(txtpasswordadmin.Text))
                    {
                        query += ", password=@password";
                    }

                    query += " WHERE user_id=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fname", txtfirstnameadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", txtlastnameadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtboxemailadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbroleadmin.Text);
                    cmd.Parameters.AddWithValue("@id", selectedUserId);

                    if (!string.IsNullOrWhiteSpace(txtpasswordadmin.Text))
                    {
                        cmd.Parameters.AddWithValue("@password", txtpasswordadmin.Text.Trim());
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User updated successfully!");

                    ClearFields();
                    LoadUsers();
                    selectedUserId = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            string connectionString = ConfigurationManager
                .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM users WHERE user_id=@id"; // <-- FIXED

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedUserId);

                    cmd.ExecuteNonQuery();

                  

                    ClearFields();
                    LoadUsers();
                    selectedUserId = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
