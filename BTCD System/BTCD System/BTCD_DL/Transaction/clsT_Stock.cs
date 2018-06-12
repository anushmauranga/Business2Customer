using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTCD_System.BTCD_DL.Transaction
{
    public class clsT_Stock
    {
        #region Fields

        private SqlParameter[] p;
        private List<StockM> _lstStock;
        private SqlDataReader _reader;

        #endregion

        #region Methods

        public List<StockM> GetDealerStockByDealerId(int dealerId)
        {
            _lstStock = new List<StockM>();
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@DealerId", SqlDbType.Int) { Value = dealerId };
            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectStockByDealerId", p))
            {
                while (_reader.Read())
                {
                    _lstStock.Add(new StockM
                    {
                        StockId = int.Parse(_reader["StockId"].ToString()),
                        ItemId = int.Parse(_reader["ItemId"].ToString()),
                        ItemName = _reader["ItemName"].ToString(),
                        UserId = int.Parse(_reader["UserId"].ToString()),
                        LocationId = int.Parse(_reader["LocationId"].ToString()),
                        GradeId = int.Parse(_reader["GradeId"].ToString()),
                        Quantity = decimal.Parse(_reader["Quantity"].ToString()),
                        RemainQuantity = decimal.Parse(_reader["RemainQuantity"].ToString()),
                        UOMId = int.Parse(_reader["UOMId"].ToString()),
                        UnitPrice = decimal.Parse(_reader["UnitPrice"].ToString()),
                        CreatedDate = DateTime.Parse(_reader["CreatedDate"].ToString())
                    });
                }

                return _lstStock;
            }
        }
        #endregion
    }
}