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

namespace new_ticket_master
{
    /// <summary>
    /// Interaction logic for PaymentStatus.xaml
    /// </summary>
    public partial class PaymentStatus : Window
    {
        public PaymentStatus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         //binding expression validation
            BindingExpression pay = tickPay.GetBindingExpression(TextBox.TextProperty);
            BindingExpression pur = tickPur.GetBindingExpression(TextBox.TextProperty);

            //synchronizing data of object with controls that reference object through bindings
            // also checks validation

           pay.UpdateSource();
            pur.UpdateSource();

            if (pay.HasError || pur.HasError)
            {
                string format = String.Format("Payment Method: {0}\n Purchase Date: {1}", pay.ValidationError.ErrorContent, pur.ValidationError.ErrorContent);
                MessageBox.Show(format, "please correct the erorrs highlighted in red", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else
            {
                this.DialogResult = true;
            }
        }
    }
}
