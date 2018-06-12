using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTCD_System.BTCD_DL.Master
{
    public class clsM_Item
    {
        #region Fields

        private SqlParameter[] p;
        private List<ItemM> _lstItem;
        private SqlDataReader _reader;

        #endregion

        #region Methods

        public List<ItemM> GetItemsByCategories(int category)
        {
            _lstItem = new List<ItemM>();
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@CategoryId", SqlDbType.Int) { Value = category };
            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectItemByCategory", p))
            {
                while (_reader.Read())
                {
                    _lstItem.Add(new ItemM
                    {
                        ItemId = int.Parse(_reader["ItemId"].ToString()),
                        CategoryId = int.Parse(_reader["CategoryId"].ToString()),
                        ItemCode = int.Parse(_reader["ItemCode"].ToString()),
                        ItemName = _reader["ItemName"].ToString(),
                        Description = _reader["Description"].ToString()
                    });
                }

                return _lstItem;
            }
        }
        #endregion
    }
}
