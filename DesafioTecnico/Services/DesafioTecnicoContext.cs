using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.EntityFramework
{
    public class DesafioTecnicoContext : DbContext
    {
        public DbSet<RegistroMovimento> RegistroMovimento { get; set; }
        public DbSet<TabelaPreco> TabelaPreco { get; set; }

        public DesafioTecnicoContext(DbContextOptions options) : base(options)
        {
        }
    }
}


