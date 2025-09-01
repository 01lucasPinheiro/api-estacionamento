using EstacionamentoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoApi.Data
{
    public class VeiculoContext: DbContext
    {
       public DbSet<VeiculoModel> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=estacionamento.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
