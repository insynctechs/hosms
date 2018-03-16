using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace HospitalERP.Helpers
{
    internal class DBHelper
    {        
        public static string Constr
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"].ConnectionString;
            }
        }

        
        public static log4net.ILog GetLogObject()
        {
            log4net.ILog log;
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            return log;
        }
        
    }
}
