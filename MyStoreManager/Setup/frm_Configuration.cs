using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Setup
{
    public partial class frm_Configuration : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        public int YearId = 0;
        public int CID;
        public string Year = string.Empty;
        public string AdminValue = string.Empty;
        public string ToPerform = string.Empty;
        public string IsAdmin=string.Empty;
        public int ColorID = 0;
        //public string BkGroundColor = string.Empty;

        public static int ID = 0;
        public string TableName = "MSM.Configuration";
        public string DbName = Global.InitialCatalogMain;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frm_Configuration()
        {
            InitializeComponent();
            ConfigInitials();
        }
        

        public void ConfigInitials()
        {
            var Configdt = mainMaster.checkConfig();
            var Backgrounddt = mainMaster.getUserLogin(Global.LoginUser, string.Empty,1);
            if (Configdt.Rows.Count == 1)
            {
                ToPerform = "Update";
                FormStatus(true);
                //configuration part
                CID = Int32.Parse(Configdt.Rows[0]["CID"].ToString());
                YearId = Int32.Parse(Configdt.Rows[0]["YearID"].ToString());
                cmb_FiscalYear.Text= Year = Configdt.Rows[0]["CurrentYear"].ToString();
                var VATstring = Configdt.Rows[0]["VAT"].ToString();
                var VAT = VATstring == "" ? decimal.Parse("0") : decimal.Parse(VATstring);
                txtVAT.Text = VAT == 0 ? "0.00" : VAT.ToString("##.##########");

                var DISstring = Configdt.Rows[0]["Discount"].ToString();
                var Discount = DISstring==""? decimal.Parse("0"): decimal.Parse(DISstring);
                txtDiscount.Text = Discount == 0 ? "0.00" : Discount.ToString("##.##########");

                chk_DateTime_Check.Checked = Convert.ToBoolean(Configdt.Rows[0]["checkDate"]);
                chkNotes.Checked = Convert.ToBoolean(Configdt.Rows[0]["notes"]);
                chkReturnNotes.Checked = Convert.ToBoolean(Configdt.Rows[0]["returnNotes"]);

                chkPrintMessage.Checked = Convert.ToBoolean(Configdt.Rows[0]["printMessage"]);
                chkAutoPrint.Checked = Convert.ToBoolean(Configdt.Rows[0]["autoPrint"]);
                cmbCompType.SelectedIndex = int.Parse(Configdt.Rows[0]["compType"].ToString());
                if (Global.purchaseCheck > 0 || Global.salesCheck > 0) cmbCompType.Enabled = false;
                txtBillMsg.Text = Configdt.Rows[0]["billMsg"].ToString();
                //User part
                var Background = mainMaster.getUserLogin(Global.LoginUser, string.Empty, 1);
                if (Backgrounddt.Rows.Count>0)
                {
                    chk_IsAdmin.Checked = Convert.ToBoolean(Background.Rows[0]["IsAdmin"]);
                    ColorID = Int32.Parse(Background.Rows[0]["ColorID"].ToString());
                    cmb_Color.Text = Background.Rows[0]["Background"].ToString();
                }
            }
            else if (Configdt.Rows.Count == 0 || Configdt.Rows.Count > 0)
            {
                MessageBox.Show("Error with Configuration Contact Support", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CbmLoad()
        {
            cmb_FiscalYear.DataSource = mainMaster.Get_FiscalYear();
            cmb_FiscalYear.ValueMember = "YearDesc";
            if (cmb_FiscalYear.Items.Count > 0) cmb_FiscalYear.SelectedIndex = YearId - 1 ;
        }

        private void BackgroundColor()
        {
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.cmb_Color.Items.Add(c.Name);
            }
            //cmb_Color_DrawItem(sender,e);
            if (cmb_Color.Items.Count > 0) cmb_Color.SelectedIndex = ColorID;
        }

        private void cmb_Color_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Verdana", 10, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }
        }
        public void FormStatus(bool txt)
        {
            cmb_FiscalYear.Enabled = Btn_Ok.Enabled= chk_IsAdmin.Enabled = txt;
        }

        private void frm_Configuration_Load(object sender, EventArgs e)
        {
            CbmLoad();
            BackgroundColor();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            FormStatus(true);
            CbmLoad();
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private bool FormIsOK()
        {
            if (string.IsNullOrWhiteSpace(cmb_FiscalYear.Text.Trim()))
            {
                MessageBox.Show("You must Enter Company Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_FiscalYear.Focus();
                return false;
            }

            if (YearId == 0)
            {
                MessageBox.Show("Year id is not set properly.. Contact System Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_FiscalYear.Focus();
                return false;
            }

            if(YearId != Global.YearID)
            {
                MessageBox.Show("Current year id cannot be changed.. Contact System Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_FiscalYear.Focus();
                return false;
            }
            else return true;
        }

        public async Task<int> ConfigurationSetup()
        {
            if (ToPerform is null) return 0;
            mainMaster.Config.CID = ToPerform is "Insert" ? Int32.Parse(ClsMainMaster.getInt("MSM.Configuration", "CID").ToString()) : CID;
            mainMaster.Config.ToPerform = ToPerform;
            mainMaster.Config.YearID = YearId;
            mainMaster.Config.Current_Year = cmb_FiscalYear.Text;
            mainMaster.Config.IsAdmin = chk_IsAdmin.Checked;
            mainMaster.Config.ColorID = cmb_Color.SelectedIndex;       //These values are being saved in User master
            mainMaster.Config.Background = cmb_Color.Text;              //These values are being saved in User master
            mainMaster.Config.VAT = !string.IsNullOrEmpty(txtVAT.Text) ?  decimal.Parse(txtVAT.Text.Trim().Replace("'", "''")) : decimal.Parse("0.00");
            mainMaster.Config.Discount = !string.IsNullOrEmpty(txtDiscount.Text) ? decimal.Parse(txtDiscount.Text.Trim().Replace("'", "''")) : decimal.Parse("0.00") ;
            mainMaster.Config.checkDate = chk_DateTime_Check.Checked;
            mainMaster.Config.notes = chkNotes.Checked;
            mainMaster.Config.returnNotes = chkReturnNotes.Checked;
            mainMaster.Config.printMessage = chkPrintMessage.Checked;
            mainMaster.Config.autoPrint = chkAutoPrint.Checked;
            mainMaster.Config.compType = cmbCompType.SelectedIndex;
            mainMaster.Config.billMsg = txtBillMsg.Text.Trim().Replace("'", "''");
            return await Task.Run(()=> mainMaster.ConfigurationSetup()) ;             
        }

        private void updateGlobal()
        {
            var initials = mainMaster.checkConfig();
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
            Global.checkDate = Convert.ToBoolean(initials.Rows[0]["checkDate"]);
            Global.checkNote = Convert.ToBoolean(initials.Rows[0]["notes"]);
            Global.checkReturnNote = Convert.ToBoolean(initials.Rows[0]["returnNotes"]); //, 
            Global.printMessage = Convert.ToBoolean(initials.Rows[0]["printMessage"]);
            Global.autoPrint = Convert.ToBoolean(initials.Rows[0]["autoPrint"]);
        }

       
        private async void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ToPerform)) return;
            var dt = mainMaster.GetID("YearID", "FiscalYear", "YearDesc", $@"{cmb_FiscalYear.Text}");
            YearId = Int32.Parse(dt.Rows[0]["YearID"].ToString());
            if(FormIsOK())
            {
                PleaseWait.Show();
                if (await ConfigurationSetup()!=0)
                {
                    FormStatus(true);
                    CbmLoad();
                    updateGlobal();
                    var AdminPermit = mainMaster.getUserLogin(Global.LoginUser, string.Empty, 1);
                    IsAdmin = AdminPermit.Rows[0]["IsAdmin"].ToString();
                    if (IsAdmin == "True") Global.IsAdmin = Global.CurrentSession = 1;
                    else Global.IsAdmin = Global.CurrentSession = 0;
                    PleaseWait.Close();
                    MessageBox.Show($@"Configuration {ToPerform} sucessfully Done...!!.", "Done..!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"Configuration {ToPerform} Failed, Contact Support...!!.", "Error..!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmb_FiscalYear.Focus();
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = mainMaster.BackgroundColor();
            //panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void chkPrintMessage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintMessage.Checked) chkAutoPrint.Checked = false;
            else chkAutoPrint.Checked = true;
        }

        private void chkAutoPrint_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutoPrint.Checked) chkPrintMessage.Checked = false;
        }
    }
}
