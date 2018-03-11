using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Commands
{
    public class InsertAddressCommand : ObjectCommand
    {
        private readonly SqlParameter _returnValue;
        private readonly SqlParameter _addressId;
        private readonly SqlParameter _personId;
        private readonly SqlParameter _streetNumber;
        private readonly SqlParameter _streetName;
        private readonly SqlParameter _addressCity;
        private readonly SqlParameter _addressState;
        private readonly SqlParameter _addressZip;
        private readonly SqlParameter _addressTypeId;

        public InsertAddressCommand(ObjectConnection objectConnection)
            : this(objectConnection.CreateCommand())
        {
        }

        public InsertAddressCommand(SqlCommand sqlCommand)
            : base(sqlCommand)
        {
            Command.CommandText = "[dbo].[spInserttblAddress]";
            Command.CommandType = CommandType.StoredProcedure;

            _returnValue = CreateParameter("RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue);
            _addressId = CreateParameter("addressId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _personId = CreateParameter("personId", SqlDbType.UniqueIdentifier, ParameterDirection.Input);
            _streetNumber = CreateParameter("streetNumber", SqlDbType.Int, ParameterDirection.Input);
            _streetName = CreateParameter("streetName", SqlDbType.VarChar, ParameterDirection.Input);
            _addressCity = CreateParameter("addressCity", SqlDbType.VarChar, ParameterDirection.Input);
            _addressState = CreateParameter("addressState", SqlDbType.VarChar, ParameterDirection.Input);
            _addressZip = CreateParameter("addressZip", SqlDbType.VarChar, ParameterDirection.Input);
            _addressTypeId = CreateParameter("addressTypeId", SqlDbType.Int, ParameterDirection.Input);

            SqlParameterCollection sqlParameterCollection = sqlCommand.Parameters;
            sqlParameterCollection.Add(_returnValue);
            sqlParameterCollection.Add(_addressId);
            sqlParameterCollection.Add(_personId);
            sqlParameterCollection.Add(_streetNumber);
            sqlParameterCollection.Add(_streetName);
            sqlParameterCollection.Add(_addressCity);
            sqlParameterCollection.Add(_addressState);
            sqlParameterCollection.Add(_addressZip);
            sqlParameterCollection.Add(_addressTypeId);
        }

        public int ReturnValue
        {
            get { return (int)_returnValue.Value; }
            set { _returnValue.Value = value; }
        }

        public Guid AddressId
        {
            get { return (Guid)_addressId.Value; }
            set { _addressId.Value = value; }
        }

        public Guid PersonId
        {
            get { return (Guid)_personId.Value; }
            set { _personId.Value = value; }
        }

        public int StreetNumber
        {
            get { return (int)_streetNumber.Value; }
            set { _streetNumber.Value = value; }
        }

        public string StreetName
        {
            get { return (string)_streetName.Value; }
            set { _streetName.Value = value; }
        }

        public string AddressCity
        {
            get { return (string)_addressCity.Value; }
            set { _addressCity.Value = value; }
        }

        public string AddressState
        {
            get { return (string)_addressState.Value; }
            set { _addressState.Value = value; }
        }

        public string AddressZip
        {
            get { return (string)_addressZip.Value; }
            set { _addressZip.Value = value; }
        }

        public int AddressTypeId
        {
            get { return (int)_addressTypeId.Value; }
            set { _addressTypeId.Value = value; }
        }
    }
}

