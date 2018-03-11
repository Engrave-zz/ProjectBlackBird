using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Commands;
using DataAccessLayer.Readers;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class AddressData
    {
      public static int InsertAddress(Guid addressId, Guid personId, int streetNumber, string streetName, string addressCity,
                                    string addressState, string addressZip, int addressTypeId)
        {
            using (ObjectConnection objectConnection = new ObjectConnection())
            {
                using (InsertAddressCommand objectCommand = new InsertAddressCommand(objectConnection))
                {
                    objectCommand.AddressId = addressId;
                    objectCommand.PersonId = personId;
                    objectCommand.StreetNumber = streetNumber;
                    objectCommand.StreetName = streetName;
                    objectCommand.AddressCity = addressCity;
                    objectCommand.AddressState = addressState;
                    objectCommand.AddressZip = addressZip;
                    objectCommand.AddressTypeId = addressTypeId;

                    objectConnection.Open();
                    objectCommand.ExecuteNonQuery();

                    return objectCommand.ReturnValue;
                }
            }
        }

      public static int UpdateByAddressId(Address address)
      {
          using (ObjectConnection objectConnection = new ObjectConnection())
          {
              using (UpdateAddressByAddressIdCommand objectCommand = new UpdateAddressByAddressIdCommand(objectConnection))
              {
                  objectCommand.AddressId = address.AddressId;
                  objectCommand.PersonId = address.PersonId;
                  objectCommand.StreetNumber = address.StreetNumber;
                  objectCommand.StreetName = address.StreetName;
                  objectCommand.AddressCity = address.AddressCity;
                  objectCommand.AddressState = address.AddressState;
                  objectCommand.AddressZip = address.AddressZip;
                  objectCommand.AddressTypeId = address.AddressTypeId;

                  objectConnection.Open();
                  objectCommand.ExecuteNonQuery();

                  return objectCommand.ReturnValue;
              }
          }
      }

      public static List<Address> GetAddressByPersonId(Guid personId)
      {
          List<Address> addressList = new List<Address>();

          using (ObjectConnection objectConnection = new ObjectConnection())
          {
              using (GetAddressByPersonIdCommand objectCommand = new GetAddressByPersonIdCommand(objectConnection))
              {
                  objectCommand.PersonId = personId;

                  objectConnection.Open();
                  using (SqlDataReader sqlDataReader = objectCommand.ExecuteReader())
                  {
                      if (!sqlDataReader.HasRows)
                      {
                          return addressList;
                      }

                      using (AddressSqlDataReader objectSqlDataReader = new AddressSqlDataReader(sqlDataReader))
                      {
                          while (objectSqlDataReader.Read())
                          {
                              Address address = objectSqlDataReader.Address;
                              addressList.Add(address);
                          }
                      }
                  }
              }
          }
          return addressList;
      }
    }
}
