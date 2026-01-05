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
using System.Data;

namespace CHSInventory
{
    public partial class AdminUser : UserControl
    {
        public AdminUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
             
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadUsers()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT first_name, last_name, email, role, status FROM users";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }
        }
    }
}
