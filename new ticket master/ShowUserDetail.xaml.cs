using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.Objects;
using System.Collections;
using System.ComponentModel;

namespace new_ticket_master
{
    /// <summary>
    /// Interaction logic for ShowUserDetail.xaml
    /// </summary>
    public partial class ShowUserDetail : Window
    {
        int userId;
        private bool isUpdateMode = false;
        TicketMastersEntities infoContext;
        Event objEventToEdit = null;
      
        PaymentInfo objPaymentToEdit = null;
        private CreditCardInfo objCeditToEdit;
       
        IQueryable<Event> getev;
        IQueryable<PaymentInfo> getpay;

        decimal? totalValue = 0;

        Event calculateMultipleSelection = null;
        public ShowUserDetail()
        {
            infoContext = new TicketMastersEntities();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userId = int.Parse(uId.Text);
            fetchUserData(infoContext);
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           // totalValue = 0;
          // note to self, i can not get selected items to work correctly as i want it to
            // i want to get the selected user items and calculate that. orignal method just gets the first value and
            // adds it x times.
           // for (var i = 0; i < dataGrid1.SelectedItems.Count; i++)
           // {
            //  var r= dataGrid1.SelectedItems.AsQueryable();
             // var t = dataGrid1.SelectedItems.IndexOf(i).ToString();
           //   MessageBox.Show(t);
             
                //var s= r as Event;

            //MessageBox.Show(s.EventCost.ToString());
                //calculateMultipleSelection = dataGrid1.SelectedItem as Event;
                 
           
        //        }
         
          //  Report_Final sendData = new Report_Final();
           
           //sendData.ShowDialog();

           // IList rs = dataGrid1.SelectedItems;
           


            PrintDialog sendToPrinter = new PrintDialog();
           
           
           Nullable<Boolean> printme = sendToPrinter.ShowDialog();
            
           if (printme == true)
           {
               //prints twice
               sendToPrinter.PrintVisual(dataGrid1, "User event history");
              
               sendToPrinter.PrintVisual(this, "total form");
           }

        }

        private void fetchUserData(TicketMastersEntities context)
        {
           getev = from p in infoContext.Events
                                       where p.UserID == userId
                                       select p;
           getpay = from p in infoContext.PaymentInfoes
                    where p.UserID == userId
                    select p;
            //dataGrid1.ItemsSource = infoContext.Events.Where(e => e.UserID == userId);
           //dataGrid2.ItemsSource = infoContext.PaymentInfoes.Where(e => e.UserID == userId);
            dataGrid1.ItemsSource = getev;
            dataGrid2.ItemsSource = getpay;
            dataGrid3.ItemsSource = infoContext.CreditCardInfoes.Where(e => e.UserID == userId);
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEventToEdit = dataGrid1.SelectedItem as Event;
        }
        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objPaymentToEdit = dataGrid2.SelectedItem as PaymentInfo;
        }
        private void dataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objCeditToEdit = dataGrid3.SelectedItem as CreditCardInfo;
        }
     
        private void dataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           
            isUpdateMode = true;
            if (isUpdateMode)
            {
                Event evData = (from emp in infoContext.Events
                                where emp.EventId == objEventToEdit.EventId
                                select emp).First();

                //event name is [1]//event cost is column 2
                FrameworkElement ele1 = dataGrid1.Columns[1].GetCellContent(e.Row);
                if (ele1.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele1).Text;
                    objEventToEdit.EventName = dereventName;
                }
                FrameworkElement ele2 = dataGrid1.Columns[2].GetCellContent(e.Row);
                if (ele2.GetType() == typeof(TextBox))
                {
                    var derEventCost = ((TextBox)ele2).Text;
                    // objEventToEdit.EventCost = Convert.ToDecimal(derEventCost);
                    objEventToEdit.EventCost = decimal.Parse(derEventCost);
                }

            }
            else
            {
                MessageBox.Show("is updatemode was not set to true. was not saved to database");
            }
        ///This code first searches the selected Employee row using 
            ///LINQ. After the row is found, the update operation is 
            ///performed on it. In DataGrid, every Cell is in the form of
            ///TextBlock FrameworkElement type when it is not editable. 
            ///So to read the edited cell value, you need to read the Cell
            ///contents using ‘GetCellContent()’ method, by passing the DataGridRow 
            ///object to it. Once the FrameworkElement is extracted, by type casting 
            ///it to the ‘TextBox’ UI element, the value changed in the cell can be read. 
            ///Here ‘Salary’ and ‘DeptNo’ are changed and updated into the selected 
            ///‘Employee’ object.
 }
        private void dataGrid2_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            isUpdateMode = true;
            if (isUpdateMode)
            {
                PaymentInfo evPay = (from emp in infoContext.PaymentInfoes
                                     where emp.TicketNumber == objPaymentToEdit.TicketNumber
                                     select emp).First();

                //payment is [1]//purchaseDate is column 2
                FrameworkElement ele1 = dataGrid2.Columns[1].GetCellContent(e.Row);
                if (ele1.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele1).Text;
                    objPaymentToEdit.PaymentMethod = dereventName;
                }
                FrameworkElement ele2 = dataGrid2.Columns[2].GetCellContent(e.Row);
                if (ele2.GetType() == typeof(TextBox))
                {
                    var derEventCost = ((TextBox)ele2).Text;
                    // objEventToEdit.EventCost = Convert.ToDecimal(derEventCost);
                    objPaymentToEdit.PurchaseDate = DateTime.Parse(derEventCost);
                }

            }
            else
            {
                MessageBox.Show("is updatemode was not set to true. was not saved to database");
            }
        }
        private void dataGrid3_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            isUpdateMode = true;
            if (isUpdateMode)
            {
                CreditCardInfo evCred = (from emp in infoContext.CreditCardInfoes
                                     where emp.AccountNumber == objCeditToEdit.AccountNumber
                                     select emp).First();

                //AccountNum is [0] ExpDate is column 1 security Key is 2, city is 3, state is 4, ZipCode is 5
                FrameworkElement ele1 = dataGrid3.Columns[1].GetCellContent(e.Row);
                if (ele1.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele1).Text;
                    objCeditToEdit.ExpirationDate = DateTime.Parse(dereventName);
                }
                FrameworkElement ele2 = dataGrid3.Columns[2].GetCellContent(e.Row);
                if (ele2.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele2).Text;
                    objCeditToEdit.SecurityKey = dereventName;
                }
                FrameworkElement ele3 = dataGrid3.Columns[3].GetCellContent(e.Row);
                if (ele3.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele3).Text;
                    objCeditToEdit.City = dereventName;
                }
                FrameworkElement ele4 = dataGrid3.Columns[4].GetCellContent(e.Row);
                if (ele4.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele4).Text;
                    objCeditToEdit.State = dereventName;
                }
                FrameworkElement ele5 = dataGrid3.Columns[5].GetCellContent(e.Row);
                if (ele5.GetType() == typeof(TextBox))
                {
                    var dereventName = ((TextBox)ele5).Text;
                    objCeditToEdit.ZipCode = dereventName;
                }
                

            }
            else
            {
                MessageBox.Show("is updatemode was not set to true. was not saved to database");
            }

        }
        private void dataGrid1_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //updating database via entity model
            saveMeToDataBase();
            MessageBox.Show("was saved");

        }

        private void dataGrid2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            saveMeToDataBase();
            MessageBox.Show("payments were saved");
        }
        private void dataGrid3_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            saveMeToDataBase();
        }  
    }
}
