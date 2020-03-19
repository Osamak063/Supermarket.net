using Supermarket.Api.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Api.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            this._context = context;
        }
    }
}
