using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
namespace HospitalERP.Procedures
{
    class ProcTypes
    {
        string connstr = HospitalERP.Helpers.DBHelper.GetConnectionString();
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public int addTypes(string type_title, string type_description, bool active)
        {
            int ret = 0;
            // Create the connection.  
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand sqlCmd = new SqlCommand("uspProcedureTypes_Add", conn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //sqlCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            //sqlCmd.Parameters["@id"].Value = this.parsedCustomerID;

            sqlCmd.Parameters.Add(new SqlParameter("@type_name", SqlDbType.VarChar));
            sqlCmd.Parameters["@type_name"].Value = type_title;


            sqlCmd.Parameters.Add(new SqlParameter("@description", SqlDbType.Text));
            sqlCmd.Parameters["@description"].Value = type_description;

            sqlCmd.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit));
            sqlCmd.Parameters["@active"].Value = active;

            sqlCmd.Parameters.Add(new SqlParameter("@Ret", SqlDbType.Int));
            sqlCmd.Parameters["@Ret"].Value = 0;
            sqlCmd.Parameters["@Ret"].Direction = ParameterDirection.Output;

            //try-catch-finally  
            try
            {
                //Open connection.  
                conn.Open();

                //Run the stored procedure.  
                sqlCmd.ExecuteNonQuery();

                ret = (int)sqlCmd.Parameters["@Ret"].Value;

            }
            catch (Exception ex)
            {
                //ret = ex.ToString();
                //A simple catch.  
                ret = -1;
                //MessageBox.Show("User could not be added." + ex.ToString());

            }
            finally
            {
                //Close connection.  
                conn.Close();
            }
            return ret;

        }

        public int InsertProc(string DepartmentName,string description, bool Active)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@type_name", DepartmentName);
            sqlParam[1] = new SqlParameter("@description", description);
            sqlParam[2] = new SqlParameter("@active", Active);
            Int32 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(connstr, CommandType.StoredProcedure, "uspInsertProcedureTypes", sqlParam).ToString());
            return Id;
        }

        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(connstr, CommandType.StoredProcedure, "uspProcedureTypes_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable SearchValues()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                dt.Rows.Add(new object[] { "All", "All" });
                //dt.Rows.Add(new object[] { "id", "ID" });
                dt.Rows.Add(new object[] { "name", "Name" });
                dt.Rows.Add(new object[] { "active", "Active" });
                return dt;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

    }
}
