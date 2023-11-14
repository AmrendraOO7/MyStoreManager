using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSM_NexaVerse_Tech_License_Generator
{
    public partial class License_Generator_MSM : Form
    {
        public string userID = "admin";
        public string Password = "MSM@admin_2023";
        public bool mdiActivity;
        public License_Generator_MSM()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_UserName.Text) && !string.IsNullOrEmpty(txt_Password.Text))
            {
                if (txt_UserName.Text == userID && txt_Password.Text == Password)
                {
                    this.Hide();
                    var frm = new MDI_License_Generator();
                    frm.ShowDialog();
                    mdiActivity = false;
                }
                else
                {
                    MessageBox.Show("Wrong Credential", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_UserName.Focus();
                    mdiActivity = true;
                }
                if (mdiActivity == false) Application.Exit();
            }
            else
            {
                MessageBox.Show("Missing Credential", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!string.IsNullOrEmpty(txt_UserName.Text)) txt_UserName.Focus();
                else txt_Password.Focus();
            }
        }
        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyChar is (char)Keys.Escape)
            {
                if (MessageBox.Show("Are you sure to Close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Application.Exit();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chk_PasswordBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PasswordBtn.Checked)
                txt_Password.UseSystemPasswordChar = false;
            else
                txt_Password.UseSystemPasswordChar = true;
        }
    }
}
