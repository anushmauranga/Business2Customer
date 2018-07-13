using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Common;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTCD_System.BTCD_DL.Transaction
{
    public class clsT_CustomerRequirment
    {
        private SqlParameter[] p;

        public string SaveCustomerRequirment(List<CustomerRequirment> lstCustomerRequirment, out string CustomerRequirmentNo)
        {
            p = new SqlParameter[3];

            try
            {
                p[0] = new SqlParameter("@CustomerReq_D", SqlDbType.Structured);
                p[0].Value = commonFunctions.ToDataTable<CustomerRequirment>(lstCustomerRequirment);
                p[1] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
                p[1].Direction = ParameterDirection.Output;
                p[2] = new SqlParameter("@ERRMSG", SqlDbType.VarChar, 400);
                p[2].Direction = ParameterDirection.Output;


                SqlHelper.ExecuteNonQuery(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "_spInsertCustomerRequirment", p);

                CustomerRequirmentNo = p[1].Value.ToString();

                return p[2].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}