using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ClientAPI.Data
{
    public class JoinJoyDbContextFactory 
        : IDesignTimeDbContextFactory<JoinJoyDbContext>
    {
        public JoinJoyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JoinJoyDbContext>();

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                ?? "Host=db.tprtntkrpvumdukryall.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=J0inj0yp@ssw0rd11;SSL Mode=Require;Trust Server Certificate=true;";

            optionsBuilder.UseNpgsql(connectionString);

            return new JoinJoyDbContext(optionsBuilder.Options); 
        }
    }
}