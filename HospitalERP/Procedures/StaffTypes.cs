using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;
namespace HospitalERP.Procedures
{
    public class StaffTypes
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();
        /*
        public int addStaffs_oldmethod(string type_title,string type_description, bool active)
        {
            int ret = 0;
            // Create the connection.  
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand sqlCmd = new SqlCommand("uspStaffTypes_Add", conn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //sqlCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            //sqlCmd.Parameters["@id"].Value = this.parsedCustomerID;

            sqlCmd.Parameters.Add(new SqlParameter("@type_title", SqlDbType.VarChar));
            sqlCmd.Parameters["@type_title"].Value = type_title;


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
        */
        public int addStaffs(string type_title, string type_description, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@name", type_title);
                sqlParam[1] = new SqlParameter("@desc", type_description);
                sqlParam[2] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspStaffTypes_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editTypes(int id, string name, string desc, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", name);
                sqlParam[2] = new SqlParameter("@desc", desc);
                sqlParam[3] = new SqlParameter("@active", active);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspStaffTypes_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }
        public DataTable GetRecords(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspStaffTypes_Get", sqlParam);
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
