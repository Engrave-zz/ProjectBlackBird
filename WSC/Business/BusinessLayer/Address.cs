// Date created 5/30/14
// Author: Adam Fike
// Description: This class represents an Address object.  An Address belongs to a Customer.  A Customer can have a Billing
// Address and a Mailing Address

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class Address
    {
        // class variables, getters & setters
        internal Guid _addressId;
        public Guid AddressId { get { return _addressId; } set { _addressId = value; } }

        internal Guid _personId;
        public Guid PersonId { get { return _personId; } set { _personId = value; } }
        
        private int _streetNumber;
        public int StreetNumber { get { return _streetNumber; } set { _streetNumber = value; } }

        private string _streetName;
        public string StreetName { get { return _streetName; } set { _streetName = value; } }

        private string _addressCity;
        public string AddressCity { get { return _addressCity; } set { _addressCity = value; } }

        private string _addressState;
        public string AddressState { get { return _addressState; } set { _addressState = value; } }

        private string _addressZip;
        public string AddressZip { get { return _addressZip; } set { _addressZip = value; } }

        private AddressType _addressType;
        public AddressType AddressType { get { return _addressType; } set { _addressType = value; } }

        // Address constructor - Null
        public Address()
        {
            _addressId = Guid.NewGuid();
        }

        // constructor for NEW Address - This constructor creates a GUID for the new Address
        public Address(Guid personId, int streetNumber, string streetName, string addressCity, string addressState, string addressZip, 
                       AddressType addressType)     
        {
            _addressId = Guid.NewGuid();
            _personId = personId;
            _streetNumber = streetNumber;
            _streetName = streetName;
            _addressCity = addressCity;
            _addressState = addressState;
            _addressZip = addressZip;
            _addressType = addressType;
        }

        // constructor for loading an EXISTING Address - This constructor DOES NOT create a new GUID
        public Address(Guid addressId, Guid personId, int streetNumber, string streetName, string addressCity, string addressState, string addressZip,
                       AddressType addressType)
        {
            _addressId = addressId;
            _personId = personId;
            _streetNumber = streetNumber;
            _streetName = streetName;
            _addressCity = addressCity;
            _addressState = addressState;
            _addressZip = addressZip;
            _addressType = addressType;
        } 

        public string DeleteAddress(Address address)
        {
            //Add code here to delete address
            return "Address has been deleted";
        }
    }
}


