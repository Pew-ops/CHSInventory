using System.Windows.Forms;
using CHSInventory;


namespace CHSInventory.Admin
{
    // Base abstract class
    public abstract class User1
    {
        public abstract void Login();
    }

    // ================= ADMIN =================
    public class AdminUser : User1
    {
        public override void Login()
        {
            Admin1 dashboard = new Admin1();
            dashboard.Show();
        }
    }

    // ================= NURSE =================
    public class NurseUser : User1
    {
        public override void Login()
        {
            Nurses dashboard = new Nurses();
            dashboard.Show();
        }
    }

    // ============== INVENTORY CLERK ==========
    public class InventoryClerkUser : User1
    {
        public override void Login()
        {
            Sta dashboard = new Sta();
            dashboard.Show();
        }
    }
}

