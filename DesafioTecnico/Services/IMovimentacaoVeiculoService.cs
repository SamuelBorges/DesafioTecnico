using DesafioTecnico.Models;

namespace DesafioTecnico.Services
{
    public interface IMovimentacaoVeiculoService 
    {
        List<RegistroMovimento> RecuperarMovimentacoes();
        void RegistrarMovimentoEntrada(RegistroMovimento novoRegistro);
        bool isVeiculoEstacionado(string placaVeiculo);
        TabelaPreco? ListarPrecosVigentes();
        void RegistrarMovimentoSaida(RegistroMovimento registroMovimento, double precoTota);
        RegistroMovimento? RecuperarMovimentoEntrada(string inputPlaca);
        double CalcularPrecoTotal(TabelaPreco precoVigente, RegistroMovimento registroEntrada);
    }
}
