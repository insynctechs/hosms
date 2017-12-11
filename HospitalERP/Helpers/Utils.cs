using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Specialized;

namespace HospitalERP.Helpers
{
    class Utils
    {
        public static NameValueCollection AppointmentStatus = new NameValueCollection()
        {
            { "Scheduled","1" },
            { "Completed", "2" },
            { "On-Hold","3" },
            { "Billed","4" }
        };

        public static NameValueCollection ProcedureStatus = new NameValueCollection()
        {
            { "Scheduled","1" },
            { "Completed", "2" },
            { "On-Hold","3" }
        };

        public static NameValueCollection BillStatus = new NameValueCollection()
        {
            { "Generated", "1" },
            { "Pending", "2"  },
            {"Partial Paid", "3" },
            { "Paid", "4" }
        };

        public static NameValueCollection Gender = new NameValueCollection()
        {
            { "M", "Male" },
            { "F", "Female"  }
            
        };

        public static string FormatAmount(double d, int decimalPlaces=3)
        {
            string format = String.Format("{{0:0.{0}}}", new string('0', decimalPlaces));
            return String.Format(format, d);
        }
    }
}
