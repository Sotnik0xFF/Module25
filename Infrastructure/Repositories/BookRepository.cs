using Microsoft.EntityFrameworkCore;
using Module25.Domain.BookAggregate;
using Module25.Domain.Common;
using Module25.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module25.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ELibContext _context;

        public BookRepository(ELibContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
        }

        public void Delete(Book entity)
        {
            _context.Books.Remove(entity);
        }

        public IEnumerable<Book> FindBooksByGenreAndYear(Genre genre, int fromYear, int toYear)
        {
            return _context.Books
                .Where(b => b.Genres.Contains(genre) && b.PublishedYear >= fromYear && b.PublishedYear <= toYear)
                .ToList();
        }

        public Book? Get(int id)
        {
            return _context.Books.Include(b => b.Owner).SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> books = _context.Books.Include(b => b.Owner).ToList();
            foreach (Book book in books)
            {
                LoadBookData(book);
            }
            return books;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public IEnumerable<Book> GetAllBooksSortedByPublishedYearDESC()
        {
            IEnumerable<Book> books = _context.Books.OrderByDescending(b => b.PublishedYear).ToList();
            foreach (Book book in books)
            {
                LoadBookData(book);
            }
            return books;
        }

        public IEnumerable<Book> GetAllBooksSortedByTitle()
        {
            IEnumerable<Book> books = _context.Books.OrderBy(b => b.Title).ToList();
            foreach (Book book in books)
            {
                LoadBookData(book);
            }
            return books;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public int GetBooksCountByAuthor(Author author)
        {
            return _context.Books.Where(b => b.Authors.Contains(author)).Count();
        }

        public int GetBooksCountByGenre(Genre genre)
        {
            return _context.Books.Where(b => b.Genres.Contains(genre)).Count();
        }

        public int GetBooksCountByOwner(User owner)
        {
            return _context.Books.Where(b => b.Owner == owner).Count();
        }

        public Book? GetLastPublicated()
        {
            int maxPublishedYear = _context.Books.Max(b => b.PublishedYear);
            Book? book = _context.Books.FirstOrDefault(b => b.PublishedYear == maxPublishedYear);
            if (book != null)
                LoadBookData(book);
            return book;
        }

        public bool HasBook(Author author, string title)
        {
            Book? book = _context.Books.FirstOrDefault(b => b.Authors.Contains(author) && b.Title == title);
            return book != null;
        }

        public void UpdatePublishedYear(int id, int year)
        {
            Book? book = Get(id);
            if (book == null)
                throw new ArgumentException(nameof(id));

            book.PublishedYear = year;
            _context.SaveChanges();
        }

        private void LoadBookData(Book book)
        {
            _context.Entry(book).Collection(b => b.Genres).Load();
            _context.Entry(book).Collection(b => b.Authors).Load();
        }
    }
}
