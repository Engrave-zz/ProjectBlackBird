using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class AddressSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalAddressId;
        private readonly int _ordinalPersonId;
        private readonly int _ordinalStreetNumber;
        private readonly int _ordinalStreetName;
        private readonly int _ordinalAddressCity;
        private readonly int _ordinalAddressState;
        private readonly int _ordinalAddressZip;
        private readonly int _ordinalAddressTypeId;

        public AddressSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public AddressSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public AddressSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalAddressId = GetOrdinal("addressId");
            _ordinalPersonId = GetOrdinal("personId");
            _ordinalStreetNumber = GetOrdinal("streetNumber");
            _ordinalStreetName = GetOrdinal("streetName");
            _ordinalAddressCity = GetOrdinal("addressCity");
            _ordinalAddressState = GetOrdinal("addressState");
            _ordinalAddressZip = GetOrdinal("addressZip");
            _ordinalAddressTypeId = GetOrdinal("addressTypeId");
        }

        public Address Address
        {
            get 
            {
                Address address = new Address
                {
                    AddressId = GetGuid(_ordinalAddressId),
                    PersonId = GetGuid(_ordinalPersonId),
                    StreetNumber = GetInt32(_ordinalStreetNumber),
                    StreetName = GetString(_ordinalStreetName),
                    AddressCity = GetString(_ordinalAddressCity),
                    AddressState = GetString(_ordinalAddressState),
                    AddressZip = GetString(_ordinalAddressZip),
                    AddressTypeId = GetInt32(_ordinalAddressTypeId)
                };

                return address;
            }
        }
    }
}

