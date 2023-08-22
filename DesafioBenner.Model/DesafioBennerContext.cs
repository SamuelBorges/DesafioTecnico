using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBenner.Model
{
    public class DesafioBennerContext : DbContext
    {
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<RegistroMovimento> RegistroMovimento { get; set; }
        public DbSet<TabelaPreco> TabelaPreco { get; set; }

        public DesafioBennerContext(DbContextOptions<DesafioBennerContext> options)
            : base(options)
        {
        }
    }
}
