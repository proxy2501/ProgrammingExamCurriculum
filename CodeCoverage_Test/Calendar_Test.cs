using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodeCoverage;

namespace CodeCoverage_Test
{
    [TestClass]
    public class Calendar_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthByNumber_Invalid_Below_Minimum()
        {
            // Arrange.
            Calendar calendar = new Calendar();

            // Act.
            calendar.MonthByNumber(0);

            // Assert.
            // Expect exception.
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_1()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "January";

            // Act.
            string result = calendar.MonthByNumber(1);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_2()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "February";

            // Act.
            string result = calendar.MonthByNumber(2);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_3()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "March";

            // Act.
            string result = calendar.MonthByNumber(3);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_4()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "April";

            // Act.
            string result = calendar.MonthByNumber(4);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_5()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "May";

            // Act.
            string result = calendar.MonthByNumber(5);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_6()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "June";

            // Act.
            string result = calendar.MonthByNumber(6);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_7()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "July";

            // Act.
            string result = calendar.MonthByNumber(7);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_8()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "August";

            // Act.
            string result = calendar.MonthByNumber(8);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_9()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "September";

            // Act.
            string result = calendar.MonthByNumber(9);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_10()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "October";

            // Act.
            string result = calendar.MonthByNumber(10);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_11()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "November";

            // Act.
            string result = calendar.MonthByNumber(11);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MonthByNumber_Valid_Value_12()
        {
            // Arrange.
            Calendar calendar = new Calendar();
            string expected = "December";

            // Act.
            string result = calendar.MonthByNumber(12);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthByNumber_Invalid_Above_Maximum()
        {
            // Arrange.
            Calendar calendar = new Calendar();

            // Act.
            calendar.MonthByNumber(13);

            // Assert.
            // Expect exception.
        }
    }
}
