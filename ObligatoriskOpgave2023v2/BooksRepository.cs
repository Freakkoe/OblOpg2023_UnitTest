using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObligatoriskOpgave2023
{
    public class BooksRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new();

        public BooksRepository()
        {
            //_books.Add(new Book() { Id = _nextId++, Title = "Yeehaa", Price = 300});
            
        }

        public IEnumerable<Book> Get(int? priceAfter = null, string? titleIncludes = null, string? orderBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);
            if (priceAfter != null)
            {
                result = result.Where(b => b.Price > priceAfter);
            }
            if (titleIncludes != null)
            {
                result = result.Where(b => b.Title.Contains(titleIncludes));
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title": // fall through to next case
                    case "title_asc":
                        result = result.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(b => b.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break; // do nothing
                        throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }
        public List<Book> GetBooks(int id)
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.Find(book => book.Id == id);
        }



        public Book Add(Book book)
        {
            book.Validate();

            if (book.Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price", "Price must be less than or equal to 1200");
            }

            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Remove(int id)
        {
            Book? book = GetBookById(id);
            if (book == null)
            {
                return null;
            }
            _books.Remove(book );
            return book;
        }

        public Book? Update(int id, Book book)
        {
            book.Validate();

            if (book.Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price", "Price must be less than or equal to 1200");
            }

            Book? existingBook = GetBookById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Price = book.Price;
            return existingBook;
        }
    }
}
