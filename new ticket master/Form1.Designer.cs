namespace new_ticket_master
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TicketMastersDataSet = new new_ticket_master.TicketMastersDataSet();
            this.EventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EventsTableAdapter = new new_ticket_master.TicketMastersDataSetTableAdapters.EventsTableAdapter();
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsersTableAdapter = new new_ticket_master.TicketMastersDataSetTableAdapters.UsersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TicketMastersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.UsersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "new_ticket_master.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(580, 437);
            this.reportViewer1.TabIndex = 0;
            // 
            // TicketMastersDataSet
            // 
            this.TicketMastersDataSet.DataSetName = "TicketMastersDataSet";
            this.TicketMastersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EventsBindingSource
            // 
            this.EventsBindingSource.DataMember = "Events";
            this.EventsBindingSource.DataSource = this.TicketMastersDataSet;
            // 
            // EventsTableAdapter
            // 
            this.EventsTableAdapter.ClearBeforeFill = true;
            // 
            // UsersBindingSource
            // 
            this.UsersBindingSource.DataMember = "Users";
            this.UsersBindingSource.DataSource = this.TicketMastersDataSet;
            // 
            // UsersTableAdapter
            // 
            this.UsersTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 437);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TicketMastersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EventsBindingSource;
        private TicketMastersDataSet TicketMastersDataSet;
        private TicketMastersDataSetTableAdapters.EventsTableAdapter EventsTableAdapter;
        private System.Windows.Forms.BindingSource UsersBindingSource;
        private TicketMastersDataSetTableAdapters.UsersTableAdapter UsersTableAdapter;
    }
}