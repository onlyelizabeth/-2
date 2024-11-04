using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
            MyTime time1 = new MyTime(5, 8, 6);
            MyTime time2 = new MyTime(9, 15, 45);
            MyTime time3 = new MyTime(12, 59, 59);
            MyTime time4 = new MyTime(16, 27, 9);
            MyTime time5 = new MyTime(23, 5, 59);

            Console.WriteLine("Робота методу WhatLesson:");
            MyTime.TestWhatLesson(new MyTime(4, 10, 56));
            MyTime.TestWhatLesson(new MyTime(7, 59, 56));
            MyTime.TestWhatLesson(new MyTime(8, 0, 0));
            MyTime.TestWhatLesson(new MyTime(8, 0, 3));
            MyTime.TestWhatLesson(new MyTime(9, 20, 0));
            MyTime.TestWhatLesson(new MyTime(9, 20, 30));
            MyTime.TestWhatLesson(new MyTime(9, 20, 50));
            MyTime.TestWhatLesson(new MyTime(9, 40, 0));
            MyTime.TestWhatLesson(new MyTime(12, 18, 50));
            MyTime.TestWhatLesson(new MyTime(12, 40, 0));
            MyTime.TestWhatLesson(new MyTime(13, 0, 0));
            MyTime.TestWhatLesson(new MyTime(15, 20, 50));
            MyTime.TestWhatLesson(new MyTime(15, 59, 50));
            MyTime.TestWhatLesson(new MyTime(16, 0, 0));
            MyTime.TestWhatLesson(new MyTime(16, 0, 50));
            MyTime.TestWhatLesson(new MyTime(16, 9, 5));
            MyTime.TestWhatLesson(new MyTime(16, 10, 30));
            MyTime.TestWhatLesson(new MyTime(17, 29, 35));
            MyTime.TestWhatLesson(new MyTime(17, 30, 0));
            MyTime.TestWhatLesson(new MyTime(17, 30, 5));
            MyTime.TestWhatLesson(new MyTime(20, 10, 50));
            Console.WriteLine();

            Console.WriteLine("Час 1: " + time1);
            Console.WriteLine("Час 2: " + time2);
            Console.WriteLine("Час 3: " + time3);
            Console.WriteLine("Час 4: " + time4);
            Console.WriteLine("Час 5: " + time5);
            Console.WriteLine();

            Console.WriteLine("Робота методу AddOneSecond:");
            MyTime time3PlusSec = MyTime.AddOneSecond(time3);
            MyTime time4PlusSec = MyTime.AddOneSecond(time4);
            Console.WriteLine($"Додавання 1 секунди до часу 3: {time3PlusSec}");
            Console.WriteLine($"Додавання 1 секунди до часу 4: {time4PlusSec}");
            Console.WriteLine();

            Console.WriteLine("Робота методу AddOneMinute:");
            MyTime time1PlusMin = MyTime.AddOneMinute(time1);
            MyTime time3PlusMin = MyTime.AddOneMinute(time3);
            Console.WriteLine($"Додавання 1 хвилини до часу 1: {time1PlusMin}");
            Console.WriteLine($"Додавання 1 хвилини до часу 3: {time3PlusMin}");
            Console.WriteLine();

            Console.WriteLine("Робота методу AddOneHour:");
            MyTime time2PlusHour = MyTime.AddOneHour(time2);
            MyTime time5PlusHour = MyTime.AddOneHour(time5);
            Console.WriteLine($"Додавання 1 години до часу 2: {time2PlusHour}");
            Console.WriteLine($"Додавання 1 години до часу 5: {time5PlusHour}");
            Console.WriteLine();

            Console.WriteLine("Робота методу AddSeconds:");
            MyTime time2Plus45Sec = MyTime.AddSeconds(time2, 45);
            MyTime time2Plus86445Sec = MyTime.AddSeconds(time2, 86445);
            MyTime time2Minus127Sec = MyTime.AddSeconds(time2, -127);
            Console.WriteLine($"Додавання 45 секунд до часу 2: {time2Plus45Sec}");
            Console.WriteLine($"Додавання 86445 секунд до часу 2: {time2Plus86445Sec}");
            Console.WriteLine($"Додавання -127 секунд до часу 2: {time2Minus127Sec}");
            Console.WriteLine();

            Console.WriteLine("Робота методу Difference:");
            int difference24 = MyTime.Difference(time2, time4);
            int difference42 = MyTime.Difference(time4, time2);
            Console.WriteLine($"Різниця між часом 2 і часом 4: {difference24} секунд");
            Console.WriteLine($"Різниця між часом 4 і часом 2: {difference42} секунд");
            Console.WriteLine();

            Console.WriteLine("Робота методу IsInRange:");
            bool isInRange135 = MyTime.IsInRange(time1, time5, time3);
            bool isInRange531 = MyTime.IsInRange(time5, time1, time3);
            string res1 = isInRange135 ? "Так" : "Ні";
            string res2 = isInRange531 ? "Так" : "Ні";
            Console.WriteLine($"Чи належить час 3 проміжку час1-час5? {res1}");
            Console.WriteLine($"Чи належить час 3 проміжку час5-час1? {res2}");
            Console.WriteLine();

            Console.WriteLine("Робота методу WhatLesson:");
            string whatLesson1 = MyTime.WhatLesson(time1);
            string whatLesson2 = MyTime.WhatLesson(time2);
            string whatLesson3 = MyTime.WhatLesson(time3);
            string whatLesson4 = MyTime.WhatLesson(time4);
            string whatLesson5 = MyTime.WhatLesson(time5);
            Console.WriteLine($"Час 1: {whatLesson1}");
            Console.WriteLine($"Час 2: {whatLesson2}");
            Console.WriteLine($"Час 3: {whatLesson3}");
            Console.WriteLine($"Час 4: {whatLesson4}");
            Console.WriteLine($"Час 5: {whatLesson5}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
