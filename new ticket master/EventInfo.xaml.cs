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
    /// Interaction logic for EventInfo.xaml
    /// </summary>
    public partial class EventInfo : Window
    {
        public EventInfo()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         
            BindingExpression eventNam = EName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression eventcost = ECost.GetBindingExpression(TextBox.TextProperty);

            eventNam.UpdateSource();
            eventcost.UpdateSource();

            if (eventNam.HasError || eventcost.HasError)
            {
                string format = String.Format(" Event Name: {0} \n Event Cost: {1}", eventNam.ValidationError.ErrorContent, eventcost.ValidationError.ErrorContent);
                MessageBox.Show(format,"please correct the erorrs highlighted in red",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                this.DialogResult = true;
            }
        }
    }
}
