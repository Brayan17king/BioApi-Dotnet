using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistance.Data;
using Persistence.Data;

namespace Application.Repositories;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
    private readonly BackEndContext _context;

    public RefreshTokenRepository(BackEndContext context) : base(context)
    {
        _context = context;
    }
}