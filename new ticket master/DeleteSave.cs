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



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (objEventToEdit == null)
            {
                MessageBox.Show("nothing to delete");
            }
            else
            {
                infoContext.DeleteObject(objEventToEdit);
                saveMeToDataBase();
            }
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (objPaymentToEdit == null)
            {
                MessageBox.Show("nothing to delete");
            }
            else
            {
                infoContext.DeleteObject(objPaymentToEdit);
                saveMeToDataBase();
            }
        }

        private void btnDelete_Click_2(object sender, RoutedEventArgs e)
        {
            if (objCeditToEdit == null)
            {
                MessageBox.Show("nothing to delete");
            }
            else
            {
                infoContext.DeleteObject(objCeditToEdit);
                saveMeToDataBase();
            }
        }



        private void saveMeToDataBase()
        {
            try
            {
                this.infoContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
              
                this.infoContext.Refresh(RefreshMode.ClientWins, infoContext.Users);
                this.infoContext.Refresh(RefreshMode.ClientWins, infoContext.PaymentInfoes);
                this.infoContext.Refresh(RefreshMode.ClientWins, infoContext.Events);
                this.infoContext.Refresh(RefreshMode.ClientWins, infoContext.CreditCardInfoes); 
                this.infoContext.SaveChanges();
            }
            catch (UpdateException uEx)
            {
              
               
                this.infoContext.Refresh(RefreshMode.StoreWins, getev);
                this.infoContext.Refresh(RefreshMode.StoreWins, getpay);
                //this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.Events); 
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.CreditCardInfoes);
                MessageBox.Show(uEx.InnerException.Message, "Error Saving changes");
            }
            catch (Exception ex)
            {
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.PaymentInfoes);
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.Events);
                this.infoContext.Refresh(RefreshMode.StoreWins, infoContext.CreditCardInfoes); 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
