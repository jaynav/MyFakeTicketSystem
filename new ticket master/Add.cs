using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Data;
using System.Data.Objects;
using System.Windows;
using System.ComponentModel;

namespace new_ticket_master
{
    partial class ShowUserDetail
    {

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentStatus p = new PaymentStatus();

            if (p.ShowDialog().Value)
            {
               PaymentInfo objPaymentToEdit1 = new PaymentInfo();
                objPaymentToEdit1.UserID = userId;
                objPaymentToEdit1.PaymentMethod = p.tickPay.Text;
                objPaymentToEdit1.PurchaseDate = DateTime.Parse(p.tickPur.Text);

                infoContext.PaymentInfoes.AddObject(objPaymentToEdit1);
                saveMeToDataBase();
                fetchUserData(infoContext);
               
            }
        }

        private void AddEventInfo_Click(object sender, RoutedEventArgs e)
        {
            EventInfo p = new EventInfo();

            if (p.ShowDialog().Value)
            {
                Event AddEvent = new Event();
                AddEvent.EventName = p.EName.Text;
                AddEvent.EventCost = Decimal.Parse(p.ECost.Text);
                AddEvent.UserID = userId;
                infoContext.Events.AddObject(AddEvent);
                saveMeToDataBase();
                fetchUserData(infoContext);
            }

        }
        private void AddCCInfo_Click(object sender, RoutedEventArgs e)
        {
            CardInfo p = new CardInfo();

            if (p.ShowDialog().Value)
            {
                CreditCardInfo cc = new CreditCardInfo();
                
                cc.AccountNumber = int.Parse(p.aNum.Text);
                cc.ExpirationDate = DateTime.Parse(p.eXp.Text);
                cc.SecurityKey = p.secK.Text;
                cc.UserFirstName = p.uFN.Text;
                cc.UserLastName = p.uLN.Text;
                cc.City = p.city.Text;
                cc.State = p.state.Text;
                cc.ZipCode = p.zip.Text;
                cc.UserID = userId;
                
                infoContext.CreditCardInfoes.AddObject(cc);
                saveMeToDataBase();
                fetchUserData(infoContext);
            }


        }
              

    }
}
