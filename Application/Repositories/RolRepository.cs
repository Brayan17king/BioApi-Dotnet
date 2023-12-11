using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistance.Data;
using Persistence.Data;

namespace Application.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly BackEndContext _context;

        public RolRepository(BackEndContext context) : base(context)
        {
            _context = context;
        }
    }
}