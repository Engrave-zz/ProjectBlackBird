using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetInventoryItemByInventoryItemIdAndInventoryItemStatusIdCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _inventoryItemId;
        private readonly SqlParameter _InventoryItemStatusId;

        public GetInventoryItemByInventoryItemIdAndInventoryItemStatusIdCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetInventoryItemByInventoryItemIdAndInventoryItemStatusIdCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblInventoryItemByInventoryItemIdAndInventoryItemStatusId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _inventoryItemId = CreateParameter("inventoryItemId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _InventoryItemStatusId = CreateParameter("inventoryItemStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_inventoryItemId);
            sqlParameterCollection.Add(_InventoryItemStatusId);
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

        public int InventoryItemStatusId
        {
            get { return (int)_InventoryItemStatusId.Value; }
            set { _InventoryItemStatusId.Value = value; }
        }
    }
}
