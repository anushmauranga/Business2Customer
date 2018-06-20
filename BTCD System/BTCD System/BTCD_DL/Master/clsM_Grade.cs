using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTCD_System.BTCD_DL.Master
{
    public class clsM_Grade
    {
        #region Fields

        private SqlParameter[] p;
        private List<ItemGradeM> lstItemGrade;
        private SqlDataReader _reader;

        #endregion

        #region Methods

        public List<ItemGradeM> GetItemGradeByItemId(int ItemId)
        {
            lstItemGrade = new List<ItemGradeM>();

            p = new SqlParameter[1];
            p[0] = new SqlParameter("@ItemId", SqlDbType.Int) { Value = ItemId };

            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectItemGradesByItem", p))
            {
                while (_reader.Read())
                {
                    lstItemGrade.Add(new ItemGradeM
                    {
                        GradeId = int.Parse(_reader["GradeId"].ToString()),
                        ItemId = int.Parse(_reader["ItemId"].ToString()),
                        Grade = _reader["Grade"].ToString(),
                        GradeDescription = _reader["GradeDescription"].ToString(),
                        GradeLevel = int.Parse(_reader["GradeLevel"].ToString())
                    });
                }

                return lstItemGrade;
            }
        }


        public List<ItemGradeM> GetAllGrades()
        {
            lstItemGrade = new List<ItemGradeM>();

            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectAllFromItemGrades"))
            {
                while (_reader.Read())
                {
                    lstItemGrade.Add(new ItemGradeM
                    {
                        GradeId = int.Parse(_reader["GradeId"].ToString()),
                        ItemId = int.Parse(_reader["ItemId"].ToString()),
                        Grade = _reader["Grade"].ToString(),
                        GradeDescription = _reader["GradeDescription"].ToString(),
                        GradeLevel = int.Parse(_reader["GradeLevel"].ToString())
                    });
                }

                return lstItemGrade;
            }
        }
        #endregion
    }
}