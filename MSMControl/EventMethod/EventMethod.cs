using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.EventMethod
{
    public static class EventMethod
    {
        public static bool IsBlankOrEmpty(this TextBox value)
        {
            return value?.Text.Replace("'", "''").Trim().Length is 0;
        }
    }
}
