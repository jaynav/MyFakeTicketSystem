using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace new_ticket_master
{
    class EventValidator
    {
          private string eventNerm;
        private string eventCorst;

      
        public string EventNameer
        {
            get
            {
                return this.eventNerm;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter Data");
                }
                else if (validateAgainst.numbers(value) != true)
                {
                    throw new ApplicationException("Event name may not contain numbers");
                }
                else
                {
                    this.eventNerm = value;
                }
            }
        }
        public string EventCoster
        {
            get
            {
                return this.eventCorst;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("please enter something");
                }
                else if (validateAgainst.letters(value) != true)
                {
                    throw new ApplicationException("Event cost may not contain letters");
                }
                else
                {
                    this.eventCorst = value;
                }
            }
        }
    }
}
