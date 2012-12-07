using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace new_ticket_master
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TicketMastersDataSet.Users' table. You can move, or remove it, as needed.
            this.UsersTableAdapter.Fill(this.TicketMastersDataSet.Users);
            // TODO: This line of code loads data into the 'TicketMastersDataSet.Events' table. You can move, or remove it, as needed.
            this.EventsTableAdapter.Fill(this.TicketMastersDataSet.Events);

            this.reportViewer1.RefreshReport();
        }
    }
}
