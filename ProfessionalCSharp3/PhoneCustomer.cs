using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp3
{
    public class PhoneCustomer
    {
        //常量
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;
        public string FirstName;
        public string LastName;
    }

    struct PhoneCustomerStruct
    {
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;
        public string FirstName;
        public string LastName;
    }

    public class DoumentEditor
    {
        private static readonly uint s_maxDocuments;

        static DoumentEditor()
        {
            s_maxDocuments = 1;
        }
    }
}
