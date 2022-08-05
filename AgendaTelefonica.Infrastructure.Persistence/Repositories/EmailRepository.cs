using AgendaTelefonica.Core.Application.Interfaces.Repositories;
using AgendaTelefonica.Core.Domain.Entities;
using AgendaTelefonica.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Infrastructure.Persistence.Repositories
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        private readonly ApplicationContext _dbContext;

        public EmailRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
