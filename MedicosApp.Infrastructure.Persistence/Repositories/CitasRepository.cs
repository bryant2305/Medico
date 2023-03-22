using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Domain.Entities;
using MedicoApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Infrastructure.Persistence.Repositories
{
    public class CitasRepository : GenericRepository<Citas>, ICitasRepository
    {
        private readonly ApplicationContext _dbContext;

        public CitasRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
