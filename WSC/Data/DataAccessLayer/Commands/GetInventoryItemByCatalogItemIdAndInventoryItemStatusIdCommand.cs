using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetInventoryItemByCatalogItemIdAndInventoryItemStatusIdCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _catalogItemId;
        private readonly SqlParameter _InventoryItemStatusId;

        public GetInventoryItemByCatalogItemIdAndInventoryItemStatusIdCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetInventoryItemByCatalogItemIdAndInventoryItemStatusIdCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblInventoryItemByCatalogItemIdAndInventoryItemStatusId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _catalogItemId = CreateParameter("catalogItemId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _InventoryItemStatusId = CreateParameter("inventoryItemStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_catalogItemId);
            sqlParameterCollection.Add(_InventoryItemStatusId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid CatalogItemId
        {
            get { return (Guid)_catalogItemId.Value; }
            set { _catalogItemId.Value = value; }
        }

        public int InventoryItemStatusId
        {
            get { return (int)_InventoryItemStatusId.Value; }
            set { _InventoryItemStatusId.Value = value; }
        }
    }
}
