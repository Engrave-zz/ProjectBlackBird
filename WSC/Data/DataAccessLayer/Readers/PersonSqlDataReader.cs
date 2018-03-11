using System;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Readers
{
    public class PersonSqlDataReader : ObjectSqlDataReader
    {
        private readonly int _ordinalPersonId;
        private readonly int _ordinalPersonFirstName;
        private readonly int _ordinalPersonLastName;
        private readonly int _ordinalPersonPhone;
        private readonly int _ordinalPersonEmail;
        private readonly int _ordinalPersonTypeId;

        public PersonSqlDataReader(ObjectCommand objectCommand)
            : this(objectCommand.ExecuteReader())
        {
        }

        public PersonSqlDataReader(SqlCommand sqlCommand)
            : this(sqlCommand.ExecuteReader())
        {
        }

        public PersonSqlDataReader(SqlDataReader sqlDataReader)
            : base(sqlDataReader)
        {
            _ordinalPersonId = GetOrdinal("personId");
            _ordinalPersonFirstName = GetOrdinal("personFirstName");
            _ordinalPersonLastName = GetOrdinal("personLastName");
            _ordinalPersonPhone = GetOrdinal("personPhone");
            _ordinalPersonEmail = GetOrdinal("personEmail");
            _ordinalPersonTypeId = GetOrdinal("personTypeId");
        }

        public Person Person
        {
            get 
            {
                Person person = new Person
                {
                    PersonId = GetGuid(_ordinalPersonId),
                    PersonFirstName = GetString(_ordinalPersonFirstName),
                    PersonLastName = GetString(_ordinalPersonLastName),
                    PersonPhone = GetString(_ordinalPersonPhone),
                    PersonEmail = GetString(_ordinalPersonEmail),
                    PersonTypeId = GetInt32(_ordinalPersonTypeId)
                };

                return person;
            }
        }
    }
}

