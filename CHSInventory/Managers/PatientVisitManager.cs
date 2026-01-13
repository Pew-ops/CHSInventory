using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace CHSInventory
{
    public class PatientVisitsManager
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
                MySqlCommand cmd = new MySqlCommand("GetAvailableMedicines", conn);
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

        // ================= ADD PATIENT WITH MEDICINES (TRANSACTION) =================
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
                    int nurseId = Convert.ToInt32(nurseCmd.ExecuteScalar());

                    // 2. Add Patient Visit
                    MySqlCommand visitCmd = new MySqlCommand("sp_AddPatientVisit", conn, tx);
                    visitCmd.CommandType = CommandType.StoredProcedure;
                    visitCmd.Parameters.AddWithValue("p_student_id", studentId);
                    visitCmd.Parameters.AddWithValue("p_program", program);
                    visitCmd.Parameters.AddWithValue("p_complaint", complaint);
                    visitCmd.Parameters.AddWithValue("p_user_id", nurseId);
                    int visitId = Convert.ToInt32(visitCmd.ExecuteScalar());

                    // 3. Add Medicine Dispense Record
                    MySqlCommand dispCmd = new MySqlCommand("sp_AddMedicineDispense", conn, tx);
                    dispCmd.CommandType = CommandType.StoredProcedure;
                    dispCmd.Parameters.AddWithValue("p_student_id", studentId);
                    dispCmd.Parameters.AddWithValue("p_student_name", studentName);
                    dispCmd.Parameters.AddWithValue("p_program", program);
                    dispCmd.Parameters.AddWithValue("p_complaint", complaint);
                    dispCmd.Parameters.AddWithValue("p_nurse_assigned", nurseAssigned);
                    dispCmd.Parameters.AddWithValue("p_visit_id", visitId);
                    int dispenseId = Convert.ToInt32(dispCmd.ExecuteScalar());

                    // 4. Add each medicine and deduct stock
                    foreach (var medicine in medicines)
                    {
                        // Add dispense item
                        MySqlCommand itemCmd = new MySqlCommand("sp_AddMedicineDispenseItem", conn, tx);
                        itemCmd.CommandType = CommandType.StoredProcedure;
                        itemCmd.Parameters.AddWithValue("p_dispense_id", dispenseId);
                        itemCmd.Parameters.AddWithValue("p_item_name", medicine);
                        itemCmd.Parameters.AddWithValue("p_quantity", 1);
                        itemCmd.ExecuteNonQuery();

                        // Deduct from stock
                        MySqlCommand stockCmd = new MySqlCommand("sp_DeductMedicineStock", conn, tx);
                        stockCmd.CommandType = CommandType.StoredProcedure;
                        stockCmd.Parameters.AddWithValue("p_item_name", medicine);
                        stockCmd.Parameters.AddWithValue("p_quantity", 1);
                        stockCmd.ExecuteNonQuery();
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

        // ================= UPDATE PATIENT DISPENSE =================
        public int UpdatePatientDispense(
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
                MySqlCommand cmd = new MySqlCommand("sp_UpdatePatientDispense", conn);
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

        // ================= GET ALL PATIENT RECORDS WITH MEDICINES =================
        public DataTable GetAllPatientRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllPatientRecords", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= GET ALL PATIENTS WITH MEDICINES (ALTERNATIVE) =================
        public DataTable GetAllPatientsWithMedicines()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetAllPatientsWithMedicines", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= GET PATIENT HISTORY =================
        public DataTable GetPatientHistory(string studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("GetPatientHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_student_id", studentId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= GET PATIENT HISTORY BY STUDENT ID (ALTERNATIVE) =================
        public DataTable GetPatientHistoryByStudentId(string studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetPatientHistoryByStudentId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_student_id", studentId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= GET DISPENSE ITEMS BY DISPENSE ID =================
        public DataTable GetDispenseItemsByDispenseId(int dispenseId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetDispenseItemsByDispenseId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_dispense_id", dispenseId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}