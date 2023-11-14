using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.PleaseWaitControl
{
    public partial class pleaseWaitForm : Form
    {
        public pleaseWaitForm()
        {
            InitializeComponent();
        }
        public pleaseWaitForm(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                    parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else this.StartPosition = FormStartPosition.CenterParent;
        }

        public void CloseWaitForm()
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
            if (label1.Image != null)
            {
                label1.Image.Dispose();
            }
        }

        public void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void btn_Close_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}
    }
}
