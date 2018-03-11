using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetOrderByInventoryItemId : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _inventoryItemId;

        public GetOrderByInventoryItemId(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetOrderByInventoryItemId(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblOrderByInventoryItemId]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _inventoryItemId = CreateParameter("inventoryItemId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_inventoryItemId);
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
    }
}
