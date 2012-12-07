using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace new_ticket_master
{
    class PaymentValidator
    {
        // properties

        private string paymentMetherd;
        private string purchaseDert;
       

       


        // these statements just check to see if they are empty
        public string PaymentMetherd
        {
            get
            {
                return this.paymentMetherd;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Please enter Data");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("May not contain number");
                }

                else
                {
                    this.paymentMetherd = value;
                }
            }
        }

        public string PurchaseDert
        {
            get 
            { 
                return this.purchaseDert;
            }

            set 
            {
               
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter data");
                }
                    //checks to see if value is equal. if it is, it passes data through, if not it throws an error
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("the date may not contain letters");
                }
                else
                {
                    this.purchaseDert = value;
                }
            }
        }



    }
}
