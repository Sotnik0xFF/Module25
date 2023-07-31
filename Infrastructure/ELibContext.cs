using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Module25.Domain.BookAggregate;
using Module25.Domain.Common;
using Module25.Domain.UserAggregate;
using Module25.Infrastructure.EntityConfigurations;
using System.Reflection;

namespace Module25.Infrastructure
{
    public class ELibContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory("Data");
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = Path.Combine(Directory.GetCurrentDirectory(), "Data", "elibdata.db");
            optionsBuilder.UseSqlite(connectionStringBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
