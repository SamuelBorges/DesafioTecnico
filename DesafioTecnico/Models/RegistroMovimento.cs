using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Models
{
    public class RegistroMovimento
    {
        public RegistroMovimento(string Placa, DateTime dataEntrada)
        {
            this.Placa = Placa;
            this.DataEntrada = dataEntrada;
        }

        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public Double PrecoTotal { get; set; }
    }
}