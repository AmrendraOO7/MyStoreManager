using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.spinner
{
    public partial class Spinner : Form
    {
        ActiveSpinner spinner;
        public Spinner()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Start();
            Task Run = new Task(Algo); 
            Run.Start();
            await Run;
            Stop();
        }

        public void Algo()
        {
            Thread.Sleep(3000);
        }

        public void Start()
        {
            spinner = new ActiveSpinner();
            spinner.Show();
        }
        public void Stop()
        {
            if (spinner != null)
            {
                spinner.Close();
            }
        }
    }
}
