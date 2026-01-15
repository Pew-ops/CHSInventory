using System;

namespace CHSInventory.Admin
{
    public static class UserFactory
    {
        public static User1 CreateUser(string role)
        {
            switch (role)
            {
                case "Admin":
                    return new AdminUser();
                case "Nurses":
                    return new NurseUser();
                case "STA":
                    return new InventoryClerkUser();
                default:
                    return null;
            }
        }
    }
}
