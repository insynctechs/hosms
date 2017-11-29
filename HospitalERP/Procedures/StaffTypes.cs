using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HospitalERP.Procedures
{
    public class StaffTypes
    {
        string connstr = HospitalERP.Helpers.DBHelper.GetConnectionString();

        public int addStaffs(string type_title,string type_description, bool active)
        {
            int ret = 0;
            // Create the connection.  
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand sqlCmd = new SqlCommand("uspAddStaffTypes", conn);
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
    }
}
