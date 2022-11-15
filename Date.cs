﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Date
    {
        private int month; // 1-12
        public int Year { get; private set; } // auto-implemented property Year

        // constructor: use property Month to confirm proper value for month; 
        // use property Day to confirm proper value for day
        public Date(int month, int year)
        {
            Month = month; // validates month
            Year = year; // could validate year
        }

        // property that gets and sets the month
        public int Month
        {
            get
            {
                return month;
            }
            private set // make writing inaccessible outside the class
            {
                if (value <= 0 || value > 12) // validate month
                {
                    throw new ArgumentOutOfRangeException(
                       nameof(value), value, $"{nameof(Month)} must be 1-12");
                }

                month = value;
            }
        }

        // return a string of the form month/day/year
        public override string ToString() => $"{Month}/{Year}";
    }
}
