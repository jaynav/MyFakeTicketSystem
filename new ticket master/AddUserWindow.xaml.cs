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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // add validation will automatically be done in uservalidator class.
            BindingExpression fn = firstNameTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression ln = lastNameTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression sta = stateTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression ci = cityTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression st = streetAddressTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression zi = zipCodeTxt.GetBindingExpression(TextBox.TextProperty);
            BindingExpression ph = phoneNumTxt.GetBindingExpression(TextBox.TextProperty);

            fn.UpdateSource();
            ln.UpdateSource();
            sta.UpdateSource();
            ci.UpdateSource();
            st.UpdateSource();
            zi.UpdateSource();
            ph.UpdateSource();


            if (ci.HasError || st.HasError || zi.HasError || ph.HasError || fn.HasError || ln.HasError || sta.HasError)
            {
                string format = String.Format( "City:{0}\n Street:{1}\n Zip:{2}\n Phone:{3}\n FirstName:{4}\n LastName:{5}\n State:{6}",
                    ci.ValidationError.ErrorContent,st.ValidationError.ErrorContent,
                    zi.ValidationError.ErrorContent,ph.ValidationError.ErrorContent,
                    fn.ValidationError.ErrorContent,ln.ValidationError.ErrorContent, sta.ValidationError.ErrorContent);
                MessageBox.Show(format, "please correct the erorrs highlighted in red", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.DialogResult = true;
            }
        }
        
    }
}
/*
          if(String.IsNullOrEmpty(this.firstNameTxt.Text))
          {
              //add validation
              return;
          }

          if (string.IsNullOrEmpty(this.lastNameTxt.Text))
          {

              return;
          }
          if (string.IsNullOrEmpty(this.streetAddressTxt.Text))
          {
              return;
          }

          if (string.IsNullOrEmpty(this.cityTxt.Text))
          {
              return;
          }

          if (string.IsNullOrEmpty(this.stateTxt.Text))
          {
              return;
          }
          if (string.IsNullOrEmpty(this.zipCodeTxt.Text))
          {
              return;
          }

          if(string.IsNullOrEmpty(this.phoneNumTxt.Text))
          {
              return;
          }
     */