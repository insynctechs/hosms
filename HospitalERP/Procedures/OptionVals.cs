using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace HospitalERP.Procedures
{
    class OptionVals
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public DataTable SearchValues()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "All", "All" });
                //dt.Rows.Add(new object[] { "id", "ID" });
                dt.Rows.Add(new object[] { "op_name", "Name" });
                dt.Rows.Add(new object[] { "op_value", "Value" });
                return dt;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public int InsertOption(string name, string description, string val)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@name", name);
            sqlParam[1] = new SqlParameter("@description", description);
            sqlParam[2] = new SqlParameter("@aval", val);
            Int32 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspOptions_Add", sqlParam).ToString());
            return Id;
        }

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspOptions_Get", sqlParam);
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
