using ClosedXML.Excel;
using Devart.Common;
using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Production
{
    public partial class frmReadyGoods : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private int loginID; //Login id
        private string ToPerform, msg = string.Empty;
        private int MouseBtn; //mouse button status holder
        private string orderStatus, Search = string.Empty;
        private int OID;
        private string ICVNUM, OVNUM = string.Empty;
        private int ICID;
        private int currentColumn;
        private string checkedBtn;
        private string reportType1, reportType2;
        public string columnName, selectedColumn = string.Empty;
        public string[] allVoucher;
        string yyyy_From, mm_From, dd_From = string.Empty;
        string yyyy_To, mm_To, dd_To = string.Empty;
        string fromDate, toDate = string.Empty;
        public static DataTable dt;
        DataSet ds = new DataSet();
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frmReadyGoods()
        {
            InitializeComponent();
            DataGridColumns();
        }
        public void DataGridColumns()
        {
            ProddataGridView.ColumnCount = 10;
            ProddataGridView.Columns[0].Name = "ICVNUM";
            ProddataGridView.Columns[1].Name = "OVNUM";
            ProddataGridView.Columns[2].Name = "Order Status";
            ProddataGridView.Columns[3].Name = "Issue Date";
            ProddataGridView.Columns[4].Name = "Issue Miti";
            ProddataGridView.Columns[5].Name = "Dlv Date";
            ProddataGridView.Columns[6].Name = "Dlv Miti";
            ProddataGridView.Columns[7].Name = "Assigned To";
            ProddataGridView.Columns[8].Name = "ICID";
            ProddataGridView.Columns[9].Name = "OID";

            //Autosize
            ProddataGridView.Columns[0].Width = 150;
            ProddataGridView.Columns[1].Width = 150;
            ProddataGridView.Columns[2].Width = 150;
            ProddataGridView.Columns[3].Width = 150;
            ProddataGridView.Columns[4].Width = 150;
            ProddataGridView.Columns[5].Width = 150;
            ProddataGridView.Columns[6].Width = 150;
            ProddataGridView.Columns[8].Visible = false;
            ProddataGridView.Columns[9].Visible = false;
        }

        private void frmReadyGoods_Load(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            loginID = Global.LoginID;
            lbl_Person.Text = Global.UserName;
            lbl_RoleName.Text = $@"({Global.LoginUser})";
            lbl_CompanyName.Text = Global.CompanyName;
            lbl_Address.Text = $@"{Global.Address},{Global.City},{Global.State},{Global.Country}";
            lbl_Phone.Text = Global.Contact;
            lbl_TagStatus.Text = Global.copyrightYear;
            lbl_CompanyName.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Address.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Phone.TextAlign = ContentAlignment.MiddleCenter;
            ToPerform = string.Empty;
            msg = string.Empty;
            MouseBtn = 0; //mouse button status holder
            Search = string.Empty;
            OID = 0;
            ICID = 0;
            ICVNUM = string.Empty;
            OVNUM = string.Empty;
            ProddataGridView.Rows.Clear();
            //ProddataGridView.DefaultCellStyle.ForeColor = Color.Black;
            MouseBtn = 0; //mouse button status holder
            orderStatus = Search = string.Empty;
            reportType1 = "Finished";
            reportType2 = " ";
            cmbData();
            maskChanged();
            getProcessingOrders();
        }
        public void maskChanged()
        {
            txtFrom.Clear();
            txtTo.Clear();
            if (rdBtnNepali.Checked == true)
            {
                txtFrom.Mask = "0000/00/00";
                txtTo.Mask = "0000/00/00";
            }
            else if (rdBtnEnglish.Checked == true)
            {
                txtFrom.Mask = "00/00/0000";
                txtTo.Mask = "00/00/0000";
            }
        }
        private void GlobalDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/')) e.Handled = true;
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1)) e.Handled = true;
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }
        private void visibleSubSections()
        {

        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        public void cmbData()
        {
            allVoucher = new string[7] { "ICVNUM", "OVNUM", "Issue_Date", "Issue_Miti", "Delivery_Date", "Delivery_Miti", "OrderStatus" };
            cmbSearchOption.DataSource = allVoucher;
        }

        private void setGridData()
        {
            if (ds == null) return;
            if (ds.Tables.Count > 0)
            {
                ProddataGridView.Rows.Clear();
                foreach (DataRow dgv in ds.Tables[0].Rows)
                {
                    var rows = ProddataGridView.Rows.Count;
                    ProddataGridView.Rows.Add();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Order Status"].Value = dgv["OrderStatus"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["ICID"].Value = dgv["ICID"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["ICVNUM"].Value = dgv["ICVNUM"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["OID"].Value = dgv["OID"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["OVNUM"].Value = dgv["OVNUM"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Issue Date"].Value = (DateTime.Parse(dgv["Issue_Date"].ToString()).Date).ToString("d");
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Issue Miti"].Value = dgv["Issue_Miti"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Dlv Date"].Value = (DateTime.Parse(dgv["Delivery_Date"].ToString()).Date).ToString("d");
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Dlv Miti"].Value = dgv["Delivery_Miti"].ToString();
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Assigned To"].Value = dgv["Assignee_Name"].ToString();
                    ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                }
                ProddataGridView.ClearSelection();
            }
        }

        public void getProcessingOrders()
        {
            ds = (DataSet)mainMaster.GetProcessing(reportType1, reportType2, string.Empty);
            if(ds.Tables.Count > 0) dt = ds.Tables[0];
            setGridData();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void ProddataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = ProddataGridView.SelectedRows[0];
            if (MessageBox.Show($@"Are you sure to Set this order {selectedRow.Cells["ICVNUM"].Value.ToString()} as Delivered...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            MouseBtn = 1;
            if (ProddataGridView.SelectedRows.Count > 0)
            {
                ICID = Convert.ToInt32(selectedRow.Cells["ICID"].Value.ToString());
                ICVNUM = selectedRow.Cells["ICVNUM"].Value.ToString();
                OID = Convert.ToInt32(selectedRow.Cells["OID"].Value.ToString());
                OVNUM = selectedRow.Cells["OVNUM"].Value.ToString();
            }

            if (ICID > 0 || ICVNUM != string.Empty || OID > 0 || OVNUM != string.Empty)
            {
                ToPerform = "Update";
                orderStatus = "Delivered";
                btn_OK_Click(sender, e);
            }
            MouseBtn = 0;
        }
        public bool FormIsOK()
        {
            if (ToPerform != null && MouseBtn == 0)
            {
                if (MessageBox.Show($@"Are you sure to {ToPerform} processing this order...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
                else return true;
            }
            else return true;
        }

        private void rdBtnReadyGoods_CheckedChanged(object sender, EventArgs e)
        {
            if(rdBtnReadyGoods.Checked == true)
            {
                reportType1 = "Finished";
                reportType2 = " ";
                visibleSubSections();
                getProcessingOrders();
            }
        }

        private void rdDeliveredGoods_CheckedChanged(object sender, EventArgs e)
        {
            if(rdDeliveredGoods.Checked == true)
            {
                reportType1 = "Delivered";
                reportType2 = " ";
                visibleSubSections();
                getProcessingOrders();
            }
        }

        private void rdBtnReadyAndDelivered_CheckedChanged(object sender, EventArgs e)
        {
            if(rdBtnReadyAndDelivered.Checked == true)
            {
                reportType1 = "Finished";
                reportType2 = "Delivered";
                visibleSubSections();
                getProcessingOrders();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to export file.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PleaseWait.Show();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(ds);
                                workbook.SaveAs(saveFileDialog.FileName);
                            }
                            PleaseWait.Close();
                            MessageBox.Show("File saved sucessfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            PleaseWait.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else return;
        }

        private void cmbSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) btn_order_TextSearch.PerformClick();
        }

        private void rdBtnEnglish_CheckedChanged(object sender, EventArgs e)
        {
            maskChanged();
        }

        private void rdBtnNepali_CheckedChanged(object sender, EventArgs e)
        {
            maskChanged();
        }

        private void btnFilterSearch_Click(object sender, EventArgs e)
        {

            //create the process of when english date have 9 digit then 0 mist be added to missing place and if there is 0 before number in miti that 0 shuld be removed
            //if (rdBtnEnglish.Checked == true && txtFrom.Text.Length < 10 ||  txtTo.Text.Length < 10)
            //{
            //    yyyy_From = ((txtFrom.Text).Substring(0, 4));
            //    mm_From = ((txtFrom.Text).Substring(5, 1));
            //    dd_From = ((txtFrom.Text).Substring(8, 1));

            //    yyyy_To = ((txtTo.Text).Substring(0, 4));
            //    mm_To = ((txtTo.Text).Substring(5, 1));
            //    dd_To = ((txtTo.Text).Substring(8, 1));
            //}
            //if (rdBtnNepali.Checked == true)
            //{
            //    yyyy_From = ((txtFrom.Text).Substring(0, 4));
            //    mm_From = ((txtFrom.Text).Substring(5, 1));
            //    dd_From = ((txtFrom.Text).Substring(8, 1));

            //    yyyy_To = ((txtTo.Text).Substring(0, 4));
            //    mm_To = ((txtTo.Text).Substring(5, 1));
            //    dd_To = ((txtTo.Text).Substring(8, 1));

            //    if (mm_From == "0" && dd_From == "0") fromDate = yyyy_From + "/" + ((txtFrom.Text).Substring(6, 1)) + "/" + ((txtFrom.Text).Substring(9, 1));

            //    else if (mm_From == "0" && dd_From != "0") fromDate = yyyy_From + "/" + ((txtFrom.Text).Substring(6, 1)) + "/" + ((txtFrom.Text).Substring(8, 2));

            //    else if (mm_From != "0" && dd_From == "0") fromDate = yyyy_From + "/" + ((txtFrom.Text).Substring(5, 2)) + "/" + ((txtFrom.Text).Substring(9, 1));

            //    else fromDate = yyyy_From + "/" + mm_From + "/" + dd_From;

            //    if (mm_To == "0" && dd_To == "0") toDate = yyyy_To + "/" + ((txtTo.Text).Substring(6, 1)) + "/" + ((txtTo.Text).Substring(9, 1));

            //    else if (mm_To == "0" && dd_To != "0") toDate = yyyy_To + "/" + ((txtTo.Text).Substring(6, 1)) + "/" + ((txtTo.Text).Substring(8, 2));

            //    else if (mm_To != "0" && dd_To == "0") toDate = yyyy_To + "/" + ((txtTo.Text).Substring(5, 2)) + "/" + ((txtTo.Text).Substring(9, 1));

            //    else toDate = yyyy_To + "/" + mm_To + "/" + dd_To;
            //}
            //else
            //{
            //    fromDate = txtFrom.Text;
            //    toDate = txtTo.Text;
            //}
            fromDate = txtFrom.Text;
            toDate = txtTo.Text;
            if (txtFrom.Text.Length == 10 && txtTo.Text.Length == 10)
            {
                if (rdBtnNepali.Checked == true) ds = (DataSet)mainMaster.GetProcessing(fromDate, toDate, "miti");
                else if (rdBtnEnglish.Checked == true) ds = (DataSet)mainMaster.GetProcessing(fromDate, fromDate, "date");
                setGridData();
            }
        }

        private void btn_order_TextSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var columnName = cmbSearchOption.Text;
                DataView dv = dt.DefaultView;
                dv.RowFilter = $@"{columnName} LIKE '" + txtSearch.Text + "%'";
                var dataTable = dv.ToTable().Copy();
                ds.Tables.Clear();
                ds.Tables.Add(dataTable);
                setGridData();
            }
            else return;
        }

        private void rdBtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if( rdBtnAll.Checked == true)
            {
                reportType1 = "";
                reportType2 = " ";
                visibleSubSections();
                getProcessingOrders();
            }
        }

        public async Task<int> StartProcessing()
        {
            mainMaster.Start_Processing.ToPerform = ToPerform;
            mainMaster.Start_Processing.ICID = ICID;
            mainMaster.Start_Processing.ICVNUM = ICVNUM;
            mainMaster.Start_Processing.OID = OID;
            mainMaster.Start_Processing.OVNUM = OVNUM;
            mainMaster.Start_Processing.OrderStatus = orderStatus;
            mainMaster.Start_Processing.UserID = Global.LoginID;
            return await Task.Run(() => mainMaster.GetStartProcessing());
        }

        public async void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToPerform is null) return;
                msg = ToPerform;
                if (FormIsOK())
                {
                    //progress bar implememtation starts
                    if (await StartProcessing() != 0)
                    {
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //if (Global.printMessage is true) if (MessageBox.Show("Do you want to print this?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) btnPrint.PerformClick();
                        //if (Global.autoPrint is true) btnPrint.PerformClick();
                        frmReadyGoods_Load(sender, e);
                        //FormStatus(true, false);
                    }
                    else
                    {

                        MessageBox.Show($@"{msg} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
        }
        private void reloadEventFunction(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                clear();
            }
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
            }
        }
    }
}
