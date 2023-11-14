using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.spinner
{
    public partial class ActiveSpinner : Form
    {
        public ActiveSpinner()
        {
            InitializeComponent();
        }

        private void ActiveSpinner_Load(object sender, EventArgs e)
        {
            loading.Load("MyStoreManager.Properties.Resources.Iphone_spinner_2");
            loading.Location = new Point(this.Width / 2-loading.Width/2, this.Height / 2 - loading.Height / 2);
        }
    }
}
