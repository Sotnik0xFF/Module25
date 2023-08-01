using Module25.Domain.BookAggregate;
using Module25.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Presentation.Views
{
    internal class UsersView
    {
        private IUserRepository _userRepository;

        public UsersView(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Show()
        {

        }
    }
}
