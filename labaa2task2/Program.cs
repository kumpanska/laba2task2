﻿using System;
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
        public int TimeSinceMidnight()
        {
            return this.hour * 3600 + this.minute * 60 + this.second;
        }
        public static MyTime TimeSinceMidnight(int t)
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
        public MyTime AddOneSecond()
        {
            int addSecond = TimeSinceMidnight() + 1;
            return TimeSinceMidnight(addSecond);
        }
        public MyTime AddOneMinute()
        {
            int addMinute = TimeSinceMidnight() + 60;
            return TimeSinceMidnight(addMinute);
        }
        public MyTime AddOneHour()
        {
            int addHour = TimeSinceMidnight() + 3600;
            return TimeSinceMidnight(addHour);
        }
        public MyTime AddSeconds(int s)
        {
            int addSeconds = TimeSinceMidnight() + s;
            return TimeSinceMidnight(addSeconds);
        }
        public int Difference(MyTime mt1, MyTime mt2)
        {
            int totalSeconds1 = mt1.TimeSinceMidnight();
            int totalSeconds2 = mt2.TimeSinceMidnight();
            return totalSeconds1 - totalSeconds2;
        }
        public string WhatLesson()
        {
            List<int[]> lessons = new List<int[]>
            {
             new int[]{8,0,9,20,1 },
             new int[]{9,40,11,0,2 },
             new int[]{11,20,12,40,3 },
             new int[]{13,0,14,20,4 },
             new int[]{14,40,16,0,5 },
             new int[]{16,10,17,30,6 }
            };
            List<int[]> breaks = new List<int[]>
            {
             new int[]{9,20,9,40,1 },
             new int[]{11,0,11,20,2 },
             new int[]{12,40,13,0,3 },
             new int[]{14,20,14,40,4 },
             new int[]{16,0,16,10,5 }
            };
            if (Hour < 8)
            {
                return "Lessons haven't started yet";
            }
            foreach (int[] lesson in lessons)
            {
                if ((Hour > lesson[0] || (Hour == lesson[0] && Minute >= lesson[1])) &&
                    (Hour < lesson[2] || (Hour == lesson[2] && Minute < lesson[3])))
                {
                    return $"Lesson: {lesson[4]}";
                }
            }
            foreach (int[] breakTime in breaks)
            {
                if ((Hour > breakTime[0] || (Hour == breakTime[0] && Minute >= breakTime[1])) &&
                    (Hour < breakTime[2] || (Hour == breakTime[2] && Minute < breakTime[3])))
                {
                    return $"Break: {breakTime[4]}";
                }
            }
            return "Lessons are already over";
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
                MyTime t = new MyTime(hour, minute, second);
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
                        Console.WriteLine($"Time in seconds:{t.TimeSinceMidnight()} ");
                        break;
                    case 2:
                        Console.Write("Enter number of seconds: ");
                        int s = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"TimeSinceMidnight:{TimeSinceMidnight(s)}");
                        break;
                    case 3:
                        Console.WriteLine($"Time after adding one second:{t.AddOneSecond()}");
                        break;
                    case 4:
                        Console.WriteLine($"Time after adding one minute:{t.AddOneMinute()}");
                        break;
                    case 5:
                        Console.WriteLine($"Time after adding one hour:{t.AddOneHour()}");
                        break;
                    case 6:
                        Console.Write("Enter number of seconds: ");
                        int seconds = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Time after adding {seconds} seconds:{t.AddSeconds(seconds)} ");
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
                        Console.WriteLine(t.WhatLesson());
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
            MyTime t = new MyTime(0, 0, 0);
            t.InputOutput();
            
        }
    }
}
