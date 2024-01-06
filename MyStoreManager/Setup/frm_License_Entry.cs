using DocumentFormat.OpenXml.Bibliography;
using MSMControl.Class;
using MSMControl.Connection;
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
    public partial class frm_License_Entry : Form
    {
        public DateTime dateCreated;
        public DateTime dateExpiry;
        public string Key = string.Empty;
        public int days;
        //clsPleaseWaitForm PleaseWait = new clsPleaseWaitForm();
        public frm_License_Entry()
        {
            InitializeComponent();
        }

        public void clear()
        {
            txt_Key.Clear();
            lbl_Status.Text = "";
            txt_Password.Clear();
        }

        private void frm_License_Entry_Load(object sender, EventArgs e)
        {
            lbl_remainingDays.Text = Global.remainingDays.ToString();
            clear();
        }

        public void KeyValidator()
        {
            if (!string.IsNullOrEmpty(txt_Key.Text))
            {
                SKGL.Validate validate = new SKGL.Validate();
                validate.Key = txt_Key.Text;
                dateCreated = validate.CreationDate;
                dateExpiry = validate.ExpireDate;
                days = validate.DaysLeft;
                Key = txt_Key.Text;
                lbl_Status.Text = "Creation Date:-   " + validate.CreationDate + "\r\n" + "Expire date:-       " + validate.ExpireDate + "\r\n" + "Day left:-             " + validate.DaysLeft;
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            
            if (txt_Password.Text == "MSM@admin_2023")
            {
                KeyValidator();
                //PleaseWait.Show();
                if (Global.licenseKey != null && txt_Key.Text == Global.licenseKey)
                {
                    //PleaseWait.Close();
                    MessageBox.Show("license Key already in use", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txt_Key.Focus();
                    return;
                }
                var query = $@"truncate table MSM.licsence;  insert into MSM.licsence (licsence_key,licsence_Days,issue_date,validity_date) values('{Key}','{days}','{dateCreated}','{dateExpiry}')";
                var Ok = Execute.ExecuteNonQueryOnMain(query);
                if (Ok != 0)
                {
                    //PleaseWait.Close();
                    MessageBox.Show("license updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                    clear();
                }

            }
            else
            {
                //PleaseWait.Close ();
                MessageBox.Show("Wrong Credential!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            KeyValidator();
        }
    }
}
