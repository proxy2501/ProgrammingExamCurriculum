using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodeCoverage;

namespace CodeCoverage_Test
{
    [TestClass]
    public class TicketBooth_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PriceByAge_Invalid_Below_Minimum()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();

            // Act.
            ticketBooth.PriceByAge(-1);

            // Assert.
            // Expect exception.
        }

        [TestMethod]
        public void PriceByAge_Valid_Lower_Boundary_Value_Partition_1()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 0;

            // Act.
            int result = ticketBooth.PriceByAge(0);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Upper_Boundary_Value_Partition_1()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 0;

            // Act.
            int result = ticketBooth.PriceByAge(1);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Lower_Boundary_Value_Partition_2()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 10;

            // Act.
            int result = ticketBooth.PriceByAge(2);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Upper_Boundary_Value_Partition_2()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 10;

            // Act.
            int result = ticketBooth.PriceByAge(14);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Lower_Boundary_Value_Partition_3()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 20;

            // Act.
            int result = ticketBooth.PriceByAge(15);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Upper_Boundary_Value_Partition_3()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 20;

            // Act.
            int result = ticketBooth.PriceByAge(64);

            // Assert.
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PriceByAge_Valid_Lower_Boundary_Value_Partition_4()
        {
            // Arrange.
            TicketBooth ticketBooth = new TicketBooth();
            int expected = 5;

            // Act.
            int result = ticketBooth.PriceByAge(65);

            // Assert.
            Assert.AreEqual(result, expected);
        }
    }
}