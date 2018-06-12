using BTCD_System.BTCD_DL.Connection;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTCD_System.BTCD_DL.Transaction
{
    public class clsT_Bids
    {
        #region Fields

        private SqlParameter[] p;
        private List<BidsM> _lstBid;
        private SqlDataReader _reader;

        #endregion

        #region Methods

        public List<BidsM> GetDealersStockBids(int dealerId)
        {
            _lstBid = new List<BidsM>();
            p = new SqlParameter[1];

            p[0] = new SqlParameter("@UserId", SqlDbType.Int) { Value = dealerId };
            using (_reader = SqlHelper.ExecuteReader(clsConnectionString.getConnectionString(), CommandType.StoredProcedure, "spSelectBidstoMyStock", p))
            {
                while (_reader.Read())
                {
                    _lstBid.Add(new BidsM
                    {
                        BidId = int.Parse(_reader["BidId"].ToString()),
                        StockId = int.Parse(_reader["StockId"].ToString()),
                        RequestedBy = int.Parse(_reader["RequestedBy"].ToString()),
                        RequestedQty = decimal.Parse(_reader["RequestedQty"].ToString()),
                        RequestedPrice = decimal.Parse(_reader["RequestedPrice"].ToString()),
                        IsConfirmed = bool.Parse(_reader["IsConfirmed"].ToString()),
                        CreatedDate = DateTime.Parse(_reader["CreatedDate"].ToString())
                    });
                }

                return _lstBid;
            }
        }
        #endregion
    }
}