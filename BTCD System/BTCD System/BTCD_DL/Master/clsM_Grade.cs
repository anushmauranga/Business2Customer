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
        private List<ItemGradeM> _lstItemGrade;
        private SqlDataReader _reader;

        #endregion

        #region Methods

        public List<ItemGradeM> GetItemGradeByItemId(int itemId)
        {
            _lstItemGrade = new List<ItemGradeM>();
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@ItemId", SqlDbType.Int) { Value = itemId };
            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectItemGrades", p))
            {
                while (_reader.Read())
                {
                    _lstItemGrade.Add(new ItemGradeM
                    {
                        ItemId = int.Parse(_reader["ItemId"].ToString()),
                        Grade = _reader["Grade"].ToString(),
                        GradeDescription = _reader["GradeDescription"].ToString(),
                        GradeLevel = int.Parse(_reader["GradeLevel"].ToString())
                    });
                }

                return _lstItemGrade;
            }
        }
        #endregion
    }
}