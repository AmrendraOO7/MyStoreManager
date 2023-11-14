using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Print.PrintForm
{
    public partial class frmPOPrint : Form
    {
        public frmPOPrint()
        {
            InitializeComponent();
        }

        private void frmPOPrint_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
