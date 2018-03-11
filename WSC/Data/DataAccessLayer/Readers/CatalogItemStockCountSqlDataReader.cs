using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class CatalogItemStockCountSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalNumberInStock;

        public CatalogItemStockCountSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public CatalogItemStockCountSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public CatalogItemStockCountSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalNumberInStock = GetOrdinal("NumberInStock");
        }

        public int NumberInStock
        {
            get 
            {
                return GetInt32(_ordinalNumberInStock);
            }
        }
    }
}

