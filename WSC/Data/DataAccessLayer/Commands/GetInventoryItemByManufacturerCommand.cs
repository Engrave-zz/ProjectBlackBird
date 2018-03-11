using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class GetInventoryItemByManufacturerCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _manufacturer;
        private readonly SqlParameter _InventoryItemStatusId;

        public GetInventoryItemByManufacturerCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public GetInventoryItemByManufacturerCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spGettblInventoryItemByManufacturer]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _manufacturer = CreateParameter("manufacturer", SqlDbType.VarChar, ParameterDirection.Input);
            _InventoryItemStatusId = CreateParameter("inventoryItemStatusId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_manufacturer);
            sqlParameterCollection.Add(_InventoryItemStatusId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public string Manufacturer
        {
            get { return (string)_manufacturer.Value; }
            set { _manufacturer.Value = value; }
        }

        public int InventoryItemStatusId
        {
            get { return (int)_InventoryItemStatusId.Value; }
            set { _InventoryItemStatusId.Value = value; }
        }
    }
}
