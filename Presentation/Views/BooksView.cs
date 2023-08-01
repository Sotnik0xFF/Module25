using Microsoft.EntityFrameworkCore.ChangeTracking;
using Module25.Domain.BookAggregate;
using Module25.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Presentation.Views
{
    public class BooksView
    {
        private IBookRepository _bookRepository;

        public BooksView(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Show()
        {
            ShowAllBooks();
            ShowSortedByTitle();
            ShowSortedByPublishedYear();
            ShowAthorsBooksCount();

            Console.ReadLine();
        }

        private void ShowAthorsBooksCount()
        {
            IEnumerable<Author> authors = _bookRepository.GetAllAuthors();
            Console.WriteLine("***Books count by authors****");
            foreach (Author author in authors)
            {
                Console.WriteLine($"{author.Name} ({_bookRepository.GetBooksCountByAuthor(author)})");
            }
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }

        private void ShowSortedByPublishedYear()
        {
            IEnumerable<Book> books = _bookRepository.GetAllBooksSortedByPublishedYearDESC();
            Console.WriteLine("*******Sorted by year********");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.PublishedYear}");
            }
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }

        private void ShowSortedByTitle()
        {
            IEnumerable<Book> books = _bookRepository.GetAllBooksSortedByTitle();
            Console.WriteLine("******Sorted by title********");
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }

        private void ShowAllBooks()
        {
            IEnumerable<Book> books = _bookRepository.GetAll();
            Console.WriteLine("**********All books**********");
            foreach (var book in books)
            {
                Console.WriteLine($"Title:\t\t{book.Title}");
                Console.WriteLine($"Published:\t{book.PublishedYear}");
                Console.Write($"Genres:\t\t");
                foreach (var genre in book.Genres)
                {
                    Console.Write($"{genre.Name} ");
                }
                Console.WriteLine();
                Console.Write($"Authors:\t");
                foreach (var author in book.Authors)
                {
                    Console.Write($"{author.Name} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("*****************************");
            Console.WriteLine();
        }
    }
}
