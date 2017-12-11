﻿using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;


namespace HospitalERP.Procedures
{
    class ConsultationDetails
    {
        string conn = HospitalERP.Helpers.DBHelper.Constr;
        log4net.ILog log = HospitalERP.Helpers.DBHelper.GetLogObject();

        public DataTable getRecordFromID(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspConsultationDet_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable getAllProcedures()
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[0];
                
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedures_ALL", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetProceduresIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedures_Combo", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }


        public DataTable ProceduresCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetProceduresIDName(id);
                foreach (DataRow dr in dt1.Rows)
                {
                    dt.Rows.Add(dr.ItemArray);
                }                               
                return dt;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable StatusCombo(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Rows.Add(new object[] { "0", "Select Type" });
                DataTable dt1 = new DataTable();
                dt1 = GetStatusIDName(id);
                foreach (DataRow dr in dt1.Rows)
                {
                    dt.Rows.Add(dr.ItemArray);
                }
                return dt;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable GetStatusIDName(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet dt = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedureStatus_Get", sqlParam);
                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }
        
        public DataTable getProceduresFromApptID(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspConsultationDet_Procedures_Get", sqlParam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable getApptHistory(int appt_id, int patient_id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@id", appt_id);
                sqlParam[1] = new SqlParameter("@patient_id", patient_id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspConsultationDet_Get_History", sqlParam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public DataTable getProceduresFromProcID(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspConsultationDet_Procedures_Single", sqlParam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public string getProcedureFees(int id)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@id", id);
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "uspProcedures_GetFee", sqlParam);
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }

        }

        public int saveDiagnosis(int appid, int patientid, string history, string allergy, string app_notes)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@appointment_id", appid);
                sqlParam[1] = new SqlParameter("@patient_id", patientid);
                sqlParam[2] = new SqlParameter("@history", history);
                sqlParam[3] = new SqlParameter("@allergies", allergy);
                sqlParam[4] = new SqlParameter("@notes", app_notes);                
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspConsultationDet_SaveDiagnosis", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public int addProcedures(int patientid, int doctorid,int apptid,int procid, string notes, decimal fee, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[7];
                sqlParam[0] = new SqlParameter("@doctor_id", doctorid);
                sqlParam[1] = new SqlParameter("@patient_id", patientid);
                sqlParam[2] = new SqlParameter("@appointment_id", apptid);
                sqlParam[3] = new SqlParameter("@procedure_id", procid);
                sqlParam[4] = new SqlParameter("@notes", notes);
                sqlParam[5] = new SqlParameter("@fee", fee);
                sqlParam[6] = new SqlParameter("@status", status);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspConsultationDet_AddProcedure", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

        public int editProcedures(int id,int patientid, int doctorid, int apptid, int procid, string notes, decimal fee, int status)
        {
            int ret = -1;
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[8];
                sqlParam[0] = new SqlParameter("@doctor_id", doctorid);
                sqlParam[1] = new SqlParameter("@patient_id", patientid);
                sqlParam[2] = new SqlParameter("@appointment_id", apptid);
                sqlParam[3] = new SqlParameter("@procedure_id", procid);
                sqlParam[4] = new SqlParameter("@notes", notes);
                sqlParam[5] = new SqlParameter("@fee", fee);
                sqlParam[6] = new SqlParameter("@status", status);
                sqlParam[7] = new SqlParameter("@id", id);
                ret = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "uspConsultationDet_EditProcedure", sqlParam).ToString());
            }
            catch (Exception ex)
            {
                ret = -1;
                log.Error(ex.Message, ex);
            }
            return ret;
        }

    }
}