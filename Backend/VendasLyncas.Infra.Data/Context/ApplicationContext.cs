using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prmToolkit.NotificationPattern;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Infra.Context.Configurations;

namespace VendasLyncas.Infra.Context.Context
{
    public class ApplicationContext : DbContext
    {
        private const string conectionString = "Data Source=DESKTOP-952E37N\\SQLEXPRESS;Initial Catalog=VendasLyncas2;Integrated Security=True";

        public DbSet<Cliente> Cliente { get; private set; }
        public DbSet<Usuario> Usuario { get; private set; }
        public DbSet<Venda> Venda { get; private set; }
        public DbSet<ItemVenda> ItemVenda { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<INotifiable>();
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
