using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using System;


namespace Tests_Task_2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Constructor_ShouldInitialize_WithoutParameters()
        {
            MyTime time = new MyTime();

            Assert.AreEqual(12, time.Hour);
            Assert.AreEqual(0, time.Minute);
            Assert.AreEqual(0, time.Second);
        }

        [TestMethod]
        public void Constructor_ShouldInitialize_WithValidParemeters()
        {
            MyTime time = new MyTime(5, 30, 45);

            Assert.AreEqual(5, time.Hour);
            Assert.AreEqual(30, time.Minute);
            Assert.AreEqual(45, time.Second);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidHour()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(-5, 30, 45);
            });

            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidMinute()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(5, -30, 45);
            });

            Assert.AreEqual("Значення хвилин має бути в діапазоні [0; 59].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidSecond()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(5, 30, 67);
            });

            Assert.AreEqual("Значення секунд має бути в діапазоні [0; 59].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidHourAndMinute()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(-5, 70, 45);
            });

            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidHourAndSecond()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(25, 30, 68);
            });

            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidMinuteAndSecond()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(5, 70, -45);
            });

            Assert.AreEqual("Значення хвилин має бути в діапазоні [0; 59].", exception.Message);
        }

        [TestMethod]
        public void Constructor_ShouldNotInitialize_WithInvalidHourAndMinuteAndSecond()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyTime time = new MyTime(-5, 70, 115);
            });

            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception.Message);
        }

        [TestMethod]
        public void MutatorHour_ShouldInitialize_WithValidValue()
        {
            MyTime time = new MyTime(5, 30, 45);
            time.Hour = 10;

            Assert.AreEqual(10, time.Hour);
        }

        [TestMethod]
        public void MutatorHour_ShouldThrowException_WithInvalidValue()
        {
            MyTime time = new MyTime(5, 30, 45);

            var exception1 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Hour = -1;
            });

            var exception2 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Hour = 25;
            });

            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception1.Message);
            Assert.AreEqual("Значення годин має бути в діапазоні [0; 23].", exception2.Message);
        }

        [TestMethod]
        public void MutatorMinute_ShouldInitialize_WithValidValue()
        {
            MyTime time = new MyTime(5, 30, 45);
            time.Minute = 10;

            Assert.AreEqual(10, time.Minute);
        }

        [TestMethod]
        public void MutatorMinute_ShouldThrowException_WithInvalidValue()
        {
            MyTime time = new MyTime(5, 30, 45);

            var exception1 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Minute = -1;
            });

            var exception2 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Minute = 65;
            });

            Assert.AreEqual("Значення хвилин має бути в діапазоні [0; 59].", exception1.Message);
            Assert.AreEqual("Значення хвилин має бути в діапазоні [0; 59].", exception2.Message);
        }

        [TestMethod]
        public void MutatorSecond_ShouldInitialize_WithValidValue()
        {
            MyTime time = new MyTime(5, 30, 45);
            time.Second = 10;

            Assert.AreEqual(10, time.Second);
        }

        [TestMethod]
        public void MutatorSecond_ShouldThrowException_WithInvalidValue()
        {
            MyTime time = new MyTime(5, 30, 45);

            var exception1 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Second = -1;
            });

            var exception2 = Assert.ThrowsException<ArgumentException>(() =>
            {
                time.Second = 65;
            });

            Assert.AreEqual("Значення секунд має бути в діапазоні [0; 59].", exception1.Message);
            Assert.AreEqual("Значення секунд має бути в діапазоні [0; 59].", exception2.Message);
        }

        [TestMethod]
        public void ToString_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(10, 5, 7);
            string result = time.ToString();

            Assert.AreEqual("10:05:07", result);
        }

        [TestMethod]
        public void ToSecSinceMidnight_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(10, 15, 57);
            int result = MyTime.ToSecSinceMidnight(time);

            Assert.AreEqual(36957, result);
        }

        [TestMethod]
        public void FromSecSinceMidnight_ShouldWorkCorrectly()
        {
            int sec = 36957;
            MyTime time = MyTime.FromSecSinceMidnight(sec);

            Assert.AreEqual(10, time.Hour);
            Assert.AreEqual(15, time.Minute);
            Assert.AreEqual(57, time.Second);
        }

        [TestMethod]
        public void AddOneSecond_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(12, 59, 59);
            MyTime timePlusSec = MyTime.AddOneSecond(time);

            Assert.AreEqual(13, timePlusSec.Hour);
            Assert.AreEqual(0, timePlusSec.Minute);
            Assert.AreEqual(0, timePlusSec.Second);
        }

        [TestMethod]
        public void AddOneMinute_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(12, 59, 59);
            MyTime timePlusMin = MyTime.AddOneMinute(time);

            Assert.AreEqual(13, timePlusMin.Hour);
            Assert.AreEqual(0, timePlusMin.Minute);
            Assert.AreEqual(59, timePlusMin.Second);
        }

        [TestMethod]
        public void AddOneHour_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(23, 5, 59);
            MyTime timePlusHour = MyTime.AddOneHour(time);

            Assert.AreEqual(0, timePlusHour.Hour);
            Assert.AreEqual(5, timePlusHour.Minute);
            Assert.AreEqual(59, timePlusHour.Second);
        }

        [TestMethod]
        public void AddSeconds_ShouldWorkCorrectly()
        {
            MyTime time = new MyTime(9, 15, 45);
            MyTime time2Plus45Sec = MyTime.AddSeconds(time, 45);
            MyTime time2Plus86445Sec = MyTime.AddSeconds(time, 86445);
            MyTime time2Minus127Sec = MyTime.AddSeconds(time, -127);

            Assert.AreEqual(9, time2Plus45Sec.Hour);
            Assert.AreEqual(16, time2Plus45Sec.Minute);
            Assert.AreEqual(30, time2Plus45Sec.Second);

            Assert.AreEqual(9, time2Plus86445Sec.Hour);
            Assert.AreEqual(16, time2Plus86445Sec.Minute);
            Assert.AreEqual(30, time2Plus86445Sec.Second);

            Assert.AreEqual(9, time2Minus127Sec.Hour);
            Assert.AreEqual(13, time2Minus127Sec.Minute);
            Assert.AreEqual(38, time2Minus127Sec.Second);
        }

        [TestMethod]
        public void IsInRange_ShouldWorkCorrectly()
        {
            MyTime time1 = new MyTime(5, 8, 6);
            MyTime time2 = new MyTime(12, 59, 59);
            MyTime time3 = new MyTime(23, 5, 59);

            bool isInRange123 = MyTime.IsInRange(time1, time3, time2);
            bool isInRange321 = MyTime.IsInRange(time3, time1, time2);

            Assert.AreEqual(true, isInRange123);
            Assert.AreEqual(false, isInRange321);
        }

        [TestMethod]
        public void WhatLesson_ShouldWorkCorrectly()
        {
            Assert.AreEqual("Пари ще не почалися", MyTime.WhatLesson(new MyTime(4, 10, 56)));
            Assert.AreEqual("Пари ще не почалися", MyTime.WhatLesson(new MyTime(7, 59, 56)));
            Assert.AreEqual("1-а пара", MyTime.WhatLesson(new MyTime(8, 0, 0)));
            Assert.AreEqual("1-а пара", MyTime.WhatLesson(new MyTime(9, 20, 0)));
            Assert.AreEqual("Перерва між 1-ю та 2-ю парами", MyTime.WhatLesson(new MyTime(9, 20, 30)));
            Assert.AreEqual("2-а пара", MyTime.WhatLesson(new MyTime(9, 40, 0)));
            Assert.AreEqual("3-а пара", MyTime.WhatLesson(new MyTime(12, 18, 50)));
            Assert.AreEqual("3-а пара", MyTime.WhatLesson(new MyTime(12, 40, 0)));
            Assert.AreEqual("4-а пара", MyTime.WhatLesson(new MyTime(13, 0, 0)));
            Assert.AreEqual("5-а пара", MyTime.WhatLesson(new MyTime(15, 20, 50)));
            Assert.AreEqual("5-а пара", MyTime.WhatLesson(new MyTime(16, 0, 0)));
            Assert.AreEqual("Перерва між 5-ю та 6-ю парами", MyTime.WhatLesson(new MyTime(16, 9, 5)));
            Assert.AreEqual("6-а пара", MyTime.WhatLesson(new MyTime(16, 10, 30)));
            Assert.AreEqual("6-а пара", MyTime.WhatLesson(new MyTime(17, 29, 35)));
            Assert.AreEqual("Пари вже скінчилися", MyTime.WhatLesson(new MyTime(17, 30, 5)));
            Assert.AreEqual("Пари вже скінчилися", MyTime.WhatLesson(new MyTime(20, 10, 50)));
        }
    }
}
