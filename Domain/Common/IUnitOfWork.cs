using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Domain.Common
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
