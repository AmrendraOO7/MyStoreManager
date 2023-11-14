using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.ClassMiti
{
    public class Miti
    {
        private string _nepaliDate;
        public string npDate
        {
            get { return _nepaliDate; }
            set { _nepaliDate = value; }
        }

        private int _npDaysInMonth;

        public int npDaysInMonth
        {
            get { return _npDaysInMonth; }
            set { _npDaysInMonth = value; }
        }

        private int _npYear;

        public int npYear
        {
            get { return _npYear; }
            set { _npYear = value; }
        }

        private int _npMonth;

        public int npMonth
        {
            get { return _npMonth; }
            set { _npMonth = value; }
        }

        private int _npDay;

        public int npDay
        {
            get { return _npDay; }
            set { _npDay = value; }
        }
    }
}
