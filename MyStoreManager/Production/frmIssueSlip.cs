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
using System.Windows.Forms;

namespace MyStoreManager.Production
{
    public partial class frmIssueSlip : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
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
        private int OID,oldOID;
        private int OldCreatorUserID;
        private DateTime OldCreatedDate;
        private string isDeleted = string.Empty; //by default it is false
        private string ICVNUM, OVNUM, oldOVNUM = string.Empty;
        private int assigneeId;
        private int OldloginID;
        private int ICID;
        private int currentColumn;
        private string orderStatus = string.Empty;
        private bool fromPrint = false;
        private decimal invData; // to check inventory value before returning the good
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frmIssueSlip()
        {
            InitializeComponent();
            OrderDataGridColumns();
            DataGridColumns();
        }

        private void frmIssueSlip_Load(object sender, EventArgs e)
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
            CustoID = 0;
            VoucherNum = 0; //string for voucher number
            unitID = 0; //Unit ID // uitlized in grid
            MouseBtn = 0; //mouse button status holder
            Search = string.Empty;
            DateOf = string.Empty;
            OID = 0;
            oldOID = 0;
            ICID = 0;
            isDeleted = string.Empty;
            ICVNUM = string.Empty;
            OVNUM = string.Empty;
            oldOVNUM = string.Empty;
            OldloginID = 0;
            lbl_status.Text = "";
            txtVoucherNum.Clear();
            txtOrderVoucherNum.Clear();
            txtAssigneeName.Clear();
            English_dateTimePicker.ResetText();
            txtMiti.Clear();
            TxtCompanyName.Clear();
            DlvEnglish_dateTimePicker.ResetText();
            OrderProddataGridView.Rows.Clear();
            ProddataGridView.Rows.Clear();
            txt_Note.Clear();
            orderStatus = string.Empty;
            DlvEnglish_dateTimePicker.Text = txtDlvMiti.Text = lblEstTime.Text = string.Empty;
            //ProddataGridView.DefaultCellStyle.ForeColor = Color.Black;
            VoucherNum = 0; //string for voucher number

            MouseBtn = 0; //mouse button status holder
            Search = string.Empty;
            DateOf = string.Empty;
            OldCreatorUserID = 0;
            isDeleted = string.Empty; //by default it is false
            assigneeId = 0;
            OldloginID = 0;
            orderStatus = string.Empty;
            fromPrint = false;
        //imp
        //txt_ESTTimePHrs.Format = DateTimePickerFormat.Custom;
        //txt_ESTTimePHrs.CustomFormat = "HH:mm";
            ProductEntryClear();
            FormStatus(true, false);
        }

        public void OrderDataGridColumns()
        {
            OrderProddataGridView.ColumnCount = 9;
            OrderProddataGridView.Columns[0].Name = "SNO";
            OrderProddataGridView.Columns[1].Name = "PID";
            OrderProddataGridView.Columns[2].Name = "Short Name";
            OrderProddataGridView.Columns[3].Name = "BarCode";
            OrderProddataGridView.Columns[4].Name = "Product";
            OrderProddataGridView.Columns[5].Name = "Quantity";
            OrderProddataGridView.Columns[6].Name = "Unit";
            OrderProddataGridView.Columns[7].Name = "EST Time/Unit";
            OrderProddataGridView.Columns[8].Name = "EST Total Time";

            //Autosize
            OrderProddataGridView.Columns[0].Width = 40;
            OrderProddataGridView.Columns[1].Visible = false;
            OrderProddataGridView.Columns[2].Width = 100;
            OrderProddataGridView.Columns[3].Visible = false;
            OrderProddataGridView.Columns[4].Width = 215;
            OrderProddataGridView.Columns[5].Width = 60;
            OrderProddataGridView.Columns[6].Width = 70;
            OrderProddataGridView.Columns[7].Width = 150;
            OrderProddataGridView.Columns[8].Width = 150;
        }

        public void DataGridColumns()
        {
            ProddataGridView.ColumnCount = 7;
            ProddataGridView.Columns[0].Name = "SNO";
            ProddataGridView.Columns[1].Name = "PID";
            ProddataGridView.Columns[2].Name = "Short Name";
            ProddataGridView.Columns[3].Name = "BarCode";
            ProddataGridView.Columns[4].Name = "Product";
            ProddataGridView.Columns[5].Name = "Quantity";
            ProddataGridView.Columns[6].Name = "Unit";

            //Autosize
            ProddataGridView.Columns[0].Width = 40;
            ProddataGridView.Columns[1].Visible = false;
            ProddataGridView.Columns[2].Width = 100;
            ProddataGridView.Columns[3].Visible = false;
            ProddataGridView.Columns[4].Width = 215;
            ProddataGridView.Columns[5].Width = 60;
            ProddataGridView.Columns[6].Width = 150;
        }

        private void FormStatus(bool btn, bool txt)
        {
            btn_New.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
            //buttons bellow will enable with the text enable
            btnAssigneeName.Enabled=txtAssigneeName.Enabled=btnOrderTicket.Enabled = txtOrderVoucherNum.Enabled = txtVoucherNum.Enabled = English_dateTimePicker.Enabled = txtMiti.Enabled = TxtCompanyName.Enabled = txtProductName.Enabled = txt_Quantity.Enabled = txtUnit.Enabled = DlvEnglish_dateTimePicker.Enabled = txtDlvMiti.Enabled = txt_Note.Enabled = txt;
            btn_order_VoucherSearch.Enabled = OrderProddataGridView.Enabled = ProddataGridView.Enabled = Btn_Ok.Enabled = btn_ProductClear.Enabled = Btn_Product_Insert.Enabled = Btn_CustoSearch.Enabled = btn_Product_Search.Enabled = txt;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            Btn_Ok.Text = "&Save";
            VoucherNumber(); // Just to be sure
            FormStatus(false, true);
            English_dateTimePicker.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
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

        private void btn_order_VoucherSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Update" || ToPerform == "Delete")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "IssueCard", 0, "InProcess", 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        ICID = Int32.Parse(popup.SelectedRow[0]["ICID"].ToString());
                        txtVoucherNum.Text = ICVNUM = popup.SelectedRow[0]["ICVNUM"].ToString();
                        oldOID = OID = Int32.Parse(popup.SelectedRow[0]["OID"].ToString());
                        txtOrderVoucherNum.Text = oldOVNUM = OVNUM = popup.SelectedRow[0]["OVNUM"].ToString();
                        //if(ToPerform == "Update")
                        //{
                        //    oldOID = Int32.Parse(popup.SelectedRow[0]["OID"].ToString());
                        //    oldOVNUM = popup.SelectedRow[0]["OVNUM"].ToString();
                        //}
                        English_dateTimePicker.Value = DateTime.Parse(popup.SelectedRow[0]["Issue_Date"].ToString());
                        txtMiti.Text = popup.SelectedRow[0]["Issue_Miti"].ToString();
                        DlvEnglish_dateTimePicker.Text = (DateTime.Parse(popup.SelectedRow[0]["Delivery_Date"].ToString()).Date).ToString("d");
                        txtDlvMiti.Text = popup.SelectedRow[0]["Delivery_Miti"].ToString();
                        OldloginID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        lbl_Person.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                        lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                        lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                        lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                        CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                        TxtCompanyName.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                        assigneeId = Int32.Parse(popup.SelectedRow[0]["AssigneeId"].ToString());
                        txtAssigneeName.Text = popup.SelectedRow[0]["Assignee_Name"].ToString();
                        txt_Note.Text = popup.SelectedRow[0]["Note"].ToString();
                        lblEstTime.Text = popup.SelectedRow[0]["Est_Time"].ToString();
                        OldCreatorUserID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        isDeleted = popup.SelectedRow[0]["is_Deleted"].ToString();
                        OldCreatedDate = Convert.ToDateTime(popup.SelectedRow[0]["DateCreated"].ToString());
                        lbl_status.Text = orderStatus = popup.SelectedRow[0]["OrderStatus"].ToString();

                        var ods = mainMaster.GetOrderTicketDetails(OVNUM);
                        if (ods.Tables.Count > 0)
                        {
                            OrderProddataGridView.Rows.Clear();
                            foreach (DataRow dgv in ods.Tables[0].Rows)
                            {
                                var rows = OrderProddataGridView.Rows.Count;
                                OrderProddataGridView.Rows.Add();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                var qnty = Decimal.Parse(dgv["Quantiy"].ToString());
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Quantity"].Value = qnty == 0 ? "0.00" : qnty.ToString("##.##########");
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["EST Time/Unit"].Value = dgv["EST_HrsPerUnit"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["EST Total Time"].Value = dgv["TotalEST_HrsPerUnit"].ToString();
                                OrderProddataGridView.CurrentCell = OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            OrderProddataGridView.ClearSelection();
                        }

                        var ds = mainMaster.GetIssueCardDetails(ICVNUM);
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
                                ProddataGridView.CurrentCell = ProddataGridView.Rows[ProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                            ProddataGridView.ClearSelection();
                            if (ToPerform == "Update")
                            {
                                FormStatus(false, true);
                            }
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
                        if (orderStatus != "InProcess") FormStatus(false, false); //if order ticket is in process it is not allowed to edit or delete.
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

        private void btn_Product_Search_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductSelect", 1, "PR01", 0);
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
                }
                txtProductName.Focus();
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_CustoSearch_Click(object sender, EventArgs e)
        {
            if (ToPerform != string.Empty && OID == 0)
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "CustomerSelect", 1, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        CustoID = Int32.Parse(popup.SelectedRow[0]["CID"].ToString());
                        TxtCompanyName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }
        private void TxtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) Btn_CustoSearch.PerformClick();  //custompany and company are the same
        }

        private void btnOrderTicket_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Insert" || ToPerform == "Update")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "OrderTicket", 1, "Pending", 0); // Active status is used one to short value
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        OID = Int32.Parse(popup.SelectedRow[0]["OID"].ToString());
                        txtOrderVoucherNum.Text = OVNUM = popup.SelectedRow[0]["OVNUM"].ToString();
                        DlvEnglish_dateTimePicker.Text = (DateTime.Parse(popup.SelectedRow[0]["Order_Date"].ToString()).Date).ToString("d"); ;
                        txtDlvMiti.Text = popup.SelectedRow[0]["Order_Miti"].ToString();
                        OldloginID = Int32.Parse(popup.SelectedRow[0]["UserID"].ToString());
                        lbl_Person.Text = popup.SelectedRow[0]["Entered_By"].ToString();
                        lbl_CompanyName.Text = popup.SelectedRow[0]["Dup_cname"].ToString();
                        lbl_Address.Text = popup.SelectedRow[0]["Dup_address"].ToString();
                        lbl_Phone.Text = popup.SelectedRow[0]["Dup_contact"].ToString();
                        CustoID = Int32.Parse(popup.SelectedRow[0]["SenderID"].ToString());
                        TxtCompanyName.Text = popup.SelectedRow[0]["PartyName"].ToString();
                        lblEstTime.Text = popup.SelectedRow[0]["Est_Time"].ToString();
                        lbl_status.Text = orderStatus = popup.SelectedRow[0]["OrderStatus"].ToString();
                        var ds = mainMaster.GetOrderTicketDetails(OVNUM);
                        if (ds.Tables.Count > 0)
                        {
                            OrderProddataGridView.Rows.Clear();
                            foreach (DataRow dgv in ds.Tables[0].Rows)
                            {
                                var rows = OrderProddataGridView.Rows.Count;
                                OrderProddataGridView.Rows.Add();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["PID"].Value = dgv["PID"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Short Name"].Value = dgv["PCode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["BarCode"].Value = dgv["PBarcode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Product"].Value = dgv["PName"].ToString();
                                var qnty = Decimal.Parse(dgv["Quantiy"].ToString());
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Quantity"].Value = qnty == 0 ? "0.00" : qnty.ToString("##.##########");
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["Unit"].Value = dgv["UnitCode"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["EST Time/Unit"].Value = dgv["EST_HrsPerUnit"].ToString();
                                OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells["EST Total Time"].Value = dgv["TotalEST_HrsPerUnit"].ToString();
                                OrderProddataGridView.CurrentCell = OrderProddataGridView.Rows[OrderProddataGridView.RowCount - 1].Cells[currentColumn];
                            }
                        }
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

        private void btnAssigneeName_Click(object sender, EventArgs e)
        {
            if (ToPerform == "Insert" || ToPerform == "Update")
            {
                var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "UserMaster", 0, string.Empty, 0);
                if (frm_PopUpSearch.dt.Rows.Count > 0)
                {
                    popup.ShowDialog();
                    if (popup.SelectedRow.Count > 0)
                    {
                        assigneeId = (int)popup.SelectedRow[0]["userid"];
                        txtAssigneeName.Text = popup.SelectedRow[0]["usrname"].ToString();
                    }
                }
            }
        }

        private void OrderProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            OrderProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void ProddataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ProddataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
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

        #region------------------------Methods----------------------------
        private void GetMiti()
        {
            txtMiti.Text = mainMaster.GetMiti(English_dateTimePicker.Text);
        }

        private void txtVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) btn_order_VoucherSearch.PerformClick();
        }

        private void txtOrderVoucherNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) btnOrderTicket.PerformClick();
        }

        private void txtAssigneeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) btnAssigneeName.PerformClick();
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.F1 && ToPerform != string.Empty) btn_Product_Search.PerformClick();
        }

        public int checkInventoryErr()
        {
            if (ProdID <= 0) return 1;
            else
            {
                invData = ClsMainMaster.getInvData(ProdID);

                if (Convert.ToDecimal(txt_Quantity.Text.ToString()) > invData)
                {
                    MessageBox.Show("Your selected amount crocess stock linit." + "\n" + $@"Current Quantity {invData} ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
                else return 0;
            }
        }

        private void Btn_Product_Insert_Click(object sender, EventArgs e)
        {
            if (ProdID > 0)
            {
                if (ProdID == 0 && ProddataGridView.RowCount > 0) return;
                else if (checkInventoryErr() == 1)
                {
                    txt_Quantity.Focus();
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
                            AddRow(Sno, lbl_ProductID.Text, lblPShortname.Text, lbl_Barcode.Text, txtProductName.Text, txt_Quantity.Text, txtUnit.Text);
                            ProductEntryClear();
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

        private void AddRow(string Sno, string PID, string ShortName, string BarCode, string Pname, string quantity, string unit)
        {
            string[] rows = { Sno, PID, ShortName, BarCode, Pname, quantity, unit };
            ProddataGridView.Rows.Add(rows);
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
        }

        private void btn_ProductClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Reload product details.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ProductEntryClear();
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            reloadEventFunction(sender, e);
            MouseBtn = 0;
        }

        private void viewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var popup = new frm_PopUpSearch(0, string.Empty, Global.InitialCatalogMain, "ProductInventory", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0) popup.ShowDialog();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
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
                    var rowIndex = ProddataGridView.CurrentCell.RowIndex;
                    ProddataGridView.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private void txtVoucherNum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

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
            if (string.IsNullOrWhiteSpace(txtAssigneeName.Text.Trim()))
            {
                MessageBox.Show("You must Enter Supplier Assignee Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //errorProvider.SetError(txtCname, "Please enter Company name.");
                txtAssigneeName.Focus();
                return false;
            }
            else return true;
        }

        public async Task<int> IssueCardSave()
        {
            mainMaster.IC_Master.ToPerform = ToPerform;
            mainMaster.IC_Master.ICID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.IssueCardMaster", "ICID") : ICID;
            mainMaster.IC_Master.ICVNUM = txtVoucherNum.Text.Trim().Replace("'", "''");
            mainMaster.IC_Master.Issue_Date = English_dateTimePicker.Value;
            mainMaster.IC_Master.Issue_Miti = txtMiti.Text.Trim().Replace("'", "''");
            mainMaster.IC_Master.Delivery_Date = DateTime.Parse(DlvEnglish_dateTimePicker.Text);
            mainMaster.IC_Master.Delivery_Miti = txtDlvMiti.Text.Trim().Replace("'", "''");
            mainMaster.IC_Master.OID = OID;
            mainMaster.IC_Master.OVNUM = txtOrderVoucherNum.Text;
            if(ToPerform == "Update" || ToPerform == "Delete")
            {
                mainMaster.IC_Master.oldOID = oldOID;
                mainMaster.IC_Master.oldOVNUM = oldOVNUM;
            }
            mainMaster.IC_Master.SenderID = (int)Global.CompanyID;
            mainMaster.IC_Master.BuyerID = CustoID;
            mainMaster.IC_Master.AssigneeId = assigneeId;
            mainMaster.IC_Master.Est_Time = lblEstTime.Text;
            mainMaster.IC_Master.Note = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.IC_Master.OrderStatus = "InProcess";
            if(isDeleted == "Yes") { mainMaster.IC_Master.check_is_Deleted = true; }
            mainMaster.IC_Master.is_Deleted = false;
            mainMaster.IC_Master.UserID = Global.LoginID;
            mainMaster.IC_Details.ToPerform = ToPerform;
            mainMaster.IC_Details.ICID = mainMaster.OT_Master.OID;
            mainMaster.IC_Details.ICVNUM = mainMaster.OT_Master.OVNUM;
            mainMaster.IC_Details.GetGridViewData = ProddataGridView;
            return await Task.Run(() => mainMaster.GetIssueCardSetup());
        }

        private async void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToPerform is null) return;
                msg = ToPerform == "Insert" ? "Save" : ToPerform;
                if (FormIsOK())
                {
                    //progress bar implememtation starts
                    PleaseWait.Show();
                    if (await IssueCardSave() != 0)
                    {
                        PleaseWait.Close();
                        MessageBox.Show($@"{msg}d Sucessfully...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                        if (Global.printMessage is true) if (MessageBox.Show("Do you want to print this?", "Print Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) btnPrint.PerformClick();
                        if (Global.autoPrint is true) btnPrint.PerformClick();
                        frmIssueSlip_Load(sender, e);
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

        protected void VoucherNumber()
        {
            if (ToPerform == "Insert")
            {
                VoucherNum = ClsMainMaster.getInt("MSM.IssueCardMaster", "ICID");
                if (VoucherNum.ToString().Length == 1) txtVoucherNum.Text = "IC-" + $"{Global.Year}" + "-" + "00" + VoucherNum;
                else if (VoucherNum.ToString().Length == 2) txtVoucherNum.Text = "IC-" + $"{Global.Year}" + "-" + "0" + VoucherNum;
                else txtVoucherNum.Text = "IC-" + $"{Global.Year}" + "-" + VoucherNum;
            }
        }
    #endregion
    }
}
