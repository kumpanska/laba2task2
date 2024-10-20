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
            set
            {
                if (value < 0 || value > 59)
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
            return TimeSinceMidnight(s);
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
                return "пари ще не почалися";
            }
            else if (Hour == 8 && Minute >= 0 && Second >= 0)
            {
                return "1-а пара";
            }
            else if (Hour == 9 && Minute >= 20 && Minute < 40 && Second >= 0)
            {
                return "перерва між 1-ю та 2-ю парами";
            }
            else if (Hour == 9 && Minute >= 40 && Second >= 0)
            {
                return "2-а пара";
            }
            else if (Hour == 11 && Minute >= 0 && Minute < 20 && Second >= 0)
            {
                return "перерва між 2-ю та 3-ю парами";
            }
            else if (Hour == 11 && Minute >= 20 && Second >= 0)
            {
                return "3-я пара";
            }
            else if (Hour == 12 && Minute >= 40 && Second >= 0)
            {
                return "перерва між 3-ю та 4-ю парами";
            }
            else if (Hour == 13 && Minute >= 0 && Second >= 0)
            {
                return " 4-а пара";
            }
            else if (Hour == 14 && Minute >= 20 && Minute < 40 && Second >= 0)
            {
                return "перерва між 4-ю та 5-ю парами";
            }
            else if (Hour >= 14 && Minute >= 40 && Second >= 0 && Hour < 16)
            {
                return "5-а пара";
            }
            else if (Hour == 16 && Minute >= 0 && Minute < 10 && Second >= 0)
            {
                return "перерва між 5-ю та 6-ю парами";
            }
            else if (Hour >= 16 && Minute >= 10 || Hour == 17 && Minute < 30 && Second >= 0)
            {
                return "6-а пара";
            }
            else
            {
                return "пари вже скінчилися";
            }
        }
        public void InputOutput()
        {
            while (true)
            {
                Console.Write("Enter time in H:mm:ss format(numbers separate by spaces): ");      
                string[] input = Console.ReadLine().Split(' ');
                int hour = Convert.ToInt32(input[0]);
                int minute = Convert.ToInt32(input[1]);
                int second = Convert.ToInt32(input[2]);
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
                        Console.WriteLine($"TimeSinceMidnight:{t.TimeSinceMidnight(second)}");
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
                        Console.Write("Enter second time in H:mm:ss format(numbers separate by spaces): ");
                        string[] input2 = Console.ReadLine().Split(' ');
                        int hour2 = Convert.ToInt32(input2[0]);
                        int minute2 = Convert.ToInt32(input2[1]);
                        int second2 = Convert.ToInt32(input2[2]);
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
