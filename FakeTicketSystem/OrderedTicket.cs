using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// this is needed for the conversion class
using System.Windows.Data;

namespace FakeTicketSystem
{
    enum PrivilegeLevel 
    {
        // used to specify the level of privilege in the ordered ticket class
        Standard, Premium, Executive, delux
    }
   
    class OrderedTicket
    {
        // field stub
        private string eventName;
        private string customerReference;
        private PrivilegeLevel privilegedLevel;
        private short numberOfTickets;

        // properties

        public string EventName
        {
            get { return this.eventName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("specify an event");
                }
                else
                {
                    this.eventName = value;
                }
            }

        }

        public string CustomeReference 
        {
            get { return this.customerReference; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("reference number needed");

                }

                else
                {
                    this.customerReference = value;
                }
            }
        }

        public PrivilegeLevel PrivilegeLevel
        {
            get { return this.privilegedLevel; }

            set
            {
                this.privilegedLevel = value;
                if (!this.checkPrivilegeAndTickets(value, this.numberOfTickets))
                {
                    throw new ApplicationException("Privilege level is too low");
                }
            }
        }

        /// <summary>
        /// gets the slider value
        /// </summary>
        public short NumberOfTickets 
        {
            get { return this.numberOfTickets; }

            set
            {
                this.numberOfTickets = value;

                if (!this.checkPrivilegeAndTickets(this.privilegedLevel, value))
                {
                    throw new ApplicationException("too many tickets for this privilege level");
                }

                if (this.numberOfTickets <= 0)
                {
                    throw new ApplicationException("you must buy at least one ticket to use this app");
                }

            }
        }

        // methods
        /// <summary>
        /// checks to see if the number of tickets exceeds privileged level
        /// </summary>
        /// <param name="proposedLevel"> what  privilege do they hold</param>
        /// <param name="proposedNumberTickets"> number of tickets</param>
        /// <returns></returns>
        private bool checkPrivilegeAndTickets(PrivilegeLevel proposedLevel, short proposedNumberTickets)
        {
            bool retVal = false;

            switch (proposedLevel)
            {
                case PrivilegeLevel.Standard:
                    retVal =(proposedNumberTickets <= 2);
                    break;
                
                case PrivilegeLevel.Premium:
                    retVal = (proposedNumberTickets <= 4);
                    break;

                case PrivilegeLevel.Executive:
                    retVal = (proposedNumberTickets <= 8);
                    break;

                case PrivilegeLevel.delux:
                    retVal = (proposedNumberTickets <= 10);
                    break;
            }

            return retVal;
        }

        public override string ToString()
        {
            string derString = string.Format("Event {0}\tCustomer {1} \tPrivilege{2} \tTickets{3}", this.eventName, this.customerReference, this.privilegedLevel.ToString(), this.numberOfTickets.ToString());
            return derString;
        }
    }

    //converter class attribute
    [ValueConversion(typeof(string), typeof(PrivilegeLevel))]

    public class PrivilegeLevelConverter : IValueConverter
    {

        /// <summary>
        /// the signiture of the convert method are defined by the ivalue converter interface
        /// object to wpf form
        /// </summary>
        /// <param name="value">the value of the class that you are converting from</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PrivilegeLevel privilegeLevel = (PrivilegeLevel)value;
            string convertedPrivilegeLevel = String.Empty;

            switch (privilegeLevel)
            {
                case PrivilegeLevel.Standard:
                    convertedPrivilegeLevel = "Standard";
                    break;
                case PrivilegeLevel.Executive:
                    convertedPrivilegeLevel = "Executive";
                        break;
                case PrivilegeLevel.Premium:
                        convertedPrivilegeLevel = "Premium";
                        break;
                case PrivilegeLevel.delux:
                        convertedPrivilegeLevel = "delux";
                        break;
            }
            return convertedPrivilegeLevel;
        }
        /// <summary>
        /// wpf to object
        /// </summary>
        /// <param name="value">the value of the wpf form you are converting from</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PrivilegeLevel privilegeLevel = PrivilegeLevel.Standard;

            switch ((string)value)
            { 
                case "Standard":
                    privilegeLevel = PrivilegeLevel.Standard;
                    break;
                case "Executive":
                    privilegeLevel = PrivilegeLevel.Executive;
                    break;
                case "delux":
                    privilegeLevel = PrivilegeLevel.delux;
                    break;
                case "Premium":
                    privilegeLevel = PrivilegeLevel.Premium;
                    break;
            }
            return privilegeLevel;
        }
    }
}
