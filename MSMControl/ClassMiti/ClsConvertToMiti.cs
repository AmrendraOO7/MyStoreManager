using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMControl.ClassMiti
{
    public class ConvertToMiti
    {
        /// <param name="EngDate">English date to get converted</param>
        public static Miti GetMiti(DateTime EngDate)
        {
            #region Core Algorithm for Nepali date conversion
            int[] npDateData = MitiData.ConvertEngDatetoMiti(EngDate.Year);
            int enDayOfYear = EngDate.DayOfYear;
            int npYear = npDateData[0];
            int npMonth = 9;
            int npDaysInMonth = npDateData[2];
            int npTempDays = npDateData[2] - npDateData[1] + 1;

            for (int i = 3; enDayOfYear > npTempDays; i++)
            {
                npTempDays += npDateData[i];
                npDaysInMonth = npDateData[i];
                npMonth++;

                if (npMonth > 12)
                {
                    npMonth -= 12;
                    npYear++;
                }
            }

            int npDay = npDaysInMonth - (npTempDays - enDayOfYear);
            #endregion

            #region Constructing and returning NepaliDate object
            Miti Miti = new Miti();
            Miti.npDate = String.Format("{0}/{1}/{2}", npYear, npMonth, npDay);
            Miti.npYear = npYear;
            Miti.npMonth = npMonth;
            Miti.npDay = npDay;
            Miti.npDaysInMonth = npDaysInMonth;

            return Miti;
            #endregion

        }

    }
}
