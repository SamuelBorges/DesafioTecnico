using System.ComponentModel.DataAnnotations;

namespace DesafioTecnico.Models
{
    public class TabelaPreco
    {
        [Key]
        public int Id { get; set; }
        public double ValorInicial { get; set; }
        public double ValorAdicional { get; set; }
        public DateTime DataVigenciaInicial { get; set; }
        public DateTime DataVigenciaFinal { get; set; }

    }
}
