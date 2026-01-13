using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CHSInventory
{
    public partial class AdminUser : UserControl
    {
        private int selectedUserId = -1;
        private string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public AdminUser()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            this.Load += AdminUser_Load;
        }

        private void AdminUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // ================= LOAD USERS =================
        public void LoadUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["user_id"].Visible = false;
            }
        }

        // ================= CELL CLICK =================
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);
                txtfirstnameadmin.Text = row.Cells["first_name"].Value.ToString();
                txtlastnameadmin.Text = row.Cells["last_name"].Value.ToString();
                txtboxemailadmin.Text = row.Cells["email"].Value.ToString();
                cmbroleadmin.Text = row.Cells["role"].Value.ToString();
            }
        }

        // ================= CLEAR FIELDS =================
        private void ClearFields()
        {
            txtfirstnameadmin.Clear();
            txtlastnameadmin.Clear();
            txtboxemailadmin.Clear();
            txtpasswordadmin.Clear();
            cmbroleadmin.SelectedIndex = -1;
            selectedUserId = -1;
        }

        // ================= ADD USER =================
        private void btnaddadmin_Click(object sender, EventArgs e)
        {
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
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ================= UPDATE USER =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_update_user", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_user_id", selectedUserId);
                    cmd.Parameters.AddWithValue("p_first_name", txtfirstnameadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("p_last_name", txtlastnameadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("p_email", txtboxemailadmin.Text.Trim());
                    cmd.Parameters.AddWithValue("p_role", cmbroleadmin.Text);
                    // Password is optional; pass NULL if empty
                    cmd.Parameters.AddWithValue("p_password",
                        string.IsNullOrWhiteSpace(txtpasswordadmin.Text) ? null : txtpasswordadmin.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully!");
                    ClearFields();
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ================= DELETE USER =================
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

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("sp_delete_user", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_user_id", selectedUserId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User deleted successfully!");
                    ClearFields();
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ================= CLEAR BUTTON =================
        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
