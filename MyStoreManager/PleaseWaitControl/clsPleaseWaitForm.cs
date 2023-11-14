using MyStoreManager.PleaseWaitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Class
{
    public class clsPleaseWaitForm
    {
        pleaseWaitForm pleaseWait;
        Thread loadthread;

        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcess));
            loadthread.Start();
        }

        public void Show(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));
            loadthread.Start(parent);
        }

        public void Close()
        {
            if (pleaseWait != null)
            {
                pleaseWait.BeginInvoke(new System.Threading.ThreadStart(pleaseWait.Close));
                pleaseWait = null;
                loadthread = null;
            }
        }

        private void LoadingProcess()
        {
            pleaseWait = new pleaseWaitForm();
            pleaseWait.ShowDialog();
        }

        private void LoadingProcess(object parent)
        {
            Form parent1 = parent as Form;
            pleaseWait = new pleaseWaitForm(parent1);
            pleaseWait.ShowDialog();
        }
    }
}
