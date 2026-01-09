using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;   

namespace CHSInventory.Nurse
{
    public partial class NursePatient : UserControl
    {
        private List<string> allMedicines = new List<string>();
        private HashSet<string> checkedMedicines = new HashSet<string>();

        public NursePatient()
        {
            InitializeComponent();
            this.Load += NursePatient_Load;
        }

        private void NursePatient_Load(object sender, EventArgs e)
        {
            cmbnurseassign.Font = new Font(
                cmbnurseassign.Font.FontFamily,
                15,
                FontStyle.Regular,
                GraphicsUnit.Pixel
            );

            LoadNurses();
            LoadMedicines();
            LoadDispensedPatients(); // Load grid at startup
        }

        private void LoadNurses()
        {
            cmbnurseassign.Items.Clear();

            string connectionString =
                ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT first_name FROM users WHERE role = 'Nurses'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbnurseassign.Items.Add(reader["first_name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load nurses: " + ex.Message);
                }
            }
        }

        private void LoadMedicines()
        {
            chklistmedicine.Items.Clear();
            allMedicines.Clear();

            string connStr = ConfigurationManager
                .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("GetAvailableMedicines", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string itemName = reader["item_name"].ToString();
                            allMedicines.Add(itemName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load medicines: " + ex.Message);
                }
            }

            // Restore checked state
            foreach (var med in allMedicines)
            {
                int index = chklistmedicine.Items.Add(med);
                if (checkedMedicines.Contains(med))
                {
                    chklistmedicine.SetItemChecked(index, true);
                }
            }
        }

        private void chklistmedicine_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            string item = chklistmedicine.Items[e.Index].ToString();
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (e.NewValue == CheckState.Checked)
                    checkedMedicines.Add(item);
                else
                    checkedMedicines.Remove(item);
            });
        }

        private void txtsearchmedicine_TextChanged(object sender, EventArgs e)
        {
            string search = txtsearchmedicine.Text.Trim().ToLower();
            chklistmedicine.Items.Clear();

            foreach (var med in allMedicines)
            {
                if (med.ToLower().StartsWith(search))
                {
                    int index = chklistmedicine.Items.Add(med);
                    if (checkedMedicines.Contains(med))
                    {
                        chklistmedicine.SetItemChecked(index, true);
                    }
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtfullname.Text))
            {
                MessageBox.Show("Please enter student info.");
                return;
            }

            if (checkedMedicines.Count == 0)
            {
                MessageBox.Show("Please select at least one medicine.");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Insert patient info first
                MySqlCommand cmdPatient = new MySqlCommand(
                    "INSERT INTO medicine_dispense(student_id, student_name, program, complain, nurse_assigned) " +
                    "VALUES(@id,@name,@prog,@comp,@nurse); SELECT LAST_INSERT_ID();", conn);
                cmdPatient.Parameters.AddWithValue("@id", txtId.Text);
                cmdPatient.Parameters.AddWithValue("@name", txtfullname.Text);
                cmdPatient.Parameters.AddWithValue("@prog", cmbprogram.Text);
                cmdPatient.Parameters.AddWithValue("@comp", txtcomplain.Text);
                cmdPatient.Parameters.AddWithValue("@nurse", cmbnurseassign.Text);

                int dispenseId = Convert.ToInt32(cmdPatient.ExecuteScalar());

                // Loop through selected medicines
                foreach (var med in checkedMedicines)
                {
                    // Insert into medicine_dispense_items
                    MySqlCommand cmdItem = new MySqlCommand(
                        "INSERT INTO medicine_dispense_items(dispense_id, item_name, quantity) VALUES(@dispenseId,@med,1);", conn);
                    cmdItem.Parameters.AddWithValue("@dispenseId", dispenseId);
                    cmdItem.Parameters.AddWithValue("@med", med);
                    cmdItem.ExecuteNonQuery();

                    // Deduct 1 from stock
                    MySqlCommand cmdStock = new MySqlCommand(
                        "UPDATE medicine_receive SET quantity = quantity - 1 WHERE item_name=@med AND quantity>0;", conn);
                    cmdStock.Parameters.AddWithValue("@med", med);
                    cmdStock.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Medicines dispensed successfully!");

            // Clear form fields and selections
            txtId.Clear();
            txtfullname.Clear();
            cmbprogram.SelectedIndex = -1;
            txtcomplain.Clear();
            cmbnurseassign.SelectedIndex = -1;
            checkedMedicines.Clear();

            LoadMedicines();           // Refresh medicine checklist
            LoadDispensedPatients();   // Refresh datagrid with new entries
        }

        private void LoadDispensedPatients()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["CHSInventoryDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("GetAllDispensedPatients", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    datagridpatients.DataSource = dt;
                    datagridpatients.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load dispensed patients: " + ex.Message);
                }
            }
        }


        private void datagridpatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
