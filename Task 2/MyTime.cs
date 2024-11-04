using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class MyTime
    {
        protected int hour;
        protected int minute;
        protected int second;

        public MyTime()
        {
            this.hour = 12;
            this.minute = 0;
            this.second = 0;
        }

        public MyTime(int h, int m, int s)
        {
            if (!(HourIsCorrect(h)))
            {
                throw new ArgumentException("Значення годин має бути в діапазоні [0; 23].");
            }

            if (!(MinuteIsCorrect(m)))
            {
                throw new ArgumentException("Значення хвилин має бути в діапазоні [0; 59].");
            }

            if (!(SecondIsCorrect(s)))
            {
                throw new ArgumentException("Значення секунд має бути в діапазоні [0; 59].");
            }
            this.hour = h;
            this.minute = m;
            this.second = s;
        }

        public bool HourIsCorrect(int h)
        {
            if (h >= 0 && h <= 23)
            {
                return true;
            }
            return false;
        }

        public bool MinuteIsCorrect(int m)
        {
            if (m >= 0 && m <= 59)
            {
                return true;
            }
            return false;
        }

        public bool SecondIsCorrect(int s)
        {
            if (s >= 0 && s <= 59)
            {
                return true;
            }
            return false;
        }

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                if (!(HourIsCorrect(value)))
                {
                    throw new ArgumentException("Значення годин має бути в діапазоні [0; 23].");
                }
                hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }

            set
            {
                if (!(MinuteIsCorrect(value)))
                {
                    throw new ArgumentException("Значення хвилин має бути в діапазоні [0; 59].");
                }
                minute = value;
            }
        }

        public int Second
        {
            get
            {
                return second;
            }

            set
            {
                if (!(SecondIsCorrect(value)))
                {
                    throw new ArgumentException("Значення секунд має бути в діапазоні [0; 59].");
                }
                second = value;
            }
        }

        public override string ToString()
        {
            return $"{hour}:{minute:00}:{second:00}";
        }

        public static int ToSecSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }

        public static MyTime FromSecSinceMidnight(int t)
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

        public static MyTime AddOneSecond(MyTime t)
        {
            int secSinceMidnight = ToSecSinceMidnight(t);
            int newTime = secSinceMidnight + 1;

            return FromSecSinceMidnight(newTime);
        }

        public static MyTime AddOneMinute(MyTime t)
        {
            int secSinceMidnight = ToSecSinceMidnight(t);
            int newTime = secSinceMidnight + 60;

            return FromSecSinceMidnight(newTime);
        }

        public static MyTime AddOneHour(MyTime t)
        {
            int secSinceMidnight = ToSecSinceMidnight(t);
            int newTime = secSinceMidnight + 3600;

            return FromSecSinceMidnight(newTime);
        }

        public static MyTime AddSeconds(MyTime t, int s)
        {
            int secSinceMidnight = ToSecSinceMidnight(t);
            int newTime = secSinceMidnight + s;

            return FromSecSinceMidnight(newTime);
        }

        public static int Difference(MyTime mt1, MyTime mt2)
        {
            int secSinceMidnight1 = ToSecSinceMidnight(mt1);
            int secSinceMidnight2 = ToSecSinceMidnight(mt2);

            return secSinceMidnight1 - secSinceMidnight2;
        }


        public static bool IsInRange(MyTime start, MyTime finish, MyTime t)
        {
            int secondsStart = ToSecSinceMidnight(start);
            int secondsFinish = ToSecSinceMidnight(finish);
            int secondsT = ToSecSinceMidnight(t);

            if (secondsStart < secondsFinish)
            {
                return secondsStart <= secondsT && secondsT <= secondsFinish;
            }
            else
            {
                return secondsStart <= secondsT || secondsT <= secondsFinish;
            }
        }

        public static string WhatLesson(MyTime mt)
        {
            int class1Start = ToSecSinceMidnight(new MyTime(8, 0, 0));
            int class2Start = ToSecSinceMidnight(new MyTime(9, 40, 0));
            int class3Start = ToSecSinceMidnight(new MyTime(11, 20, 0));
            int class4Start = ToSecSinceMidnight(new MyTime(13, 0, 0));
            int class5Start = ToSecSinceMidnight(new MyTime(14, 40, 0));
            int class6Start = ToSecSinceMidnight(new MyTime(16, 10, 0));

            int classesEnd = ToSecSinceMidnight(new MyTime(17, 30, 0));


            int[] classesStart = { class1Start, class2Start, class3Start, class4Start, class5Start, class6Start };

            int secondsMt = ToSecSinceMidnight(mt);

            if (secondsMt > classesEnd)
            {
                return "Пари вже скінчилися";
            }

            if (secondsMt < class1Start)
            {
                return "Пари ще не почалися";
            }


            for (int i = 0; i < classesStart.Length; i++)
            {
                if (secondsMt < classesStart[i])
                {

                    if (secondsMt <= classesStart[i - 1] + 80 * 60)
                    {
                        return $"{i}-а пара";
                    }
                    else
                    {
                        return $"Перерва між {i}-ю та {i + 1}-ю парами";
                    }

                }
            }

            return "6-а пара";
        }

        public static void TestWhatLesson(MyTime t)
        {
            Console.WriteLine($"{t} {WhatLesson(t)}");
        }
    }
}
