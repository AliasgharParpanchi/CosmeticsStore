using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CosmeticsStore.Utilitis
{
    public class PersianDate
    {
        private readonly PersianCalendar _persianCalendar;

        public PersianDate()
        {
            _persianCalendar = new PersianCalendar();
        }

        public int GetCurrentPersianYear()
        {
            return _persianCalendar.GetYear(DateTime.Now);
        }

        public (DateTime start, DateTime end) GetPersianYearRange()
        {
            int persianYear = GetCurrentPersianYear();
            // اولین روز سال شمسی (1 فروردین)
            DateTime startOfYear = _persianCalendar.ToDateTime(persianYear, 1, 1, 0, 0, 0, 0);

            // آخرین روز سال شمسی (29 یا 30 اسفند)
            int daysInLastMonth = _persianCalendar.GetDaysInMonth(persianYear, 12);
            DateTime endOfYear = _persianCalendar.ToDateTime(persianYear, 12, daysInLastMonth, 23, 59, 59, 999);

            return (startOfYear, endOfYear);
        }
    }
}