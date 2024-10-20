using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labaa2task2
{
    public class MyTime
    {
        private int hour;
        private int minute;
        private int second;
        public MyTime(int h, int m, int s)
        {
            this.hour = h;
            this.minute = m;
            this.second = s;
        }
        public override string ToString()
        {
            return $"Time:{hour}:{minute:D2}:{second:D2}";
        }
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Hour should be between 0 and 23");
                }
                hour = value;
            }
        }
        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Minute should be between 0 and 59");
                }
                minute = value;
            }
        }
        public int Second
        {
            get { return second; }
            set { if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Second should be between 0 and 59");
                }
                second = value;
            }
        }
        public int TimeSinceMidnight(MyTime t)
        {
            return t.Hour * 3600 + t.Minute * 60 + t.Second;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
