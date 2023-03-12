﻿
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class ShowRepository : BaseRepository<Show>, IShowRepository
    {
        private readonly DatabaseContext _dbContext;
        public ShowRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
