using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;

namespace HospitalERP.Procedures
{
    class Appointments
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public void Appointments_init()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public int addAppointment(int patient_id, int doctor_id, DateTime meet_date, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[4];
                sqlParam[0] = new SqlParameter("@patient_id", patient_id);
                sqlParam[1] = new SqlParameter("@doctor_id", doctor_id);
                sqlParam[2] = new SqlParameter("@meet_date", meet_date);
                sqlParam[3] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Add", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editAppointment(int app_id, string notes, string history, string allergies, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@id", app_id);
                sqlParam[1] = new SqlParameter("@notes", notes);
                sqlParam[2] = new SqlParameter("@history", history);
                sqlParam[3] = new SqlParameter("@allergies", allergies);
                sqlParam[4] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspAppointments_Edit", sqlParam).ToString());
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }


        public DataTable getAllAppointmentsForDate(DateTime meet_date, int doctor_id )
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@meet_date", meet_date);
                sqlParam[1] = new SqlParameter("@doc_id", doctor_id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspAppointments_GetForDateDoc", sqlParam);
                return dt.Tables[0];
            }
            catch (DbException ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }
    }
}
