using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Users.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            options.UseSqlite(connection);
        }

        public DbSet<AppUser>? Users { get; set; }
    }
}
