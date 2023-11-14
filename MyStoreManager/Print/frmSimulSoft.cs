using System;
using System.Windows.Forms;

namespace MyStoreManager.Print
{
    public partial class frmSimulSoft : Form
    {
        public frmSimulSoft()
        {
            InitializeComponent();
        }

        public void BtnPrintCall_Click(object sender, EventArgs e)
        {
              
        }

        private void frmSimulSoft_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
