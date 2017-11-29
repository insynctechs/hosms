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
        //Get the connection string from App config file.  
        internal static string GetConnectionString()
        {            
            string returnValue = null;
                    
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["HospitalERP.Properties.Settings.connstr"];

            //ConnectionStringSettings settings =
            //ConfigurationManager.ConnectionStrings["conString"];


            //If found, return the connection string.  
            if (settings != null)
              returnValue = settings.ConnectionString;

            return returnValue;
        }

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
        public DataSet GetDataSetFromWebApi(string path)
        {
            /*
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(res);
                return ds;
            }
           
            */
            return null;
        }

        public DataTable GetDataTableFromWebApi(string path)
        {
            /*
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                DataSet dt = JsonConvert.DeserializeObject<DataSet>(res);
                return dt.Tables[0];
            }
            
            */
           return null;
        }

        public int GetExecuteNonQueryResFromWebApi(string path)
        {
            /*
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                int ret = JsonConvert.DeserializeObject<int>(res);
                return ret;
            }
            return 0;
            */
            return 0;
        }


        public string GetExecuteNonQueryStringResFromWebApi(string path)
        {
            /*
            var url = string.Format(path);
            HttpResponseMessage response = Utils.Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                string ret = JsonConvert.DeserializeObject<string>(res);
                return ret;
            }
            else
                return "Error";// + response.StatusCode.ToString();
                */
            return null;
        }


    }
}
