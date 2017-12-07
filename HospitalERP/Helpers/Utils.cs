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
        NameValueCollection AppointmentStatus = new NameValueCollection()
        {
            { "1", "Scheduled" },
            { "2", "Completed" },
            {"3","On-Hold" }
        };

        NameValueCollection ProcedureStatus = new NameValueCollection()
        {
            { "1", "Scheduled" },
            { "2", "Completed" },
            {"3","On-Hold" }
        };

        NameValueCollection BillStatus = new NameValueCollection()
        {
            { "1", "Paid" },
            { "2", "Pending" },
            {"3","Partial Paid" }
        };
    }
}
