using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistence.Data;

namespace Application.Repositories
{
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        private readonly BackEndContext _context;

        public PaisRepository(BackEndContext context) : base(context)
        {
            _context = context;
        }
    }
}