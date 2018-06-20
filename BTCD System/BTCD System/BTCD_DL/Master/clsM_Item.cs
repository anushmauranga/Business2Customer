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
        private List<ItemM> lstItem;
        private SqlDataReader reader;

        #endregion

        #region Methods

        public List<ItemM> GetItemsByCategories(int category)
        {
            lstItem = new List<ItemM>();
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@CategoryId", SqlDbType.Int) { Value = category };
            using (reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectItemByCategory", p))
            {
                while (reader.Read())
                {
                    lstItem.Add(new ItemM
                    {
                        ItemId = int.Parse(reader["ItemId"].ToString()),
                        CategoryId = int.Parse(reader["CategoryId"].ToString()),
                        ItemCode = reader["ItemCode"].ToString(),
                        ItemName = reader["ItemName"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }

                return lstItem;
            }
        }


        public ItemM GetItemByItemId(int ItemId)
        {

            ItemM ItemM = new ItemM();

            p = new SqlParameter[1];
            p[0] = new SqlParameter("@ItemId", SqlDbType.Int) { Value = ItemId };

            using (reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectItemByItemId", p))
            {
                while (reader.Read())
                {
                    ItemM = new ItemM
                    {
                        ItemId = int.Parse(reader["ItemId"].ToString()),
                        CategoryId = int.Parse(reader["CategoryId"].ToString()),
                        ItemCode = reader["ItemCode"].ToString(),
                        ItemName = reader["ItemName"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }

                return ItemM;
            }
        }

        #endregion
    }
}
