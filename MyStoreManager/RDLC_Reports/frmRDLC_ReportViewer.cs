using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MSMControl.Class;

namespace MyStoreManager.RDLC_Reports
{
    public partial class frmRDLC_ReportViewer : Form
    {
        public frmRDLC_ReportViewer()
        {
            InitializeComponent();
        }

        private void frmRDLC_ReportViewer_Load(object sender, EventArgs e)
        {
            // Load the report when the form loads (optional)
            LoadReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Call the LoadReport method to refresh the report when the Print button is clicked
            LoadReport();
        }

        private void LoadReport()
        {
            // Create a DataTable or use any data source that contains the data you want to display in the report
            DataTable yourData = ClsMainMaster.GetProduct(); ; // Implement this method to retrieve your data

            // Create a report data source
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet"; // Replace with your dataset name in the report
            reportDataSource.Value = yourData;

            // Clear any existing data sources
            reportViewer.LocalReport.DataSources.Clear();

            // Add the new data source to the report
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Set the report path (make sure it matches the path to your .rdlc file)
            reportViewer.LocalReport.ReportPath = "./Reports/PurchaseOrder_Bill.rdlc";

            // Refresh the report to display the data
            reportViewer.RefreshReport();
        }

        private DataTable GetReportData()
        {
            // Implement this method to retrieve your data from your data source (e.g., database, API)
            // Create and return a DataTable with your data
            DataTable dataTable = new DataTable();
            // Populate the dataTable with your data
            return dataTable;
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MyStoreManager.RDLC_Reports
//{
//    public partial class frmRDLC_ReportViewer : Form
//    {
//        public frmRDLC_ReportViewer()
//        {
//            InitializeComponent();
//        }

//        private void frmRDLC_ReportViewer_Load(object sender, EventArgs e)
//        {

//            this.reportViewer.RefreshReport();
//        }

//        private void btnPrint_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
