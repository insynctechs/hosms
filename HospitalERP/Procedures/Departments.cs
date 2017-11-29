using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace HospitalERP.Procedures
{
    class Departments
    {
        string connstr = HospitalERP.Helpers.DBHelper.GetConnectionString();
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public void Departments_init()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public int addTypes(string type_title,string type_description,  bool active)
        {
            //Departments_init();
            int ret = -1;
            // Create the connection.  
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand sqlCmd = new SqlCommand("uspDepartments_Add", conn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //sqlCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            //sqlCmd.Parameters["@id"].Value = this.parsedCustomerID;

            sqlCmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
            sqlCmd.Parameters["@name"].Value = type_title;

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
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                ret = (int)sqlCmd.Parameters["@Ret"].Value;
                //log.Info("Department added succesfully");

            }
            catch (Exception ex)
            {
               ret = -1;
               log.Error(ex.Message, ex);
            }
            finally
            {
                //Close connection.  
                conn.Close();
            }
            return ret;

        }

        public int editTypes(int id,string name, string desc, bool active)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@id", id);
                sqlParam[1] = new SqlParameter("@name", id);
                sqlParam[2] = new SqlParameter("@desc", id);
                sqlParam[3] = new SqlParameter("@active", active);
                sqlParam[4] = new SqlParameter("@Ret", 0);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDepartments_Edit", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable GetDepartments(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspDepartments_Get", sqlParam);
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
