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
            if (h < 0 || h > 23)
            {
                throw new ArgumentException("Hour should be between 0 and 23");
            }
            if (m < 0 || m > 59)
            {
                throw new ArgumentException("Minute should be between 0 and 59");
            }
            if (s < 0 || s > 59)
            {
                throw new ArgumentException("Second should be between 0 and 59");
            }
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
        }
        public int Minute
        {
            get { return minute; }
        }
        public int Second
        {
            get { return second; }
        }
        public int TimeSinceMidnight(MyTime t)
        {
            return t.Hour * 3600 + t.Minute * 60 + t.Second;
        }
        public MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t %= secPerDay;
            if (t < 0)
                t += secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }
        public MyTime AddOneSecond(MyTime t)
        {
            int addSecond = TimeSinceMidnight(t) + 1;
            return TimeSinceMidnight(addSecond);
        }
        public MyTime AddOneMinute(MyTime t)
        {
            int addMinute = TimeSinceMidnight(t) + 60;
            return TimeSinceMidnight(addMinute);
        }
        public MyTime AddOneHour(MyTime t)
        {
            int addHour = TimeSinceMidnight(t) + 3600;
            return TimeSinceMidnight(addHour);
        }
        public MyTime AddSeconds(MyTime t, int s)
        {
            int addSeconds = TimeSinceMidnight(t) + s;
            return TimeSinceMidnight(addSeconds);
        }
        public int Difference(MyTime mt1, MyTime mt2)
        {
            int totalSeconds1 = TimeSinceMidnight(mt1);
            int totalSeconds2 = TimeSinceMidnight(mt2);
            return totalSeconds1 - totalSeconds2;
        }
        public string WhatLesson()
        {
            if (Hour < 8)
            {
                return "Lessons haven't started yet";
            }
            else if (Hour == 8 && Minute >= 0 && Second >= 0)
            {
                return "First lesson";
            }
            else if (Hour == 9 && Minute >= 20 && Minute < 40 && Second >= 0)
            {
                return "Break between first and second lessons";
            }
            else if (Hour == 9 && Minute >= 40 && Second >= 0)
            {
                return "Second lesson";
            }
            else if (Hour == 11 && Minute >= 0 && Minute < 20 && Second >= 0)
            {
                return "Break between second and third lessons";
            }
            else if ((Hour == 11 && Minute >= 20 && Second >= 0) ||(Hour==12 && Minute<=39))
            {
                return "Third lesson";
            }
            else if (Hour == 12 && Minute >= 40 && Second >= 0 )
            {
                return "Break between third and fourth lessons";
            }
            else if (Hour == 13 && Minute >= 0 && Second >= 0)
            {
                return "Fourth lesson";
            }
            else if (Hour == 14 && Minute >= 20 && Minute < 40 && Second >= 0)
            {
                return "Break between fourth and fifth lessons";
            }
            else if (Hour >= 14 && Minute >= 40 && Second >= 0 || Hour < 16)
            {
                return "Fifth lesson";
            }
            else if (Hour == 16 && Minute >= 0 && Minute < 10 && Second >= 0)
            {
                return "Break between fifth and sixth lessons";
            }
            else if (Hour == 16 && Minute >= 10 || Hour == 17 && Minute < 30 && Second >= 0)
            {
                return "Sixth lesson";
            }
            else
            {
                return "Lessons are already over";
            }
        }
        public void InputOutput()
        {
            while (true)
            {
                Console.Write("Enter time (numbers separate by spaces): ");      
                string[] input = Console.ReadLine().Split(' ');
                int hour = Convert.ToInt32(input[0]);
                int minute = Convert.ToInt32(input[1]);
                int second = Convert.ToInt32(input[2]);
                if (hour < 0 || hour > 23)
                {
                    throw new ArgumentException("Hour should be between 0 and 23");
                }
                if (minute < 0 || minute > 59)
                {
                    throw new ArgumentException("Minute should be between 0 and 59");
                }
                if (second < 0 || second > 59)
                {
                    throw new ArgumentException("Second should be between 0 and 59");
                }
                MyTime t = new MyTime(hour,minute,second);
                Console.WriteLine(t.ToString());
                Console.WriteLine("Choose operation(1-8) or exit the program(0):");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 0)
                {
                    Console.WriteLine("Exit the program");
                    break;
                }
                switch (num)
                {
                    case 1:
                        Console.WriteLine($"Time in seconds:{t.TimeSinceMidnight(t)} ");
                        break;
                    case 2:
                        Console.Write("Enter number of seconds: ");
                        int s= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"TimeSinceMidnight:{t.TimeSinceMidnight(s)}");
                        break;
                    case 3:
                        Console.WriteLine($"Time after adding one second:{t.AddOneSecond(t)}");
                        break;
                    case 4:
                        Console.WriteLine($"Time after adding one minute:{t.AddOneMinute(t)}");
                        break;
                    case 5:
                        Console.WriteLine($"Time after adding one hour:{t.AddOneHour(t)}");
                        break;
                    case 6:
                        Console.Write("Enter number of seconds: ");
                        int seconds = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Time after adding {seconds} seconds:{t.AddSeconds(t, seconds)} ");
                        break;
                    case 7:
                        Console.Write("Enter second time (numbers separate by spaces): ");
                        string[] input2 = Console.ReadLine().Split(' ');
                        int hour2 = Convert.ToInt32(input2[0]);
                        int minute2 = Convert.ToInt32(input2[1]);
                        int second2 = Convert.ToInt32(input2[2]);
                        if (hour2 < 0 || hour2 > 23)
                        {
                            throw new ArgumentException("Hour should be between 0 and 23");
                        }
                        if (minute2 < 0 || minute2 > 59)
                        {
                            throw new ArgumentException("Minute should be between 0 and 59");
                        }
                        if (second2 < 0 || second2 > 59)
                        {
                            throw new ArgumentException("Second should be between 0 and 59");
                        }
                        MyTime t2 = new MyTime(hour2, minute2, second2);
                        Console.WriteLine($"Time difference:{t.Difference(t, t2)} second");
                        break;
                    case 8:
                        Console.WriteLine($"Lesson:{t.WhatLesson()}");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select again.");
                        break;
                }
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTime t = new MyTime(0,0,0);
            t.InputOutput();
        }
    }
}
