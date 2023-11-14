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

namespace MyStoreManager.Setup
{
    public partial class frm_Country_State : Form
    {
        # region Global
        private readonly IMainMaster MainMaster = new ClsMainMaster();
        public string ToPerform = string.Empty;
        public int ID = 0;
        public int MouseBtn = 0;
        public string TableName = "[dbo].[master.ComboBoxVal]";
        public string DbName = "master";
        private readonly bool _NewEntry;
        public string country, state = string.Empty;
        clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();

        public frm_Country_State(bool NewEntry)
        {
            InitializeComponent();
            _NewEntry = NewEntry;
        }
        #endregion

        #region Function(Method)
        public void Clear()
        {
            ToPerform = string.Empty;
            ID = 0;
            MouseBtn = 0;
            txtState.Clear();
            txtCountry.Clear();
            FormStatus(true,false);
        }

        public void FormStatus(bool btn = true,bool txt = false)
        {
            txtCountry.Enabled = txtState.Enabled = btn_Search.Enabled=Btn_Ok.Enabled = txt;
            btn_Save.Enabled = btn_Edit.Enabled = btn_Delete.Enabled = btn;
        }


        private bool FormIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtState.Text.Trim().Replace("'", "''")) && string.IsNullOrWhiteSpace(txtCountry.Text.Trim().Replace("'", "''")))
            {
                MessageBox.Show("Enter Value...!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }

        }

        public int ComboBoxValueTaskDone()
        {
            MainMaster.ComboInfo.ToPerform = ToPerform;
            MainMaster.ComboInfo.CbId = ID;
            MainMaster.ComboInfo.StateName = txtState.Text.Trim().Replace("'", "''");
            MainMaster.ComboInfo.Country = txtCountry.Text.Trim().Replace("'", "''");
            return MainMaster.ComboBoxValueTaskDone();
        }
        #endregion


        private void frm_Country_State_Load(object sender, EventArgs e)
        {
            Clear();
            FormStatus(true, false);
        }
        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
        }

      

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ToPerform = "insert";
            FormStatus(false, true);
            txtState.Focus();
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ToPerform = "Update";
            FormStatus(false, true);
            txtState.Focus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ToPerform = "Delete";
            FormStatus(false, false);
            btn_Search.Enabled = Btn_Ok.Enabled = true;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (MouseBtn == 1)
            {
                Clear();
                FormStatus(true, false);
            }
            else
            {
                if (MessageBox.Show("Are you sure to Refresh...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Clear();
                FormStatus(true, false);
               
            }
                     
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Close...!!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            else this.Close();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            if (ToPerform == "Insert") return;
            var popup = new frm_PopUpSearch(ID, TableName, DbName, "CountryOrStateList",0, string.Empty, 0);
            if (frm_PopUpSearch.dt.Rows.Count > 0)
            {
                popup.ShowDialog();
                if (popup.SelectedRow.Count > 0)
                {
                    txtState.Text = popup.SelectedRow[0]["StateName"].ToString();
                    txtCountry.Text = popup.SelectedRow[0]["CountryName"].ToString();
                    ID = (int)popup.SelectedRow[0]["ID"];
                }
            }
            else
            {
                MessageBox.Show("No Data..!!", "Stop..!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            if (FormIsValid() is true)
            {
                //progress bar implememtation starts

                PleaseWait.Show();
                if (ComboBoxValueTaskDone() != 0)
                {
                    if (_NewEntry == true)
                    {
                        country = txtCountry.Text.Trim().Replace("'","''");
                        state = txtState.Text.Trim().Replace("'", "''");
                        
                        Close();
                        return;
                    }
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Done...!!!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Clear();
                }
                else
                {
                    PleaseWait.Close();
                    MessageBox.Show($@"{ToPerform.ToUpper()} Error...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtState.Focus();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml(Global.BackgroundColor);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseBtn = 1;
            btn_Refresh_Click(sender, e);
        }
    }
}
