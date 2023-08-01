using Module25.Domain.BookAggregate;
using Module25.Domain.UserAggregate;
using Module25.Infrastructure;
using Module25.Infrastructure.Repositories;
using Module25.Presentation.Views;

namespace Module25.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PopulateDB();
            ShowData();
        }

        private static void ShowData()
        {
            using (ELibContext context = new ELibContext())
            {
                IUserRepository userRepository = new UserRepository(context);
                IBookRepository bookRepository = new BookRepository(context);

                new BooksView(bookRepository).Show();
                new UsersView(userRepository).Show();
            }
        }

        private static void PopulateDB()
        {
            using (ELibContext context = new ELibContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                IUserRepository userRepository = new UserRepository(context);
                IBookRepository bookRepository = new BookRepository(context);

                User userAlice = new User() { Name = "Alice", Email = "alice@mail.com" };
                User userBob = new User() { Name = "Bob", Email = "bob@mail.com" };

                Genre genreClassics = new Genre() { Name = "Classics" };
                Genre genreDystopia = new Genre() { Name = "Dystopia" };
                Genre genreRomance = new Genre() { Name = "Romance" };
                Genre genreHistorical = new Genre() { Name = "Historical" };

                Author author1 = new Author() { Name = "George Orwell" };
                Author author2 = new Author() { Name = "Jane Austen" };

                Book book1 = new Book()
                {
                    Authors = new List<Author>() { author1 },
                    Genres = new List<Genre> { genreClassics, genreDystopia },
                    PublishedYear = 1949,
                    Title = "1984",
                    Owner = userAlice
                };

                Book book2 = new Book()
                {
                    Authors = new List<Author>() { author1 },
                    Genres = new List<Genre> { genreClassics, genreDystopia },
                    PublishedYear = 1945,
                    Title = "Animal Farm",
                    Owner = userAlice
                };

                Book book3 = new Book()
                {
                    Authors = new List<Author>() { author2 },
                    Genres = new List<Genre> { genreClassics, genreRomance },
                    PublishedYear = 1815,
                    Title = "Emma",
                    Owner = userBob
                };

                Book book4 = new Book()
                {
                    Authors = new List<Author>() { author2 },
                    Genres = new List<Genre> { genreClassics, genreRomance, genreHistorical },
                    PublishedYear = 1817,
                    Title = "Persuasion"
                };

                bookRepository.Add(book1);
                bookRepository.Add(book2);
                bookRepository.Add(book3);
                bookRepository.Add(book4);
                bookRepository.UnitOfWork.Commit();
            }
        }
    }
}