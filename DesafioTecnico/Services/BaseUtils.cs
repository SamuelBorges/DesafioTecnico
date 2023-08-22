using DesafioTecnico.EntityFramework;
using DesafioTecnico.Models;

namespace DesafioTecnico.Services
{
    public abstract class BaseUtils
    {
        protected readonly DesafioTecnicoContext _context;
        public BaseUtils(DesafioTecnicoContext context)
        {
            _context = context;
        }
        public virtual TabelaPreco? ListarPrecosVigentes()
        {
            DateTime dataAtual = DateTime.Now;

            TabelaPreco? precoVigente = _context.TabelaPreco
            .Where(tp => tp.DataVigenciaInicial <= dataAtual && tp.DataVigenciaFinal >= dataAtual).FirstOrDefault();

            return precoVigente;
        }
    }
}
