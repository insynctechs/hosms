using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Bill
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public void Bill_init()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public int AddBill(int aid, int pid, decimal amount, int type)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@appointment_id", aid);
                sqlParam[1] = new SqlParameter("@patient_id", pid);               
                sqlParam[2] = new SqlParameter("@bill_amount", amount);
                sqlParam[3] = new SqlParameter("@bill_type", type);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspBill_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public DataTable GetAppointmentBill(int aid, int pid, int type)
        {
            
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@appointment_id", aid);
                sqlParam[1] = new SqlParameter("@patient_id", pid);
                sqlParam[2] = new SqlParameter("@bill_type", type);              
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBill_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBillTypes(int hasall = 0)
        {

            try
            {
               
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillTypes_Get");
                if (hasall == 1)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "Choose One";
                    dt.Tables[0].Rows.InsertAt(dr, 0);
                }
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }
        }

        public DataTable GetBillStatus(int hasall = 0)
        {

            try
            {

                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspBillStatus_Get");
                if (hasall == 1)
                {
                    DataRow dr = dt.Tables[0].NewRow();
                    dr["id"] = 0;
                    dr["name"] = "All";
                    dt.Tables[0].Rows.InsertAt(dr, 0);
                }
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }
        }


    }
}
