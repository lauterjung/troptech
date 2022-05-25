using System;

namespace A2
{
    public class Data
    {
        private int _day;
        private int _month;
        private int _year;
        private int _daysToAdd = 0;
        private int _monthsToAdd = 0;
        private int _yearsToAdd = 0;
        
        public int Day
        {
            get
            {
                return _day;
            }
        }
        public int Month
        {
            get
            {
                return _month;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
        }

        public string CompleteDate
        {
            get
            {
                while(_daysToAdd > 31)
                {
                    _daysToAdd = _daysToAdd - 31;
                    _monthsToAdd++;
                }
                 while(_monthsToAdd > 12)
                {
                    _monthsToAdd = _monthsToAdd - 12;
                    _yearsToAdd++;
                }
                int _finalDay = _day + _daysToAdd;
                int _finalMonth = _month + _monthsToAdd;
                int _finalYear = _year + _yearsToAdd;
                return string.Format("{0}/{1}/{2}", _finalDay.ToString("00"), _finalMonth.ToString("00"), _finalYear.ToString("0000"));
            }
        }

        public int DaysToAdd
        {
            get
            {
                return _daysToAdd;
            }
            set
            {
                _daysToAdd = value;
            }
        }
        public int MonthsToAdd
        {
            get
            {
                return _monthsToAdd;
            }
            set
            {
                _monthsToAdd = value;
            }
        }
        public int YearsToAdd
        {
            get
            {
                return _yearsToAdd;
            }
            set
            {
                _yearsToAdd = value;
            }
        }

        public Data(int day, int month, int year)
        {
            if (day > 31 || day < 1)
            {
                _day = 0;
            }
            else
            {
               _day = day;
            }

            if (month > 12 || month < 1)
            {
                _month = 0;
            }
            else
            {
               _month= month; 
            }

            if (year > 9999 || year < 0)
            {
                _year = 0;
            }
            else
            {
               _year= year; 
            }
        }
    }
}
