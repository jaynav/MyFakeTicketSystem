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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class About : Window
    {
        Version bob;
        
        public About()
        {
           
            InitializeComponent();

            bob = new Version();
            
                 string versionInfo = string.Format("Mock system version {0}.{1}.{2}.{3}", bob.Build, bob.Major, bob.Minor, bob.Revision);
                 this.textBoxVersion.Text = versionInfo;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
