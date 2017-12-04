using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Users
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public void Users_init()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public int Users_Valid(string empid, string pwd)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@empid", empid);
                sqlParam[1] = new SqlParameter("@pwd", pwd);
                int ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspUsers_ValidateLogin", sqlParam));
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return 0;
            }
        }

        public DataTable GetLoggedUser(string empid)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@empid", empid);                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspDepartments_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }
        }

        public int SetLoginDetails(string empid)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@empid", empid);
                int ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDepartments_Get", sqlParam));
                return ret;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return 0;
            }
        }


    }
}
