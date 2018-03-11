using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class CustomerData
    {         

        public static int InsertCustomer(Guid customerId, Guid personId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertCustomerCommand objectCommand = new InsertCustomerCommand(objectConnection))
                {
                    objectCommand.CustomerId = customerId;
                    objectCommand.PersonId = personId;


                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

        public static List<Customer> GetCustomerByPersonLastName(string personLastName)
        {
            List<Customer> customerList = new List<Customer>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByLastNameCommand objectCommand = new GetCustomerByLastNameCommand(objectConnection))
                {
                    objectCommand.PersonLastName = personLastName;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customerList;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Customer customer = objectSqlDataReader.Customer;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }

            return customerList;
        }

        public static List<Customer> GetCustomerByPersonFirstName(string personFirstName)
        {
            List<Customer> customerList = new List<Customer>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByFirstNameCommand objectCommand = new GetCustomerByFirstNameCommand(objectConnection))
                {
                    objectCommand.PersonFirstName = personFirstName;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customerList;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Customer customer = objectSqlDataReader.Customer;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }

            return customerList;
        }

        public static List<Customer> GetCustomerByPersonEmail(string personEmail)
        {
            List<Customer> customerList = new List<Customer>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByPersonEmailCommand objectCommand = new GetCustomerByPersonEmailCommand(objectConnection))
                {
                    objectCommand.PersonEmail = personEmail;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customerList;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Customer customer = objectSqlDataReader.Customer;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }

            return customerList;
        }

        public static List<Customer> GetCustomerByPersonPhone(string personPhone)
        {
            List<Customer> customerList = new List<Customer>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByPhoneCommand objectCommand = new GetCustomerByPhoneCommand(objectConnection))
                {
                    objectCommand.PersonPhone = personPhone;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customerList;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Customer customer = objectSqlDataReader.Customer;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }

            return customerList;
        }

        public static List<Customer> GetCustomerByCustomerId(Guid customerId)
        {
            List<Customer> customerList = new List<Customer>();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByCustomerIdCommand objectCommand = new GetCustomerByCustomerIdCommand(objectConnection))
                {
                    objectCommand.CustomerId = customerId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customerList;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                Customer customer = objectSqlDataReader.Customer;
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }

            return customerList;
        }

        public static Customer GetCustomerByPersonId(Guid personId)
        {
            Customer customer = new Customer();

            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (GetCustomerByPersonIdCommand objectCommand = new GetCustomerByPersonIdCommand(objectConnection))
                {
                    objectCommand.PersonId = personId;

                    objectConnection.Open();
                    using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                    {
                        if (!sqlDataReader.HasRows)
                        {
                            return customer;
                        }

                        using (CustomerSqlDataReader objectSqlDataReader = new CustomerSqlDataReader(sqlDataReader))
                        {
                            while (objectSqlDataReader.Read())
                            {
                                customer = objectSqlDataReader.Customer;                                
                            }
                        }
                    }
                }
            }

            return customer;
        }
    }     
}
