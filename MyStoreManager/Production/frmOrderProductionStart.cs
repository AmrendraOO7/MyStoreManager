using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.Print.PrintForm;
using MyStoreManager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MyStoreManager.Production
{
    public partial class frmOrderProductionStart : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private int loginID; //Login id
        private string ToPerform, msg = string.Empty;
        private int MouseBtn; //mouse button status holder
        private string orderStatus, Search = string.Empty;
        private int OID;
        private string ICVNUM, OVNUM= string.Empty;
        private int ICID;
        private int currentColumn;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frmOrderProductionStart()
        {
            InitializeComponent();
            DataGridColumns();
        }

        private void frmOrderProductionStart_Load(object sender, EventArgs e)
        {
            clear();
        }

        public bool FormIsOK()
        {
            if (ToPerform != null && MouseBtn == 0)
            {
                if (MessageBox.Show($@"Are you sure to {ToPerform} processing this order {txtVoucherNum.Text}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (ICID == 0 || ICVNUM == string.Empty )
            {
                MessageBox.Show("Please select order.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtMiti, "Please enter Miti.");
                txtVoucherNum.Focus();
                return false;
            }
            else return true;
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
                    PleaseWait.Show();
                    if (await StartProcessing() != 0)
                    {
                        PleaseWait.Close(); 
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //if (Global.printMessage is true) if (MessageBox.Show("Do you want to print this?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) btnPrint.PerformClick();
                        //if (Global.autoPrint is true) btnPrint.PerformClick();
                        frmOrderProductionStart_Load(sender, e);
                        //FormStatus(true, false);
                    }
                    else
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtVoucherNum.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtVoucherNum.Focus();
            }
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            orderStatus = "Processing";
            btn_OK_Click(sender, e);
        }

        public void DataGridColumns()
        {
            ProddataGridView.ColumnCount = 11;
            ProddataGridView.Columns[0].Name = "Order Status";
            ProddataGridView.Columns[1].Name = "ICVNUM";
            ProddataGridView.Columns[2].Name = "OID";
            ProddataGridView.Columns[3].Name = "OVNUM";
            ProddataGridView.Columns[4].Name = "Issue Date";
            ProddataGridView.Columns[5].Name = "Issue Miti";
            ProddataGridView.Columns[6].Name = "Dlv Date";
            ProddataGridView.Columns[7].Name = "Dlv Miti";
            ProddataGridView.Columns[8].Name = "Assigned To";
            ProddataGridView.Columns[9].Name = "Estimited Time";
            ProddataGridView.Columns[10].Name = "ICID";

            //Autosize
            ProddataGridView.Columns[0].Width = 150;
            ProddataGridView.Columns[1].Width = 150;
            ProddataGridView.Columns[2].Visible = false;
            ProddataGridView.Columns[3].Width = 150;
            ProddataGridView.Columns[4].Width = 150;
            ProddataGridView.Columns[5].Width = 150;
            ProddataGridView.Columns[6].Width = 150;
            ProddataGridView.Columns[8].Width = 150;
            ProddataGridView.Columns[9].Width = 150;
            ProddataGridView.Columns[10].Visible = false;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
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
            txtVoucherNum.Clear();
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
            getProcessingOrders();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void txtVoucherNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.F1) btn_Start.PerformClick();
        }

        private void ProddataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MessageBox.Show("Are you sure to Set this order as completed...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            MouseBtn = 1;
            if (ProddataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ProddataGridView.SelectedRows[0];
                ICID = Convert.ToInt32(selectedRow.Cells["ICID"].Value.ToString());
                ICVNUM = selectedRow.Cells["ICVNUM"].Value.ToString();
                OID = Convert.ToInt32(selectedRow.Cells["OID"].Value.ToString());
                OVNUM = selectedRow.Cells["OVNUM"].Value.ToString();
            }

            if(ICID > 0 || ICVNUM != string.Empty || OID > 0 || OVNUM != string.Empty)
            {
                ToPerform = "Update";
                orderStatus = "Finished";
                btn_OK_Click(sender, e);
            }
            MouseBtn = 0;
        }

        public void getProcessingOrders()
        {
            var ds = mainMaster.GetProcessing("Processing", " ",string.Empty);
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
                    ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Estimited Time"].Value = dgv["Est_Time"].ToString();
                    ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                }
                ProddataGridView.ClearSelection();                       
            }                
        }

        private void btn_order_VoucherSearch_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "IssueCard", 0, "InProcess", 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ICID = Int32.Parse(popup.SelectedRow[0]["ICID"].ToString());
                    txtVoucherNum.Text = ICVNUM = popup.SelectedRow[0]["ICVNUM"].ToString();
                    OID = Int32.Parse(popup.SelectedRow[0]["OID"].ToString());
                    OVNUM = popup.SelectedRow[0]["OVNUM"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
