using APICiaAerea.Entities;
using APICiaAerea.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace APICiaAerea.Contexts
{
    public class CiaAreaContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CiaAreaContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
        public DbSet<Piloto> Pilotos => Set<Piloto>();
        public DbSet<Voo> Voos => Set<Voo>();
        public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
        public DbSet<Manutencao> Manutencoes => Set<Manutencao>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("APICiaAerea"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AeronaveConfiguration());
            builder.ApplyConfiguration(new PilotoConfiguration());
            builder.ApplyConfiguration(new VooConfiguration());
            builder.ApplyConfiguration(new ManutencaoConfiguration());
            builder.ApplyConfiguration(new CancelamentoConfiguration());
        }
    }
}
