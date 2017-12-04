using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace HospitalERP.Procedures
{
    class Menus
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMenus_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetMenuActive(Boolean active)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@active", active);                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspMenus_GetActive", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }
    }
}
