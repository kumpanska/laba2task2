using System;
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
