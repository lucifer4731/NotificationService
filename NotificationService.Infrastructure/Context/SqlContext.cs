using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Context
{
    public class SqlContext : DbContext
    {
        public DbSet<NotificationTemplate> NotificationTemplate { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
        }
    }
}
