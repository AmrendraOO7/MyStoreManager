using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using MyStoreManager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.PreEntry
{
    public partial class frm_CustomerEntry : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        private int CustoID = 0;
        public string ToPerform = string.Empty;
        public string UnitCode = string.Empty;
        public string TableName = "master.ComboBoxVal";
        public string DbName = Global.InitialCatalogMaster;
        public int MouseBtn = 0;
        private readonly bool _NewEntry;

        public int custoid;
        public string CustoName = string.Empty;
        public string companyName = string.Empty;
        public string address = string.Empty;
        public string contact = string.Empty;
        public string note = string.Empty;
        public frm_CustomerEntry(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }

        private void frm_CustomerEntry_Load(object sender, EventArgs e)
        {
            clear();
            lbl_TagStatus.Text = $"Copyright@ MSM_{DateTime.Today.ToString().Substring(5,4)}";
            //State_Country_Load();
            //ToPerform = "Insert";
            ToPerform = string.Empty;
            FormStatus(true, false);
            txt_Name.Focus();
            
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            panel.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);

            //lining not required now
            //Graphics VerticalLine = panel.CreateGraphics();
            //Graphics HorizontalLine1 = panel.CreateGraphics();
            //Graphics HorizontalLine2 = panel.CreateGraphics();
            //Graphics HorizontalLine3 = panel.CreateGraphics();
            //Brush White = new SolidBrush(Color.White);
            //Pen Whitepen = new Pen(White, 1);
            ////length,angle,pointPlace,line Depth
            //VerticalLine.DrawLine(Whitepen, 380, 00, 380, 1050);
            //HorizontalLine1.DrawLine(Whitepen, 1100, 90, 380, 90);
            //HorizontalLine2.DrawLine(Whitepen, 1100, 160, 380, 160);
            //HorizontalLine3.DrawLine(Whitepen, 1100, 485, 380, 485);
        }

        //public void State_Country_Load()
        //{
        //    cmb_State.DataSource = mainMaster.Get_State();
        //    cmb_State.ValueMember = "Name";
        //    if (cmb_State.Items.Count > 0) cmb_State.SelectedIndex = 0;

        //    cmb_Country.DataSource = mainMaster.Get_Country();
        //    cmb_Country.ValueMember = "Name";
        //    if (cmb_Country.Items.Count > 0) cmb_Country.SelectedIndex = 0;
        //}

       

        public void clear()
        {
            CustoID = 0;
            MouseBtn = 0;
            ToPerform = string.Empty;
            UnitCode = string.Empty;
            TableName = "[MSM].[CustomerMaster]";
            DbName = Global.InitialCatalogMain;
            txt_Name.Clear();
            txt_Code.Clear();
            txt_Email.Clear();
            txtCompany.Clear();
            txt_Address.Clear();
            txt_Contact.Clear();
            txt_Registration.Clear();
            txt_Note.Clear();
            listView.Items.Clear();
            ListviewLoad();
            txtreadonly(true);
        }

        private void txtreadonly(bool ReadOnly)
        {
            txtCompany.ReadOnly = txt_Name.ReadOnly = txt_Code.ReadOnly = txt_Email.ReadOnly = txt_Address.ReadOnly = txt_Contact.ReadOnly = txt_Registration.ReadOnly = txt_Note.ReadOnly  = ReadOnly;
        }
        public void FormStatus(bool btn, bool txt)
        {
            btn_Delete.Enabled = btn_Edit.Enabled = btn_Save.Enabled = btn;
            txtCompany.Enabled = txt_Name.Enabled = txt_Code.Enabled = txt_Email.Enabled = txt_Address.Enabled = txt_Contact.Enabled = txt_Registration.Enabled = txt_Note.Enabled = txt_Country.Enabled = txt_State.Enabled = btn_Search.Enabled = Btn_Ok.Enabled = txt;
        }

        public bool FormIsOK()
        {
            if (ToPerform != null)
            {
                if (MessageBox.Show($@"Are you sure to {ToPerform}...!!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Name.Text.Trim()))
            {
                MessageBox.Show("You must Enter Name", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Code.Text.Trim()))
            {
                MessageBox.Show("You must Enter Code", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Code.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Contact.Text.Trim()))
            {
                MessageBox.Show("You must Enter Contact", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Contact.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Registration.Text.Trim()))
            {
                MessageBox.Show("You must Enter Registration", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Registration.Focus();
                return false;
            }
            else return true;
        }

        public void ListviewLoad()
        {
            if(listView.Columns.Count ==0)
            {
                listView.Columns.Add("CUSTOMER NAME", 170, HorizontalAlignment.Center);
                listView.Columns.Add("CODE", 80, HorizontalAlignment.Center);
                listView.Columns.Add("REGISTRATION", 180, HorizontalAlignment.Center);
                listView.Columns.Add("STATUS", 80, HorizontalAlignment.Center);
                listView.View = View.Details;
            }
            var dt = ClsMainMaster.GetCustomer();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i]["PartyName"].ToString());
                item.SubItems.Add(dt.Rows[i]["PartyCode"].ToString());
                item.SubItems.Add(dt.Rows[i]["PartyReg"].ToString());
                item.SubItems.Add(dt.Rows[i]["ActiveStatus"].ToString());
                listView.Items.Add(item);
            }
        }

        public int CustomerSetup()
        {
            mainMaster.CustoMaster.ToPerform = ToPerform;
            CustoID = ToPerform is "Insert" ? ClsMainMaster.getInt("MSM.CustomerMaster", "CID") : CustoID;
            mainMaster.CustoMaster.CID = CustoID;
            mainMaster.CustoMaster.PartyName = txt_Name.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyCode = txt_Code.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyEmail = txt_Email.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyCompany = txtCompany.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyAddress = txt_Address.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyState = txt_State.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyCountry = txt_Country.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyContact = txt_Contact.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyReg = txt_Registration.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.PartyNote = txt_Note.Text.Trim().Replace("'", "''");
            mainMaster.CustoMaster.ActiveStatus = chk_Status.Checked;
            mainMaster.CustoMaster.UserID = Global.LoginID;
            return mainMaster.GetCustomerSetup();
        }

        private void txt_State_KeyDown(object sender, KeyEventArgs e)
        {
            if( ToPerform != "Delete" && e.KeyCode is Keys.F1)
            {
                getCountryorState();
            }
            if (e.Control is true && e.KeyCode is Keys.N)
            {
                var frm = new frm_Country_State(true);
                frm.ShowDialog();
                txt_Country.Text = frm.country;
                txt_State.Text = frm.state;
                return;
            }
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "Insert";
            FormStatus(false, true);
            txtreadonly(false);
            txt_Name.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtreadonly(true);
            txt_Name.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, true);
            txtreadonly(true);
            txt_Name.Focus();
        }

        private void txt_Name_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text.Trim()) && ToPerform is "Insert")
                txt_Code.Text = string.IsNullOrEmpty(txt_Code.Text.Trim().Replace("'", "''")) ?
                    ClsIncrement.AutoIncrement("PartyCode", txt_Name.Text.Trim().Replace("'", "''"))
                    : txt_Code.Text.Trim();
        }

        private void txt_Code_Validating(object sender, CancelEventArgs e)
        {
            if (UnitCode != txt_Code.Text.ToString())
            {
                var dt = mainMaster.CheckAvailability("MSM.CustomerMaster", "PartyCode", txt_Code.Text.Trim().Replace("'", "''"));
                if (dt == null || dt.Rows.Count <= 0) return;
                MessageBox.Show(@"Code Is Taken..!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Code.Focus();
            }
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }



        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if(MouseBtn == 1)
            {
                clear();
                FormStatus(true, false);
                //State_Country_Load();
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                clear();
                FormStatus(true, false);
                //State_Country_Load();
            }
                //ListviewLoad();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if(FormIsOK())
            {
                //progress bar implememtation starts
                
                
                if (CustomerSetup() != 0)
                {
                    if(_NewEntry == true)
                    {
                        custoid = CustoID;
                        CustoName = txt_Name.Text;
                        companyName = txtCompany.Text;
                        address = txt_Address.Text;
                        contact = txt_Contact.Text;
                        note = txt_Note.Text;
                        
                        Close();
                        return;
                    }
                    
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    clear();
                    FormStatus(true,false);
                }
                else
                {
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txt_Name.Focus();
                }
            }
        }

        public void getCountryorState()
        {
            var popup = new frm_PopUpSearch(0, TableName, DbName, "CountryOrStateList", 0, string.Empty, 0);
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txt_State.Text = popup.SelectedRow[0]["StateName"].ToString();
                    txt_Country.Text = popup.SelectedRow[0]["CountryName"].ToString();
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;

            if (ToPerform == "Update") txtreadonly(false);
            else if (ToPerform == "Delete") 
            {
                FormStatus(false, false);
                txt_Name.Enabled=Btn_Ok.Enabled = true;
                Btn_Ok.Focus();
            }

            if (ToPerform == "insert") return;
            var popup = new frm_PopUpSearch(CustoID, TableName, DbName, "CustomerSelect", 0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    CustoID= Int32.Parse(popup.SelectedRow[0]["CID"].ToString());
                    txt_Name.Text = popup.SelectedRow[0]["PartyName"].ToString();
                    txt_Code.Text = UnitCode = popup.SelectedRow[0]["PartyCode"].ToString();
                    txt_Email.Text = popup.SelectedRow[0]["PartyEmail"].ToString();
                    txtCompany.Text = popup.SelectedRow[0]["PartyCompany"].ToString();
                    txt_Address.Text = popup.SelectedRow[0]["PartyAddress"].ToString();
                    txt_State.Text = popup.SelectedRow[0]["PartyState"].ToString();
                    txt_Country.Text = popup.SelectedRow[0]["PartyCountry"].ToString();
                    txt_Contact.Text = popup.SelectedRow[0]["PartyContact"].ToString();
                    txt_Registration.Text = popup.SelectedRow[0]["PartyReg"].ToString();
                    txt_Note.Text = popup.SelectedRow[0]["PartyNote"].ToString();
                    var status = popup.SelectedRow[0]["ActiveStatus"].ToString();
                    if (status == "True") chk_Status.Checked = true;
                    else chk_Status.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {
            txt_Address.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_Address.Text);
            txt_Address.Select(txt_Address.TextLength, 0);
        }

        private void txt_Contact_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Contact.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only phone numbers.");
                txt_Contact.Text = txt_Contact.Text.Remove(txt_Contact.Text.Length - 1);
            }
           
        }

        

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Name.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txt_Name.Text);
            txt_Name.Select(txt_Name.TextLength, 0);
        }

        private void frm_CustomerEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Escape)
            {
                MouseBtn = 1;
                btn_Refresh_Click(sender, e);
            }
        }

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToPerform is "Update" || ToPerform is "Delete" && e.KeyCode is Keys.F1 && txt_Name.ReadOnly is true)
            {
                btn_Search.PerformClick();
            }
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            txtCompany.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.txtCompany.Text);
            txtCompany.Select(txtCompany.TextLength, 0);
        }
    }
}
