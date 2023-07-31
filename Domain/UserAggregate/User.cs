using Module25.Domain.BookAggregate;
using Module25.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
