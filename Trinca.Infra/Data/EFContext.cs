using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Trinca.Domain.Entities;

namespace Trinca.Infra.Data
{
    
    public class EFContext : DbContext
    {
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<EventEntity> Evento { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().ToContainer("Users");
            builder.Entity<TaskEntity>().ToContainer("Tasks");
            builder.Entity<EventEntity>().ToContainer("Event");

        }

    }
}
