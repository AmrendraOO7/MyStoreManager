using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.PreEntry;
using MyStoreManager.Print;
using MyStoreManager.Print.PrintForm;
using MyStoreManager.Setup;
using Stimulsoft.Report;
using Stimulsoft.Report.Design.Controls;
using Stimulsoft.Report.Viewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyStoreManager.Production
{
    public partial class frmOrderCard : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        //private readonly IReport report = new ClsReport(reportViewer);
        private int loginID; //Login id
        private string ToPerform, msg = string.Empty;
        private int CustoID; //Customer Id 
        private int VoucherNum; //string for voucher number
        private int unitID; //Unit ID // uitlized in grid
        private int Pid; //PersonID
        private int MouseBtn; //mouse button status holder
        private string Search = string.Empty;
        private int ProdID; //Product ID
        private string DateOf = string.Empty;
        private int DuplicateValue = 0;
        string hours, minuts = string.Empty;
        private int OID;
        private int OldCreatorUserID;
        private DateTime OldCreatedDate;
        private string isDeleted = string.Empty; //by default it is false
        private string OVNUM = string.Empty;
        private int OldloginID;
        private int currentColumn;
        private string orderStatus = string.Empty;
        private bool fromPrint = false;
        public DataTable dt;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        //private string 
        public frmOrderCard()
        {
            InitializeComponent();
            DataGridColumns();
        }

        private void frmOrderCard_Load(object sender, EventArgs e)
        {
            clear();
        }
        public void DataGridColumns()
        {
            ProddataGridView.ColumnCount = 9;
            ProddataGridView.Columns[0].Name = "SNO";
            ProddataGridView.Columns[1].Name = "PID";
            ProddataGridView.Columns[2].Name = "Short Name";
            ProddataGridView.Columns[3].Name = "BarCode";
            ProddataGridView.Columns[4].Name = "Product";
            ProddataGridView.Columns[5].Name = "Quantity";
            ProddataGridView.Columns[6].Name = "Unit";
            ProddataGridView.Columns[7].Name = "EST Time/Unit";
            ProddataGridView.Columns[8].Name = "EST Total Time";
            
            //Autosize
            ProddataGridView.Columns[0].Width = 40;
            ProddataGridView.Columns[1].Visible = false;
            ProddataGridView.Columns[2].Width = 100;
            ProddataGridView.Columns[3].Visible = false;
            ProddataGridView.Columns[4].Width = 215;
            ProddataGridView.Columns[5].Width = 60;
            ProddataGridView.Columns[6].Width = 70;
            ProddataGridView.Columns[7].Width = 150;
            ProddataGridView.Columns[8].Width = 150;
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
            CustoID = 0;
            VoucherNum = 0; //string for voucher number
            unitID = 0 ; //Unit ID // uitlized in grid
            MouseBtn = 0; //mouse button status holder
            Search = string.Empty;
            DateOf = string.Empty;
            hours = "Hrs";
            minuts = "Mins";
            OID = 0;
            isDeleted = string.Empty;
            OVNUM = string.Empty;
            OldloginID = 0;
            lbl_status.Text = "";
            txt_ESTTimePHrs.Clear();
            txtVoucherNum.Clear(); 
            English_dateTimePicker.ResetText();
            txtMiti.Clear(); 
            TxtCompanyName.Clear(); 
            txtCompanyAddress.Clear(); 
            DlvEnglish_dateTimePicker.ResetText();
            txtDlvMiti.Clear();
            ProddataGridView.Rows.Clear();
            txt_Note.Clear();
            orderStatus = string.Empty;
            lblEstTime.Text = $@"00{hours} 00{minuts}";
            ProddataGridView.DefaultCellStyle.ForeColor = Color.Black;
            //imp
            //txt_ESTTimePHrs.Format = DateTimePickerFormat.Custom;
            //txt_ESTTimePHrs.CustomFormat = "HH:mm";
            ProductEntryClear();
            FormStatus(true, false);
        }
        public void ProductEntryClear()
        {
            ProdID = 0;
            btn_Product_Search.Enabled = true;
            txtProductName.Clear();
            lbl_ProductID.Text = "";
            lbl_Barcode.Text = "";
            lblPShortname.Text = "";
            txt_Quantity.Clear();
            txtUnit.Clear();
            DuplicateValue = 0;
            lbl_TotalTimeEST.Text = $@"00{hours} 00{minuts}";
            txt_ESTTimePHrs.Text = "00:00";
        }

        private void FormStatus(bool btn, bool txt)
        {
            btn_New.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            //buttons bellow will enable with the text enable
            txt_ESTTimePHrs.Enabled = txtVoucherNum.Enabled = English_dateTimePicker.Enabled = txtMiti.Enabled = TxtCompanyName.Enabled = txtCompanyAddress.Enabled = txtProductName.Enabled = txt_Quantity.Enabled = txtUnit.Enabled = DlvEnglish_dateTimePicker.Enabled = txtDlvMiti.Enabled = txt_Note.Enabled = txt;
            btn_order_VoucherSearch.Enabled = ProddataGridView.Enabled = Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Product_Insert.Enabled = Btn_CustoSearch.Enabled = btn_Product_Search.Enabled = txt;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            Btn_Ok.Text = "&Save";
            VoucherNumber(); // Just to be sure
            FormStatus(false, true);
            DlvEnglish_dateTimePicker.Value = English_dateTimePicker.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            English_dateTimePicker.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            Btn_Ok.Text = "&Update";
            FormStatus(false, true);
            //UpdateDataGrid();
            //UpdateProddataGridViewData.Visible = true;
            txtVoucherNum.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            Btn_Ok.Text = "&Delete";
            FormStatus(false, false);
            ProddataGridView.Enabled = false;
            txtVoucherNum.Enabled = btn_order_VoucherSearch.Enabled = true;
            Btn_Ok.Enabled = true;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void btn_order_VoucherSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Update" || ToPerform == "Delete")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "OrderTicket", 0, fromPrint ? "print" : "Pending", 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        OID = Int32.Parse(popup.SelectedRow[0]["OID"].ToString());
                        txtVoucherNum.Text = OVNUM = popup.SelectedRow[0]["OVNUM"].ToString();
                        English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Order_Date"].ToString());
                        txtMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                        DlvEnglish_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Order_Date"].ToString());
                        txtDlvMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                        OldloginID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        lbl_Person.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                        lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                        lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                        lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                        CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                        TxtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                        txt_Note.Text = popup.SelectedRow[0]["Note"].ToString();
                        lblEstTime.Text = popup.SelectedRow[0]["Est_Time"].ToString();
                        OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        isDeleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                        OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                        lbl_status.Text = orderStatus = popup.SelectedRow[0]["OrderStatus"].ToString();
                        var ds = mainMaster.GetOrderTicketDetails(OVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            ProddataGridView.Rows.Clear();
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = ProddataGridView.Rows.Count;
                                ProddataGridView.Rows.Add();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                var qnty = Decimal.Parse(dgv["Quantiy"].ToString());
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Quantity"].Value = qnty == 0 ? "0.00" : qnty.ToString("##.##########");
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["EST Time/Unit"].Value = dgv["EST_HrsPerUnit"].ToString();
                                ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells["EST Total Time"].Value = dgv["TotalEST_HrsPerUnit"].ToString();
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            ProddataGridView.ClearSelection();
                            if (ToPerform == "Delete")
                            {
                                FormStatus(false, false);
                                Btn_Ok.Enabled = true;
                                Btn_Ok.Text = "Delete";
                                Btn_Ok.Focus();
                            }
                        }
                        if (fromPrint == true)
                        {
                            FormStatus(false, false);
                            fromPrint = false;
                            btnPrint.PerformClick();
                        }
                        if(orderStatus != "Pending") FormStatus(false, false); //if order ticket is in process it is not allowed to edit or delete.
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                // MessageBox.Show("Something Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) btn_order_VoucherSearch.PerformClick();
        }

        private void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Insert")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "CustomerSelect", 1, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        CustoID = Int32.Parse(popup.SelectedRow[0]["CID"].ToString());
                        TxtCompanyName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        txtCompanyAddress.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    ProdID = Int32.Parse(popup.SelectedRow[0]["PID"].ToString());
                    txtProductName.Text = popup.SelectedRow[0]["PName"].ToString();
                    lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = popup.SelectedRow[0]["PCode"].ToString();
                    lbl_Barcode.Text = popup.SelectedRow[0]["PBarcode"].ToString();
                    var QntiString = popup.SelectedRow[0]["UnitQnty"].ToString();
                    var Quantity = QntiString == "" ? Decimal.Parse("0") : Decimal.Parse(QntiString);
                    txt_Quantity.Text = Quantity == 0 ? "0" : Quantity.ToString("##.##########");
                    unitID = Int32.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txtUnit.Text = popup.SelectedRow[0]["MainUnitCode"].ToString();
                    //var ESTTimePHrs = popup.SelectedRow[0]["PurchasePrice"].ToString();
                    //txt_ESTTimePHrs.Text = ESTTimePHrs == 0 ? "00:00:00" : ESTTimePHrs;
                }
                txtProductName.Focus();
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btn_Unit_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, "MSM.UnitMaster", Global.InitialCatalogMain, "GetUnit", 1, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    unitID = int.Parse(popup.SelectedRow[0]["UnitID"].ToString());
                    txtUnit.Text = popup.SelectedRow[0]["UnitCode"].ToString();
                }
            }
            Search = string.Empty;
        }

        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1) btn_Unit_Search_Click(sender, e);
            else if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Unit(true);
                frm.Show();
                unitID = frm.Unitid;
                txtUnit.Text = frm.UnitCode;
            }
        }
        private void btn_ChkGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProddataGridView.Rows.Count; i++)
            {
                if (lbl_ProductID.Text == ProddataGridView.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Duplicate Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    DuplicateValue = 1;
                    return;
                    //txt_Name.Focus();
                }
                else DuplicateValue = 0;
            }
        }
        public bool IsProductOk()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_Name, "Please enter Product name.");
                txtProductName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Quantity.Text.Trim()))
            {
                MessageBox.Show("You must Enter Product Quantity", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txt_Quantity, "Please enter Quantity.");
                txt_Quantity.Focus();
                return false;
            }
            else return true;
        }
        private void Btn_Product_Insert_Click(object sender, EventArgs e)
        {
            txt_ESTTimePHrs_Leave(sender, e);
            if (ProdID > 0)
            {
                if (ProdID == 0 && ProddataGridView.RowCount > 0)
                {
                    return;
                }
                else
                {
                    btn_ChkGrid_Click(sender, e);
                    if (DuplicateValue == 0)
                    {
                        if (IsProductOk())
                        {
                            string Sno = string.Empty;
                            AddRow(Sno, lbl_ProductID.Text, lblPShortname.Text, lbl_Barcode.Text, txtProductName.Text, txt_Quantity.Text, txtUnit.Text, txt_ESTTimePHrs.Text, lbl_TotalTimeEST.Text);
                            ProductEntryClear();
                            TotalTimeCalculator();
                            txtProductName.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter data..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ProductEntryClear();
                            txtProductName.Focus();
                        }
                    }
                    else
                    {
                        ProductEntryClear();
                        txtProductName.Focus();
                    }
                }
            }
            else txt_Note.Focus();
        }


        private void AddRow(string Sno, string PID, string ShortName, string BarCode, string Pname, string quantity, string unit, string estTimePerUnit, string totalEstTime)
        {
            string[] rows = { Sno, PID, ShortName, BarCode,Pname, quantity, unit, estTimePerUnit, totalEstTime };
            ProddataGridView.Rows.Add(rows);
        }

        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
        }

        public bool FormIsOK()
        {
            if (ToPerform != null)
            {
                if (MessageBox.Show($@"Are you sure to {msg}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (string.IsNullOrWhiteSpace(txtMiti.Text.Trim()))
            {
                MessageBox.Show("Please select english date to set Miti", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtMiti, "Please enter Miti.");
                English_dateTimePicker.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDlvMiti.Text.Trim()))
            {
                MessageBox.Show("Please select Delivery english date to Delivery set Miti", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtMiti, "Please enter Miti.");
                DlvEnglish_dateTimePicker.Focus();
                return false;
            }
            if (ProddataGridView.Rows.Count == 0)
            {
                MessageBox.Show("You must Enter Products in order list", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(TxtPname, "Please enter Supplier name");
                DlvEnglish_dateTimePicker.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtCompanyName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Company Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtCname, "Please enter Company name.");
                TxtCompanyName.Focus();
                return false;
            }
            else return true;
        }

        public int OrderTicketSave()
        {
            mainMaster.OT_Master.ToPerform = ToPerform;
            mainMaster.OT_Master.OID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.OrderMaster", "OID") : OID;
            mainMaster.OT_Master.OVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.OT_Master.Order_Date = English_dateTimePicker.Value;
            mainMaster.OT_Master.Order_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.OT_Master.Delivery_Date = DlvEnglish_dateTimePicker.Value;
            mainMaster.OT_Master.Delivery_Miti = txtDlvMiti.Text.Trim().Replace("'", "''");
            mainMaster.OT_Master.SenderID = (int)Global.CompanyID;
            mainMaster.OT_Master.BuyerID = CustoID;
            mainMaster.OT_Master.Est_Time = lblEstTime.Text;
            mainMaster.OT_Master.Note = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.OT_Master.OrderStatus = "Pending";
            mainMaster.OT_Master.is_Deleted = false;
            mainMaster.OT_Master.UserID = Global.LoginID;
            mainMaster.OT_Details.ToPerform = ToPerform;
            mainMaster.OT_Details.OID = mainMaster.OT_Master.OID;
            mainMaster.OT_Details.OVNUM = mainMaster.OT_Master.OVNUM;
            mainMaster.OT_Details.GetGridViewData = ProddataGridView;
            return mainMaster.GetOrderTicketSetup();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            TotalTimeCalculator();
            if (checkMfgDateAndDelvDate() == 0) return;
            try
            {
                if (ToPerform is null) return;
                msg = ToPerform == "Insert" ? "Save" : ToPerform;
                if (FormIsOK())
                {
                    //progress bar implememtation starts
                    PleaseWait.Show();
                    if (OrderTicketSave() != 0)
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        if (Global.printMessage is true) if (MessageBox.Show("Do you want to print this?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) btnPrint.PerformClick();
                        if (Global.autoPrint is true) btnPrint.PerformClick();
                        frmOrderCard_Load(sender, e);
                        //FormStatus(true, false);
                    }
                    else
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                        TxtCompanyName.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                TxtCompanyName.Focus();
            }
        }


    #region ------------------------Methods----------------------------
        protected void VoucherNumber()
        {
            if (ToPerform == "Insert")
            {
                VoucherNum = ClsMainMaster.getInt("MSM.OrderMaster", "OID");
                if (VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "OR-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
                else if (VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "OR-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
                else txtVoucherNum.Text = "OR-" + $"{Global.Year}" + "-" + VoucherNum;
            }
        }

        private void ProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void ProddataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProddataGridView.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure to select Row", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductEntryClear();
                    ProdID = Int32.Parse(ProddataGridView.CurrentRow.Cells["PID"].Value.ToString()); lbl_ProductID.Text = ProdID.ToString();
                    lblPShortname.Text = ProddataGridView.CurrentRow.Cells["Short Name"].Value.ToString();
                    lbl_Barcode.Text = ProddataGridView.CurrentRow.Cells["BarCode"].Value.ToString();
                    txtProductName.Text = ProddataGridView.CurrentRow.Cells["Product"].Value.ToString();
                    if (ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString() != "")
                    {
                        var Quantity = double.Parse(ProddataGridView.CurrentRow.Cells["Quantity"].Value.ToString());
                        txt_Quantity.Text = Quantity == 0 ? "0.00" : Quantity.ToString("##.##########");
                    }
                    else txt_Quantity.Text = "0.00";
                    txtUnit.Text = ProddataGridView.CurrentRow.Cells["Unit"].Value.ToString();
                    txt_ESTTimePHrs.Text = ProddataGridView.CurrentRow.Cells["EST Time/Unit"].Value.ToString();
                    lbl_TotalTimeEST.Text = ProddataGridView.CurrentRow.Cells["EST Total Time"].Value.ToString();
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                    //btn_Product_Search.Enabled = false;
                    //ProddataGridView.Enabled = false;
                }
            }
        }
        public string[] timeCalculator(string strHrs, string strMin, Decimal estTotal, bool isFinalCalculation)
        {
            var hrs = Decimal.Parse(strHrs);
            var min = Decimal.Parse(strMin);           
            if (hrs > 0) hrs = hrs * 60;
            var totalMins = hrs + min;
            var totalhrs = totalMins * estTotal;
            var disphrs = Math.Round((totalhrs / 60), 3, MidpointRounding.AwayFromZero);
            var value = disphrs.ToString().Split('.');
            var x = string.Empty;
            Decimal y = 0;
            if (value.Length > 1)
            {
                x = $@".{value[1]}";
                y = Decimal.Parse(x.ToString()) * 60;
                var reminder = y.ToString().Split('.');
                string[] data = { value[0].ToString(), reminder[0].ToString() };
                return data;
            }    
            else
            {
                string[] data = { value[0].ToString().ToString(), "00" };
                return data;
            }                                   
        }

        private void txt_ESTTimePHrs_Leave(object sender, EventArgs e)
        {
            if (ProdID > 0) 
            { 
                var timePerUnitString = txt_ESTTimePHrs.Text.Split(':');
                var strHrs = timePerUnitString[0].ToString();
                var strMin = timePerUnitString[1].ToString();
                var estTotal = Decimal.Parse(txt_Quantity.Text.Trim().ToString()); //reasion for using decimal in this calculation because Math.Round doesnot return int value, it returns decimal.
                if ( strHrs == "" || strHrs == "  " || strHrs == "0 " || strMin == "" || strMin == "0" || strMin == " 0" || strMin == "0 " || strMin == "  " || strMin == " 0" || strMin == "0 "|| Decimal.Parse(strMin) > 59)
                {
                    MessageBox.Show("Time input not proper", "Time input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ESTTimePHrs.Focus();
                    return;
                }

                var value =  timeCalculator(strHrs, strMin, estTotal, false);
                lbl_TotalTimeEST.Text = $@"{value[0]}{hours} {value[1]}{minuts}";
            }
        }

        public string[] totalTimeCalculator()
        {
            Decimal mins = 0;
            Decimal totalMins = 0;
            string[] returnValue = {""};
            if (ProddataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < ProddataGridView.Rows.Count; i++)
                {
                    var timePerUnitString = ProddataGridView.Rows[i].Cells[8].Value.ToString().Split(' ');
                    var strHrs = timePerUnitString[0].ToString().Replace($@"{hours}","");
                    var strMin = timePerUnitString[1].ToString().Replace($@"{minuts}", "");
                    var hrs = Decimal.Parse(strHrs);
                    var min = Decimal.Parse(strMin);
                    if (hrs > 0) hrs = hrs * 60;
                    mins = hrs + min;
                    totalMins += mins;
                }
                var disphrs = Math.Round((totalMins / 60), 3, MidpointRounding.AwayFromZero);
                var value = disphrs.ToString().Split('.');
                var x = string.Empty;
                Decimal y = 0;
                if (value.Length > 1)
                {
                    x = $@".{value[1]}";
                    y = Decimal.Parse(x.ToString()) * 60;
                    var reminder = y.ToString().Split('.');
                    string[] data = { value[0].ToString(), reminder[0].ToString() };
                    returnValue = data;
                }
                else
                {
                    string[] data = { value[0].ToString().ToString(), "00" };
                    returnValue = data;
                }
            }
            return returnValue;
        }

        public void TotalTimeCalculator()
        {
            var value = totalTimeCalculator();
            lblEstTime.Text = $@"{value[0]}{hours} {value[1]}{minuts}";
        }

        public int checkMfgDateAndDelvDate()
        {
            var totalTime = lblEstTime.Text.Split(' ');
            var strHrs = totalTime[0].ToString().Replace($@"{hours}", "");
            var strMin = totalTime[1].ToString().Replace($@"{minuts}", "");
            var dateDiffrence = DateTime.Parse(DlvEnglish_dateTimePicker.Text) - DateTime.Parse(English_dateTimePicker.Text);
            var diffDays = Decimal.Parse(dateDiffrence.Days.ToString());
            if(diffDays < 0)
            {
                MessageBox.Show("Delivery date cannot be before order date.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            var totalDelvHrs = ((diffDays) * 24) * 60;

            var hrs = Decimal.Parse(strHrs);
            var min = Decimal.Parse(strMin);
            if (hrs > 0) hrs = hrs * 60;
            var totalMins = hrs + min;

            if (totalMins > totalDelvHrs)
            {
                MessageBox.Show("Expexted delivery time is more than delivery date.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            else return 1;
        }

        private void escFunction(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Escape)
            {
                if (string.IsNullOrEmpty(TxtCompanyName.Text.Trim()))
                {
                    if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("Are you sure to Clear...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    MouseBtn = 1;
                    refreshToolStripMenuItem.PerformClick();
                    //clear();
                    //btn_sendtoGrid.Enabled = false;
                }
            }
        }
        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
            escFunction(sender, e);
        }
        private void GlobalDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
            escFunction(sender, e);
        }

        private void English_dateTimePicker_Leave(object sender, EventArgs e)
        {
            if (Global.checkDate && English_dateTimePicker.Focused == true)
            {
                var date = Convert.ToDateTime(DateTime.Parse(English_dateTimePicker.Text).ToShortDateString());
                var dateNow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                if (date > dateNow)
                {
                    MessageBox.Show("Careful you have selected Future date", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //English_dateTimePicker.Focus();
                }
                else if (date < dateNow)
                {
                    MessageBox.Show("Careful you have selected Previous date", "Careful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //English_dateTimePicker.Focus();
                }
            }
            GetMiti();
        }

        private void GetMiti()
        {
            txtMiti.Text = mainMaster.GetMiti(English_dateTimePicker.Text);
            txtDlvMiti.Text = mainMaster.GetMiti(DlvEnglish_dateTimePicker.Text);
            //if (English_dateTimePicker.Focused == true) txtMiti.Text = mainMaster.GetMiti(English_dateTimePicker.Text);
            //else if (DlvEnglish_dateTimePicker.Focused == true) txtDlvMiti.Text = mainMaster.GetMiti(DlvEnglish_dateTimePicker.Text);
            //else
            //{
            //    MessageBox.Show("Date or Delivery date not selected properly", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private void TxtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_CustomerEntry(true);
                frm.ShowDialog();
                CustoID = frm.custoid;
                TxtCompanyName.Text = frm.companyName;
                txtCompanyAddress.Text = frm.address;
            }
            if (e.KeyCode is Keys.F1 && ToPerform == "Insert") Btn_CustoSearch.PerformClick();
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_ProductEntry(true);
                frm.ShowDialog();
                ProdID = frm.ProdID;
                txtProductName.Text = frm.Prod_Name;
                lbl_ProductID.Text = frm.ProdID.ToString();
                lblPShortname.Text = frm.Prod_Code;
                lbl_Barcode.Text = frm.Prod_BCode;
                txt_Quantity.Text = frm.Qnty;
                txtUnit.Text = frm.Unit;

            }
            if (e.KeyCode is Keys.F1 && txtProductName.ReadOnly is true) btn_Product_Search.PerformClick();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //var frm = new frmSimulSoft();
            //frm.BtnPrintCall_Click(sender, e);
            FormStatus(false, false);
            ProddataGridView.Enabled = false;
            txtVoucherNum.Enabled = btn_order_VoucherSearch.Enabled = true;
            if (txtVoucherNum.Text.Trim() == "")
            {
                ToPerform = "Update";
                fromPrint = true;
                btn_order_VoucherSearch.PerformClick();
            }
            //Print
            else if (ToPerform != "Delete" && !string.IsNullOrEmpty(txtVoucherNum.Text.Trim()))
            {
                var printData = new
                {
                    VoucherNum = txtVoucherNum.Text,
                    Miti = txtMiti.Text,
                    DlvMiti = txtDlvMiti.Text,
                    partyCompanyName = TxtCompanyName.Text,
                    partyCompanyAddress = txtCompanyAddress.Text,

                    //,                    for (int j = 0; j < ProddataGridView.Rows.Count; j++)
                    //                    {
                    //                        Items=ProddataGridView.Rows[j].Cells[4].Value.ToString();                   
                    //                        ProductCode=ProddataGridView.Rows[j].Cells[2].Value.ToString();                   
                    //                        Quantity=ProddataGridView.Rows[j].Cells[5].Value.ToString();                   
                    //                        ESTTimeUnit=ProddataGridView.Rows[j].Cells[7].Value.ToString();
                    //                        ESTTotalTime=ProddataGridView.Rows[j].Cells[8].Value.ToString();
                    //                    }


                    EstTime = lblEstTime.Text,
                    Note = txt_Note.Text
                };
                //report.PrintCall(printData);
                //printPreviewDialog.Document = printDocument;
                //DialogResult result = printPreviewDialog.ShowDialog();
                //if (result == DialogResult.OK) printDocument.Print();
            }
        }
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument.DocumentName = $@"{txtVoucherNum.Text}";
            StringFormat center = new StringFormat();
            center.LineAlignment = StringAlignment.Center;
            center.Alignment = StringAlignment.Center;
            const int X = 50, Y = 100;
            e.Graphics.DrawString($@"{Global.CompanyName}", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(425, 40), center);
            e.Graphics.DrawString($@"{Global.Address}, {Global.City}, {Global.State}, {Global.Country}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 60), center);
            e.Graphics.DrawString($@"Comp. Reg:-{Global.Registration}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(425, 75), center);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 90.0F), new PointF(850.0F, 90.0F)); //Ref line:- https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
            e.Graphics.DrawString($@"OR-BILL-No.:- {txtVoucherNum.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 10));
            e.Graphics.DrawString($@"Order Date:- {txtMiti.Text}  ({txtMiti.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 10));
            e.Graphics.DrawString($@"Delivery Date:- {txtDlvMiti.Text}  ({DlvEnglish_dateTimePicker.Text})", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 25));
            e.Graphics.DrawString($@"Party Name:- {TxtCompanyName.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 40));
            e.Graphics.DrawString($@"Address:- {txtCompanyAddress.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 55));
            //e.Graphics.DrawString($@"Contact:- {txtPContactnum.Text}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X, Y + 80));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 200.0F), new PointF(850.0F, 200.0F));
            e.Graphics.DrawString($@"SNO.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 105));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F), new PointF(850.0F, 220.0F));
            e.Graphics.DrawString($@"Items", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 50, Y + 105));
            e.Graphics.DrawString($@"Product Code", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 105));
            e.Graphics.DrawString($@"Quantity", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 350, Y + 105));
            e.Graphics.DrawString($@"EST Time/Unit", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 450, Y + 105));
            e.Graphics.DrawString($@"EST Total Time", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 550, Y + 105));
            int i = 5;
            int index = 0;
            for (int j = 0; j < ProddataGridView.Rows.Count; j++)
            {
                i += 15;
                e.Graphics.DrawString($@"{index += 1}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 8, Y + 105 + i));
                var prodName = ProddataGridView.Rows[j].Cells[4].Value.ToString();
                e.Graphics.DrawString(prodName.Length < 24 ? $@"{ProddataGridView.Rows[j].Cells[4].Value.ToString()}" : $@"{ (ProddataGridView.Rows[j].Cells[4].Value.ToString()).Substring(0, 24)}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 50, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[2].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 252, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[5].Value} {ProddataGridView.Rows[j].Cells[6].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 350, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[7].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 450, Y + 105 + i));
                e.Graphics.DrawString($@"{ProddataGridView.Rows[j].Cells[8].Value}", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Point(X + 550, Y + 105 + i));
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 220.0F + i), new PointF(850.0F, 220.0F + i));
            e.Graphics.DrawString($@"Total Hrs :-", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 480, Y + 125 + i));
            e.Graphics.DrawString($@"{lblEstTime.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 550, Y + 125 + i));
            e.Graphics.DrawString($@"Note :- {txt_Note.Text}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 150 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 270.0F + i), new PointF(850.0F, 270.0F + i));
            e.Graphics.DrawString($@"Signature:- {Global.UserName}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X, Y + 180 + i));
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new PointF(00.0F, 300.0F + i), new PointF(850.0F, 300.0F + i));
            e.Graphics.DrawString($@"{Global.billMessage}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 250, Y + 180 + i));
            e.Graphics.DrawString($@"{Global.copyrightYear}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(X + 575, Y + 180 + i));
        }

        private void reloadEventFunction(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                clear();
                //frmOrderCard_Load(sender, e);
                //FormStatus(true, false);
            }
            else  // else case is for the button on the form
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
                //frmOrderCard_Load(sender, e);
                //FormStatus(true, false);
            }
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }
    #endregion
    }
}
