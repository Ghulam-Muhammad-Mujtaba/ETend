using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Constants
{
    public class Constants
    {
        public const string Role_User_Indi = "Individual";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_Driver = "Driver";
        public const string Role_Retailer = "Retailer";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusDelivered = "Delivered";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";

        public const string SessionCart = "SessionShoppingCart";
    }
}
