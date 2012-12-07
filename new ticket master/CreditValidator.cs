using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace new_ticket_master
{
    class CreditValidator
    {
        private string accountNumber;
        private string expirationDate;
        private string securityKey;
        private string firstName;
        private string lastName;
        private string city;
        private string state;
        private string zip;


        public string AccountNumber
        {
            get 
            { 
                return this.accountNumber;
            }
            set 
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ArgumentNullException("Account # code may not contain letters");
                   
                }
                else if (value.Length != 16)
                {
                    throw new ApplicationException("credit cards are 16 digits in length");
                }
                else
                {
                    this.accountNumber = value;
                }
            }
        }
        public string ExpirationDate
        {
            get
            { 
                return this.expirationDate;
            }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("please enter a value in this format MM/DD/YY");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("Expiration Date code may not contain letters");
                }
                else
                {
                    this.expirationDate = value;
                }
            }
        }
        public string SecurityKey
        {
            get 
            {
                return this.securityKey;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("security code may not contain letters");
                }
                else
                {
                    this.securityKey = value;
                }
            }
        }
        public string FirstName
        {
            get
            { 
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("first name may not contain numbers");
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("Last Name code may not contain numbers");
                }
                else
                {
                    this.lastName = value;
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("city code may not contain numbers");
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("state code may not contain numbers");
                }
                else
                {
                    this.state = value;
                }
            }
        }
        public string Zip
        {
            get 
            {
                return this.zip; 
            }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter a value");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("zip code may not contain letters");
                }
                else
                {
                    this.zip = value;
                }
            }
        }

    }
}
