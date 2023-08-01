using Module25.Domain.Common;
using Module25.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.BookAggregate
{
    public interface IBookRepository : IRepository<Book>
    {
        void UpdatePublishedYear(int id, int year);
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Genre> GetAllGenres();
        int GetBooksCountByAuthor(Author author);
        int GetBooksCountByGenre(Genre genre);
        int GetBooksCountByOwner(User owner);
        IEnumerable<Book> GetAllBooksSortedByTitle();
        IEnumerable<Book> GetAllBooksSortedByPublishedYearDESC();
        Book? GetLastPublicated();
        IEnumerable<Book> FindBooksByGenreAndYear(Genre genre, int fromYear, int toYear);
        bool HasBook(Author author, string title);
    }
}
