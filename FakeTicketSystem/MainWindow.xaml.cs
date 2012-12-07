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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FakeTicketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void purchaseTicketsMenu_Click(object sender, RoutedEventArgs e)
        {
            //String messenger = string.Format("purchase {0} ticket for {1}cutomer :{2} for event{3}", numberOfTickets.Value, privilegeLevelCbx.Text, customerReferenceTxtB.Text, eventList.Text);
            //MessageBox.Show(messenger, "thank you");

            // these create bindingexpression object used to propagate the values on the form to the ordered ticket object
            BindingExpression eventB = eventList.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression customRefB = customerReferenceTxtB.GetBindingExpression(TextBox.TextProperty);
            BindingExpression priviLevelB = privilegeLevelCbx.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression numberOfTickB = numberOfTickets.GetBindingExpression(Slider.ValueProperty);

            //synchronizes data in an object with the controls that refrence the objet through bindings.
            eventB.UpdateSource();
            customRefB.UpdateSource();
            priviLevelB.UpdateSource();
            numberOfTickB.UpdateSource();

            if(eventB.HasError||customRefB.HasError|| priviLevelB.HasError|| numberOfTickB.HasError)
            {
                MessageBox.Show("Please correct Errors",  "Purchase aborted");
            }
            else
            {
                Binding ticketOdrBinding = BindingOperations.GetBinding(privilegeLevelCbx, ComboBox.TextProperty);
                OrderedTicket ticketOrder = ticketOdrBinding.Source as OrderedTicket;
                MessageBox.Show(ticketOrder.ToString(), "purchased");
            }
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
