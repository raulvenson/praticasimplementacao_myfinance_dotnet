using Microsoft.EntityFrameworkCore;
using praticasimplementacao_myfinance_dotnet.Domain.Entities;

namespace praticasimplementacao_myfinance_dotnet
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = @"Server=.\SQLEXPRESS;Database=myFinance;Trusted_Connection=True;TrustServerCertificate=True";
            var connectionString = @"Data Source=DESKTOP-FMAJCOU;Database=myFinance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}