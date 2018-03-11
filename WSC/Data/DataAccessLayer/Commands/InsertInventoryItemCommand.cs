using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertInventoryItemCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _inventoryItemId;
        private readonly SqlParameter _catalogItemId;
        private readonly SqlParameter _orderId;
        private readonly SqlParameter _inventoryItemStatusId;

        public InsertInventoryItemCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertInventoryItemCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblInventoryItem]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _inventoryItemId = CreateParameter("inventoryItemId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _catalogItemId = CreateParameter("catalogItemId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _orderId = CreateParameter("orderId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _inventoryItemStatusId = CreateParameter("inventoryItemStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_inventoryItemId);
            sqlParameterCollection.Add(_catalogItemId);
            sqlParameterCollection.Add(_orderId);
            sqlParameterCollection.Add(_inventoryItemStatusId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid InventoryItemId
        {
            get { return (Guid)_inventoryItemId.Value; }
            set { _inventoryItemId.Value = value; }
        }

        public Guid CatalogItemId
        {
            get { return (Guid)_catalogItemId.Value; }
            set { _catalogItemId.Value = value; }
        }

        public Guid? OrderId
        {
            get { return (Guid?)_orderId.Value; }
            set { _orderId.Value = value; }
        }

        public int InventoryItemStatusId
        {
            get { return (int)_inventoryItemStatusId.Value; }
            set { _inventoryItemStatusId.Value = value; }
        }
    }
}

