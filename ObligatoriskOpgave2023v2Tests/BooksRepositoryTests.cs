using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave2023.Tests
{
    [TestClass()]
    public class BooksRepositoryTest
    {
        private BooksRepository _repo;
        private readonly Book _badBook = new() { Title = "Test", Price = 1201 };



        [TestInitialize]
        public void Init()
        {
            _repo = new BooksRepository();

            _repo.Add(new Book() { Title = "HungerGames", Price = 200 });
            _repo.Add(new Book() { Title = "Divergent", Price = 155 });
            _repo.Add(new Book() { Title = "Twillight", Price = 775 });
            _repo.Add(new Book() { Title = "MazeRunner", Price = 1100 });
            _repo.Add(new Book() { Title = "LordOfTheRings", Price = 150 });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Book> books = _repo.Get();
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual(books.First().Title, "HungerGames");

            IEnumerable<Book> sortedBooks = _repo.Get(orderBy: "title");
            Assert.AreEqual(sortedBooks.First().Title, "Divergent");

            IEnumerable<Book> sortedBooks2 = _repo.Get(orderBy: "price");
            Assert.AreEqual(sortedBooks2.First().Title, "LordOfTheRings");
        }

        [TestMethod()]
        public void GetBookByIdTest()
        {
            Assert.IsNotNull(_repo.GetBookById(1));
            Assert.IsNull(_repo.GetBookById(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Book b = new() { Title = "Test", Price = 1199 };
            Assert.AreEqual(6, _repo.Add(b).Id);
            Assert.AreEqual(6, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(_badBook));
        }

        //[TestMethod()]
        [TestMethod]
        public void RemoveTest()
        {
            Assert.IsNull(_repo.Remove(100));
            Assert.AreEqual(1, _repo.Remove(1)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());
            Book b = new() { Title = "Test", Price = 1199 };
            Assert.IsNull(_repo.Update(100, b));
            Assert.AreEqual(1, _repo.Update(1, b)?.Id);
            Assert.AreEqual(5, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, _badBook));
        }
    }
}
