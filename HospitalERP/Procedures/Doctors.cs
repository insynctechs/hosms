using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Doctors
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public void Departments_init()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public int addDoctors(string first_name, string last_name,int department_id, string designation,
            string qualification, string specialization,char gender, DateTime dob,  string nationality, string legal_id, 
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, bool active, Double consultation_fee)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[18];
                sqlParam[0] = new SqlParameter("@first_name",first_name);
                sqlParam[1] = new SqlParameter("@last_name", last_name);
                sqlParam[2] = new SqlParameter("@department_id", department_id);
                sqlParam[3] = new SqlParameter("@designation",designation);
                sqlParam[4] = new SqlParameter("@qualification", qualification);
                sqlParam[5] = new SqlParameter("@specialization", specialization);
                sqlParam[6] = new SqlParameter("@gender", gender);
                sqlParam[7] = new SqlParameter("@dob", dob);
                sqlParam[8] = new SqlParameter("@nationality", nationality);
                sqlParam[9] = new SqlParameter("@legal_id", legal_id);
                sqlParam[10] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[11] = new SqlParameter("@address", address);
                sqlParam[12] = new SqlParameter("@city", city);
                sqlParam[13] = new SqlParameter("@state", state);
                sqlParam[14] = new SqlParameter("@zip", zip);
                sqlParam[15] = new SqlParameter("@phone", phone);
                sqlParam[16] = new SqlParameter("@email", email);
                sqlParam[17] = new SqlParameter("@consultation_fee", consultation_fee);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDoctors_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editDoctors(int id, string first_name, string last_name, int department_id, string designation,
            string qualification, string specialization, char gender, DateTime dob, string nationality, string legal_id,
            DateTime legal_id_expiry, string address, string city, string state, string zip,
            string phone, string email, bool active, Double consultation_fee)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[18];
                sqlParam[0] = new SqlParameter("@first_name", first_name);
                sqlParam[1] = new SqlParameter("@last_name", last_name);
                sqlParam[2] = new SqlParameter("@department_id", department_id);
                sqlParam[3] = new SqlParameter("@designation", designation);
                sqlParam[4] = new SqlParameter("@qualification", qualification);
                sqlParam[5] = new SqlParameter("@specialization", specialization);
                sqlParam[6] = new SqlParameter("@gender", gender);
                sqlParam[7] = new SqlParameter("@dob", dob);
                sqlParam[8] = new SqlParameter("@nationality", nationality);
                sqlParam[9] = new SqlParameter("@legal_id", legal_id);
                sqlParam[10] = new SqlParameter("@legal_id_expiry", legal_id_expiry);
                sqlParam[11] = new SqlParameter("@address", address);
                sqlParam[12] = new SqlParameter("@city", city);
                sqlParam[13] = new SqlParameter("@state", state);
                sqlParam[14] = new SqlParameter("@zip", zip);
                sqlParam[15] = new SqlParameter("@phone", phone);
                sqlParam[16] = new SqlParameter("@email", email);
                sqlParam[17] = new SqlParameter("@consultation_fee", consultation_fee);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspDoctors_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable GetDoctors(string SearchBy, string SearchValue)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SearchBy", SearchBy);
                sqlParam[1] = new SqlParameter("@SearchValue", SearchValue);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspDoctors_Get", sqlParam);
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
