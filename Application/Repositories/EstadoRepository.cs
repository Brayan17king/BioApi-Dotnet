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
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly BackEndContext _context;

        public EstadoRepository(BackEndContext context) : base(context)
        {
            _context = context;
        }
    }
}