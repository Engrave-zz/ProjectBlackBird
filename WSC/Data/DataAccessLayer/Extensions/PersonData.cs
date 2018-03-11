using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class PersonData
    {
        public static Person GetByPersonId(Guid personId)
        {
            Person person = new Person();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetPersonByPersonIdCommand objectCommand = new GetPersonByPersonIdCommand(objectConnection))
                {
                    objectCommand.PersonId = personId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return person;
                        }

                        using (PersonSqlDataReader objectSqlDataReader = new PersonSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                person = objectSqlDataReader.Person;
                            }
                        }
                    }
                }
            }

            return person;
        }

        public static List<Person> GetByUserId(Guid userId)
        {
            List<Person> personList = new List<Person>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetPersonByUserIdCommand objectCommand = new GetPersonByUserIdCommand(objectConnection))
                {
                    objectCommand.UserId = userId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return personList;
                        }

                        using (PersonSqlDataReader objectSqlDataReader = new PersonSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Person person = objectSqlDataReader.Person;
                                personList.Add(person);
                            }
                        }
                    }
                }
            }

            return personList;
        }

        public static int Insert(Guid? personId, string firstName, string lastName, string phone, string email, int personTypeId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertPersonCommand objectCommand = new InsertPersonCommand(objectConnection))
                {
                    objectCommand.PersonId = personId ?? new Guid();
                    objectCommand.PersonFirstName = firstName;
                    objectCommand.PersonLastName = lastName;
                    objectCommand.PersonPhone = phone;
                    objectCommand.PersonEmail = email;
                    objectCommand.PersonTypeId = personTypeId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int Insert(Person person)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertPersonCommand objectCommand = new InsertPersonCommand(objectConnection))
                {
                    objectCommand.PersonId = (person.PersonId != Guid.Empty) ? person.PersonId : new Guid();
                    objectCommand.PersonFirstName = person.PersonFirstName;
                    objectCommand.PersonLastName = person.PersonLastName;
                    objectCommand.PersonPhone = person.PersonPhone;
                    objectCommand.PersonEmail = person.PersonEmail;
                    objectCommand.PersonTypeId = person.PersonTypeId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByPersonId(Guid personId, string firstName, string lastName, string phone, string email, int personTypeId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdatePersonByPersonIdCommand objectCommand = new UpdatePersonByPersonIdCommand(objectConnection))
                {
                    objectCommand.PersonId = personId;
                    objectCommand.PersonFirstName = firstName;
                    objectCommand.PersonLastName = lastName;
                    objectCommand.PersonPhone = phone;
                    objectCommand.PersonEmail = email;
                    objectCommand.PersonTypeId = personTypeId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static int UpdateByPersonId(Person person)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (UpdatePersonByPersonIdCommand objectCommand = new UpdatePersonByPersonIdCommand(objectConnection))
                {
                    objectCommand.PersonId = person.PersonId;
                    objectCommand.PersonFirstName = person.PersonFirstName;
                    objectCommand.PersonLastName = person.PersonLastName;
                    objectCommand.PersonPhone = person.PersonPhone;
                    objectCommand.PersonEmail = person.PersonEmail;
                    objectCommand.PersonTypeId = person.PersonTypeId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }
    }
}
