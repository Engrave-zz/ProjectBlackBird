// Date created 5/29/14
// Author: Adam Fike
// Description: This class represents an Employee object - and inherits information from the Person class.  
// An Employee is defined as someone who works at WSC printing and engraving.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Enumerations;

namespace BusinessLayer
{
    public class Employee : Person
    {
        // class variables, getters & setters
        internal Guid _employeeId;
        public Guid EmployeeId { get { return _employeeId; } set { _employeeId = value; } }

        public new PersonType PersonType { get { return base.PersonType; } }

        internal UserAccount _user;
        public UserAccount UserAccount { get { return _user; } set { _user = value; } }

        // constructor with zero arguments - Null
        public Employee() : base()
        {
            _employeeId = new Guid();
        }

        // constructor for NEW Employee - This constructor creates a GUID for the new Employee
        public Employee(string firstName, string lastName, string phoneNumber, string emailAddress,
                        UserAccount user)
            : base(firstName, lastName, phoneNumber, emailAddress)
        {
            _employeeId = Guid.NewGuid();
            _user = user;
            base.PersonType = Enumerations.PersonType.Employee;
        }

        // standard constructor
        public Employee(Guid personId, string firstName, string lastName, string phoneNumber, string emailAddress,
                        Guid employeeId, UserAccount user)
            : base(personId, firstName, lastName, phoneNumber, emailAddress)
        {
            _employeeId = employeeId;
            _user = user;
            base.PersonType = Enumerations.PersonType.Employee;
        }

        public string DeleteEmployee(Employee employee)
        {
            //add code for employee deletion
            return "Employee has been deleted";
        }
    }
}
