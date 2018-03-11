using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class CatalogItemSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalCatalogItemId;
        private readonly int _ordinalItemName;
        private readonly int _ordinalManufacturer;
        private readonly int _ordinalNumberInscriptionLines;
        private readonly int _ordinalNumberLineCharacters;
        private readonly int _ordinalItemCost;
        private readonly int _ordinalItemRetailPrice;
        private readonly int _ordinalInscriptionTypeId;

        public CatalogItemSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public CatalogItemSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public CatalogItemSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalCatalogItemId = GetOrdinal("catalogItemId");
            _ordinalItemName = GetOrdinal("itemName");
            _ordinalManufacturer = GetOrdinal("manufacturer");
            _ordinalNumberInscriptionLines = GetOrdinal("numberInscriptionLines");
            _ordinalNumberLineCharacters = GetOrdinal("numberLineCharacters");
            _ordinalItemCost = GetOrdinal("itemCost");
            _ordinalItemRetailPrice = GetOrdinal("itemRetailPrice");
            _ordinalInscriptionTypeId = GetOrdinal("inscriptionTypeId");
        }

        public CatalogItem CatalogItem
        {
            get 
            {
                CatalogItem catalogItem = new CatalogItem
                {
                    CatalogItemId = GetGuid(_ordinalCatalogItemId),
                    ItemName = GetString(_ordinalItemName),
                    Manufacturer = GetString(_ordinalManufacturer),
                    NumberInscriptionLines = GetInt32(_ordinalNumberInscriptionLines),
                    NumberLineCharacters = GetInt32(_ordinalNumberLineCharacters),
                    ItemCost = GetDecimal(_ordinalItemCost),
                    ItemRetailPrice = GetDecimal(_ordinalItemRetailPrice),
                    InscriptionTypeId = GetInt32(_ordinalInscriptionTypeId)
                };

                return catalogItem;
            }
        }
    }
}

