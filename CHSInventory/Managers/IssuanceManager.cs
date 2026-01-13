using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace CHSInventory
{
    public class IssuanceManager
    {
        private string connectionString = ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        // ================= GET ALL NURSES =================
        public List<string> GetAllNurses()
        {
            List<string> nurses = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_GetAllNurses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nurses.Add(reader["first_name"].ToString());
                    }
                }
            }

            return nurses;
        }

        // ================= GET AVAILABLE MEDICINES =================
        public List<string> GetAvailableMedicines()
        {
            List<string> medicines = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_GetAvailableMedicines", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicines.Add(reader["item_name"].ToString());
                    }
                }
            }

            return medicines;
        }

        // ================= GET NURSE ID BY NAME =================
        public int GetNurseIdByName(string nurseName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_GetNurseIdByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nurse_name", nurseName);

                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value
                    ? Convert.ToInt32(result)
                    : -1;
            }
        }

        // ================= CHECK MEDICINE STOCK =================
        public int CheckMedicineStock(string medicineName, int requiredQuantity)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_CheckMedicineStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_item_name", medicineName);
                cmd.Parameters.AddWithValue("p_required_quantity", requiredQuantity);

                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value
                    ? Convert.ToInt32(result)
                    : 0;
            }
        }

        // ================= ADD PATIENT WITH MEDICINES (COMPLETE TRANSACTION) =================
        public void AddPatientWithMedicines(
            string studentId,
            string studentName,
            string program,
            string complaint,
            string nurseAssigned,
            List<string> medicines)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // 1. Get Nurse ID
                    MySqlCommand nurseCmd = new MySqlCommand("sp_GetNurseIdByName", conn, tx);
                    nurseCmd.CommandType = CommandType.StoredProcedure;
                    nurseCmd.Parameters.AddWithValue("p_nurse_name", nurseAssigned);

                    object nurseResult = nurseCmd.ExecuteScalar();
                    if (nurseResult == null || nurseResult == DBNull.Value)
                    {
                        throw new Exception("Nurse not found.");
                    }
                    int nurseId = Convert.ToInt32(nurseResult);

                    // 2. Insert Patient Visit
                    MySqlCommand visitCmd = new MySqlCommand("sp_InsertPatientVisit", conn, tx);
                    visitCmd.CommandType = CommandType.StoredProcedure;
                    visitCmd.Parameters.AddWithValue("p_student_id", studentId);
                    visitCmd.Parameters.AddWithValue("p_program", program);
                    visitCmd.Parameters.AddWithValue("p_complaint", complaint);
                    visitCmd.Parameters.AddWithValue("p_user_id", nurseId);

                    object visitResult = visitCmd.ExecuteScalar();
                    int visitId = Convert.ToInt32(visitResult);

                    // 3. Insert Medicine Dispense Record
                    MySqlCommand dispCmd = new MySqlCommand("sp_InsertMedicineDispense", conn, tx);
                    dispCmd.CommandType = CommandType.StoredProcedure;
                    dispCmd.Parameters.AddWithValue("p_student_id", studentId);
                    dispCmd.Parameters.AddWithValue("p_student_name", studentName);
                    dispCmd.Parameters.AddWithValue("p_program", program);
                    dispCmd.Parameters.AddWithValue("p_complaint", complaint);
                    dispCmd.Parameters.AddWithValue("p_nurse_assigned", nurseAssigned);
                    dispCmd.Parameters.AddWithValue("p_visit_id", visitId);

                    object dispenseResult = dispCmd.ExecuteScalar();
                    int dispenseId = Convert.ToInt32(dispenseResult);

                    // 4. Add Each Medicine and Deduct Stock
                    foreach (var medicine in medicines)
                    {
                        // Insert dispense item
                        MySqlCommand itemCmd = new MySqlCommand("sp_InsertDispenseItem", conn, tx);
                        itemCmd.CommandType = CommandType.StoredProcedure;
                        itemCmd.Parameters.AddWithValue("p_dispense_id", dispenseId);
                        itemCmd.Parameters.AddWithValue("p_item_name", medicine);
                        itemCmd.Parameters.AddWithValue("p_quantity", 1);
                        itemCmd.ExecuteNonQuery();

                        // Deduct stock (FIFO)
                        MySqlCommand stockCmd = new MySqlCommand("sp_DeductMedicineStock", conn, tx);
                        stockCmd.CommandType = CommandType.StoredProcedure;
                        stockCmd.Parameters.AddWithValue("p_item_name", medicine);
                        stockCmd.Parameters.AddWithValue("p_quantity", 1);

                        object stockResult = stockCmd.ExecuteScalar();
                        int rowsAffected = Convert.ToInt32(stockResult);

                        if (rowsAffected == 0)
                        {
                            throw new Exception($"Insufficient stock for medicine: {medicine}");
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        // ================= GET ALL DISPENSED PATIENTS =================
        public DataTable GetAllDispensedPatients()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllDispensedPatients", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= SEARCH DISPENSED PATIENTS =================
        public DataTable SearchDispensedPatients(string searchText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_SearchDispensedPatients", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_search_text", searchText);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= UPDATE DISPENSE RECORD =================
        public int UpdateMedicineDispense(
            int id,
            string studentId,
            string studentName,
            string program,
            string complaint,
            string nurseAssigned)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_UpdateMedicineDispense", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id", id);
                cmd.Parameters.AddWithValue("p_student_id", studentId);
                cmd.Parameters.AddWithValue("p_student_name", studentName);
                cmd.Parameters.AddWithValue("p_program", program);
                cmd.Parameters.AddWithValue("p_complaint", complaint);
                cmd.Parameters.AddWithValue("p_nurse_assigned", nurseAssigned);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // ================= GET DISPENSE BY ID =================
        public DataRow GetDispenseById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetDispenseById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }

                return null;
            }
        }
    }
}