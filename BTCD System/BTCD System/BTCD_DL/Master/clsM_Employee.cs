using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Common;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTCD_System.BTCD_DL.Master
{
    public class clsM_Employee
    {
        #region Fields

        private SqlParameter[] p;
        private List<EmployeeM> lstCustomer;
        private SqlDataReader reader;

        #endregion

        #region Methods
        public string SaveEmployee(EmployeeM Employee)
        {
            p = new SqlParameter[15];

            p[0] = new SqlParameter("@FirstName", SqlDbType.VarChar) { Value = Employee.FirstName };
            p[1] = new SqlParameter("@LastName", SqlDbType.VarChar) { Value = Employee.LastName };
            p[2] = new SqlParameter("@NickName", SqlDbType.VarChar) { Value = Employee.NickName };
            p[3] = new SqlParameter("@Address1", SqlDbType.VarChar) { Value = Employee.Address1 };
            p[4] = new SqlParameter("@Address2", SqlDbType.VarChar) { Value = Employee.Address2 };
            p[5] = new SqlParameter("@Address3", SqlDbType.VarChar) { Value = Employee.Address3 };
            p[6] = new SqlParameter("@Telephone1", SqlDbType.VarChar) { Value = Employee.Telephone1 };
            p[7] = new SqlParameter("@Telephone2", SqlDbType.VarChar) { Value = Employee.Telephone2 };
            p[8] = new SqlParameter("@BankCode", SqlDbType.VarChar) { Value = Employee.BankCode };
            p[9] = new SqlParameter("@BranchCode", SqlDbType.VarChar) { Value = Employee.BranchCode };
            p[10] = new SqlParameter("@AccountNo", SqlDbType.VarChar) { Value = Employee.AccountNo };         
            p[11] = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Employee.Email };
            p[12] = new SqlParameter("@NICNo", SqlDbType.VarChar) { Value = Employee.NICNo };
            p[13] = new SqlParameter("@Dob", SqlDbType.Date) { Value = Employee.Dob };
            p[14] = new SqlParameter("@ERRMSG", SqlDbType.VarChar, 400);
            p[14].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spInsertEmployee", p);

            return p[14].Value.ToString();
        }


        public List<AutoComplete> GetEmployee()
        {
            List<AutoComplete> lstAutoComplete = new List<AutoComplete>();

            using (reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectAllEmployee"))
            {
                while (reader.Read())
                {
                    lstAutoComplete.Add(new AutoComplete
                    {
                        value = reader["EmployeeCode"].ToString(),
                        text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString()
                    });
                }

                return lstAutoComplete;
            }
        }


        #endregion
    }
}