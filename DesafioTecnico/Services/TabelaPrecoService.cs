using DesafioTecnico.EntityFramework;
using DesafioTecnico.Models;
using DesafioTecnico.Services;

namespace DesafioTecnico.DAL
{
    public class TabelaPrecoService : BaseUtils, ITabelaPrecoService
    {
        public TabelaPrecoService(DesafioTecnicoContext context) : base(context) { }

        public List<TabelaPreco> ListarPrecosFuturos()
        {
            DateTime dataAtual = DateTime.Now;

            List<TabelaPreco> precosFuturos = _context.TabelaPreco
                .Where(tp => tp.DataVigenciaInicial > dataAtual).ToList();

            return precosFuturos;
        }
    }
}
