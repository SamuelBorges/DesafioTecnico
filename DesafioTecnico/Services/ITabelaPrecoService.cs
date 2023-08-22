using DesafioTecnico.Models;

namespace DesafioTecnico.Services
{
    public interface ITabelaPrecoService
    {
        TabelaPreco? ListarPrecosVigentes();
        List<TabelaPreco> ListarPrecosFuturos();
    }
}
