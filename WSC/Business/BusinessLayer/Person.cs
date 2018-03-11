// Date created 5/29/14
// Author: Adam Fike
// Description: This class represents a person object.  A person is a "parent object" for customers and employees

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class Person
    {
        // class variables, getters & setters
        internal Guid _personId;
        public Guid PersonId { get { return _personId; } set { _personId = value; } }

        protected string _firstName;
        public string FirstName { get { return _firstName; } set { _firstName = value; } }

        protected string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        protected string _phoneNumber;
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        protected string _emailAddress;
        public string EmailAddress { get { return _emailAddress; } set { _emailAddress = value; } }

        protected PersonType _personType;
        public PersonType PersonType { get { return _personType; } set { _personType = value; } }

        // constructor with zero arguments
        public Person()
        {
            _personId = Guid.NewGuid();
        }

        public Person(Guid personId)
        {
            _personId = personId;
        }

        // constructor for NEW customer - This constructor creates a GUID for the new user
        public Person(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            _personId = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        }

        // constructor for loading an EXISTING customer - This constructor DOES NOT create a new GUID
        public Person(Guid personId, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            _personId = personId;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        }
    }
}
