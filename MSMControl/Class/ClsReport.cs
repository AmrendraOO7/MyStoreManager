using MSMControl.Connection;
using MSMControl.Interface;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace MSMControl.Class
{
    public class ClsReport : IReport
    {
        private ReportViewer reportViewer; // Reference to the ReportViewer control on your form

        public ClsReport(ReportViewer viewer)
        {
            reportViewer = viewer;
        }

        public void PrintCall(object printData)
        {
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = "D:/All Workspaces/My Workspace/Desktop App/MyStoreManager/MyStoreManager/Print/Reports/MSM_PO.rdlc";

            // Pass data to the report
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CompanyName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Columns.Add("Registration", typeof(string));
            dataTable.Columns.Add("Signature", typeof(string));
            dataTable.Columns.Add("billMessage", typeof(string));
            dataTable.Columns.Add("copyrightYear", typeof(string));

            DataRow dataRow = dataTable.NewRow();
            dataRow["CompanyName"] = Global.CompanyName;
            dataRow["Address"] = Global.Address + ", " + Global.City + "," + Global.State;
            dataRow["Country"] = Global.Country + "," + Global.Contact;
            dataRow["Registration"] = Global.Registration;
            dataRow["Signature"] = Global.UserName;
            dataRow["billMessage"] = Global.billMessage;
            dataRow["copyrightYear"] = Global.copyrightYear;

            dataTable.Rows.Add(dataRow);

            ReportDataSource reportDataSource = new ReportDataSource("DataSetName", dataTable);
            reportViewer.LocalReport.DataSources.Clear(); // Clear any existing data sources
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Refresh and display the report
            reportViewer.RefreshReport();
        }
    }
}
