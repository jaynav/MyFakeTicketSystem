using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace new_ticket_master
{
    class UserValidator
    {
        string firstName;
        string lastName;
        string streetAddress;
        string city;
        string state;
        string zipCode;
        string phoneNumber;

        public string FirstName
        { 
            get
            {
                return this.firstName;
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                       throw new ApplicationException("please enter data");
                }
                else if(validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("No numbers in first name");
                }
                else
                {
                    this.firstName = value; 
                }
            }
        }
        public string LastName 
        {
            get 
            {
                return this.lastName;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("no numbers in last name");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        public string StreetAddress
        {
            get 
            {
                return this.streetAddress;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                       throw new ApplicationException("please enter data");
                }
                else
                {
                    this.streetAddress = value;
                }
            }
        }
        public string City 
        { 
            get 
            {
                return this.city;
            } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("city may not contain numbers");
                }
                else
                { 
                    this.city = value;
                }
                
            }
        }
        public string State 
        {
            get
            {
                return this.state;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("states do not contain numbers");
                }
                else
                {
                    this.state = value;
                }
            }
        }
        public string ZipCode 
        {
            get
            {
                return this.zipCode;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("Zip code may not contain letters");
                }
                else
                {
                    this.zipCode = value;
                }
            } 
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("phone number must not contain letters");
                }
                else
                {
                    this.phoneNumber = value;
                }

            }
        }
    }
}
