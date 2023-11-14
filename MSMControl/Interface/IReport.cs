using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.Interface
{
    public interface IReport
    {
        void PrintCall(object printData);
    }
}
