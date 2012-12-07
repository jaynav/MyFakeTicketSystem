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
    /// Interaction logic for CardInfo.xaml
    /// </summary>
    public partial class CardInfo : Window
    {
        public CardInfo()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            BindingExpression accountNum = aNum.GetBindingExpression(TextBox.TextProperty);
            BindingExpression expirationD = eXp.GetBindingExpression(TextBox.TextProperty);
            BindingExpression securityK = secK.GetBindingExpression(TextBox.TextProperty);
            BindingExpression userFirst= uFN.GetBindingExpression(TextBox.TextProperty);
            BindingExpression userLast = uLN.GetBindingExpression(TextBox.TextProperty);
            BindingExpression userCity = city.GetBindingExpression(TextBox.TextProperty);
            BindingExpression userState = state.GetBindingExpression(TextBox.TextProperty);
            BindingExpression userZip = zip.GetBindingExpression(TextBox.TextProperty);

            accountNum.UpdateSource();
            expirationD.UpdateSource();
            securityK.UpdateSource();
            userFirst.UpdateSource();
            userLast.UpdateSource();
            userCity.UpdateSource();
            userState.UpdateSource();
            userZip.UpdateSource();

            if (accountNum.HasError || expirationD.HasError || securityK.HasError || userFirst.HasError
                || userLast.HasError || userCity.HasError || userState.HasError || userZip.HasError)
            {
                string format = String.Format("Account Number: {0}\n Expiration Date: {1}\n Security Key: {2}\n First Name: {3}\n LastName: {4}\n City: {5}\n State: {6}\n Zip: {7}", accountNum.ValidationError.ErrorContent,
                    expirationD.ValidationError.ErrorContent, securityK.ValidationError.ErrorContent,
                    userFirst.ValidationError.ErrorContent, userLast.ValidationError.ErrorContent, userCity.ValidationError.ErrorContent,
                    userState.ValidationError.ErrorContent, userZip.ValidationError.ErrorContent);
                MessageBox.Show(format, "please correct the erorrs highlighted in red", MessageBoxButton.OK, MessageBoxImage.Warning);
          
            }
            else
            {
                this.DialogResult = true;
            }
            }
    }
}
