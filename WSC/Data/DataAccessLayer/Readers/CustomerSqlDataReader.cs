using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class CustomerSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalCustomerId;
        private readonly int _ordinalPersonId;

        public CustomerSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public CustomerSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public CustomerSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalCustomerId = GetOrdinal("customerId");
            _ordinalPersonId = GetOrdinal("personId");
        }

        public Customer Customer
        {
            get
            {
                Customer customer = new Customer
                {
                    CustomerId = GetGuid(_ordinalCustomerId),
                    PersonId = GetGuid(_ordinalPersonId),
                };

                return customer;
            }
        }
    }
}

