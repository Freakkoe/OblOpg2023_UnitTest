using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave2023.Tests
{
    [TestClass]
    public class BookTest
    {
        private Book book = new Book { Id = 1, Title = "HarryPotter", Price = 799 };
        private Book bookTitleNull = new Book { Id = 2, Title = null, Price = 1998 };
        private Book bookTitleToShort = new Book { Id = 3, Title = "Ho", Price = 1998 };
        private Book bookPriceToLow = new Book { Id = 4, Title = "Askepot", Price = -1 };
        private Book bookPriceToHigh = new Book { Id = 5, Title = "Lyntyven", Price = 1201 };

        [TestMethod]
        public void ToStringTest()
        {
            string str = book.ToString();
            Assert.AreEqual("1 HarryPotter 799", str);
        }

        [TestMethod]
        public void ValidateTitleTest()
        {
            book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleNull.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => bookTitleToShort.ValidateTitle());
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(500)]
        [DataRow(899)]
        [DataRow(1200)]
        public void ValidatePriceTest(int price)
        {
            book.Price = price;
            book.ValidatePrice();
        }

        [TestMethod]
        public void ValidatePriceOutOfRangeTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceToLow.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceToHigh.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            book.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleNull.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => bookTitleToShort.ValidateTitle());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceToLow.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceToHigh.ValidatePrice());
        }

    }
}