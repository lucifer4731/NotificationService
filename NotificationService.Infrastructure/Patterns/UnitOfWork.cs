using NotificationService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Patterns
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;
        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose(); 
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
