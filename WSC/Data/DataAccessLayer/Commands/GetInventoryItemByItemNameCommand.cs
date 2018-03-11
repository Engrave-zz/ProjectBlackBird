using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetInventoryItemByItemNameCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _ItemName;
        private readonly SqlParameter _InventoryItemStatusId;

        public GetInventoryItemByItemNameCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetInventoryItemByItemNameCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblInventoryItemByItemName]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _ItemName = CreateParameter("itemName", SqlDbType.VarChar, ParameterDirection.Input);
            _InventoryItemStatusId = CreateParameter("inventoryItemStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_ItemName);
            sqlParameterCollection.Add(_InventoryItemStatusId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public string ItemName
        {
            get { return (string)_ItemName.Value; }
            set { _ItemName.Value = value; }
        }

        public int InventoryItemStatusId
        {
            get { return (int)_InventoryItemStatusId.Value; }
            set { _InventoryItemStatusId.Value = value; }
        }
    }
}
