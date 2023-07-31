using Module25.Domain.Common;
using Module25.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.BookAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new List<Author>();
        public int PublishedYear { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre> { };
        public User? Owner { get; set; }
    }
}
