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
            { "On-Hold","3" }
        };

        public static NameValueCollection ProcedureStatus = new NameValueCollection()
        {
            { "Scheduled","1" },
            { "Completed", "2" },
            { "On-Hold","3" }
        };

        public static NameValueCollection BillStatus = new NameValueCollection()
        {
            { "Paid", "1" },
            { "Pending", "2"  },
            {"Partial Paid", "3" }
        };
    }
}
