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
    public partial class MDI_License_Generator : Form
    {
        private int childFormNumber = 0;

        public MDI_License_Generator()
        {
            InitializeComponent();
        }

        private void MDI_License_Generator_Load(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            lbl_Status.BackColor = Color.Black; lbl_Status.ForeColor = Color.White;
            txt_Key.Clear();
            cmd_Days.Enabled = true;
        }

        public void KeyGenerator()
        {
            SKGL.Generate generate = new SKGL.Generate();
            txt_Key.Text = generate.doKey(Convert.ToInt32(cmd_Days.Text));
        }

        public void KeyValidator()
        {
            SKGL.Validate validate = new SKGL.Validate();
            validate.Key = txt_Key.Text;
            lbl_Status.Text = "Creation Date:-   " + validate.CreationDate + "\r\n" + "Expire date:-       " + validate.ExpireDate + "\r\n" + "Day left:-             " + validate.DaysLeft;
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmd_Days.Text))
            {
                cmd_Days.Enabled = false;
                KeyGenerator();
                KeyValidator();
            }
            else
            {
                MessageBox.Show("Missing Credential", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void globalTab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyChar is (char)Keys.Escape)
            {
                if (MessageBox.Show("Are you sure to clear...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) clear();
                else
                {
                    if (MessageBox.Show("Are you sure to close...!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
                    else return;
                }
            }
        }

    }
}
