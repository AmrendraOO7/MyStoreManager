using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.customTools
{
    internal class TextBoxChangedDelay : TextBox
    {
        private System.ComponentModel.IContainer components;
        private Timer _timer = new Timer();
        public event EventHandler TextBoxChangedDelayed;

        public TextBoxChangedDelay()
        {
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            OnTextChangedDelayed();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _timer.Stop();
            _timer.Start();
        }

        protected virtual void OnTextChangedDelayed()
        {
            if (TextBoxChangedDelayed != null)
            {
                TextBoxChangedDelayed(this, EventArgs.Empty);
            }
        }

        public int TextChangedDelayedInterval
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
