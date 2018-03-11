// Date created 5/29/14
// Author: Adam Fike
// Description: This class represents a Customer object - and inherits information from the Person class.  
// A Customer is defined as someone who makes purchases from WSC printing and engraving.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class Customer : Person
    {
        // class variables, getters & setters
        internal Guid _customerId;
        public Guid CustomerId { get { return _customerId; } set { _customerId = value; } }

        public new PersonType PersonType { get { return base.PersonType; } set { base.PersonType = value; } }

        private Address _mailingAddress;
        public Address MailingAddress { get { return _mailingAddress; } set { _mailingAddress = value; } }

        private Address _billingAddress;
        public Address BillingAddress { get { return _billingAddress; } set { _billingAddress = value; } }

        // Customer constructor - Null
        public Customer() : base()
        {
            _customerId = Guid.NewGuid();
            base.PersonType = Enumerations.PersonType.Customer;
        }

        public Customer(Guid personId, Guid customerId)
            : base(personId)
        {
            _customerId = customerId;
        }

        // constructor for NEW Customer - This constructor creates a GUID for the new Customer
        public Customer(string firstName, string lastName, string phoneNumber, string emailAddress,
                        Address mailingAddress, Address billingAddress)
            : base(firstName, lastName, phoneNumber, emailAddress)
        {
            _customerId = Guid.NewGuid();
            _mailingAddress = mailingAddress;
            _billingAddress = billingAddress;
            base.PersonType = Enumerations.PersonType.Customer;
        }

        // constructor for loading an EXISTING Customer - This constructor DOES NOT create a new GUID
        public Customer(Guid personId, string firstName, string lastName, string phoneNumber, string emailAddress,
                        Guid customerId, Address mailingAddress, Address billingAddress)
            : base(personId, firstName, lastName, phoneNumber, emailAddress)
        {
            _customerId = customerId;
            _mailingAddress = mailingAddress;
            _billingAddress = billingAddress;
            base.PersonType = Enumerations.PersonType.Customer;
        } 


    }
}
