using DesafioTecnico.EntityFramework;
using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace DesafioTecnico.Services
{
    public class MovimentacaoVeiculoService : BaseUtils, IMovimentacaoVeiculoService
    {
        public MovimentacaoVeiculoService(DesafioTecnicoContext context) : base(context) { }
        public List<RegistroMovimento> RecuperarMovimentacoes()
        {
            List<RegistroMovimento> movimentacoes = _context.RegistroMovimento
                .OrderBy(m => m.DataSaida == null).ThenBy(m => m.DataSaida).ToList();
            return movimentacoes;
        }

        public void RegistrarMovimentoEntrada(RegistroMovimento novoRegistro)
        {
             _context.RegistroMovimento.Add(novoRegistro);
             _context.SaveChanges();
        }
        public double CalcularPrecoTotal(TabelaPreco precoVigente, RegistroMovimento registroMovimento)
        {
            TimeSpan tempoPermanencia = (TimeSpan)(registroMovimento.DataSaida - registroMovimento.DataEntrada);
            double valorFinal = precoVigente.ValorInicial;

            if (tempoPermanencia.TotalMinutes <= 30)
            {
                return valorFinal / 2;
            }else if (tempoPermanencia.TotalMinutes <= 70)
            {
                return valorFinal;
            }
            tempoPermanencia -= TimeSpan.FromMinutes(60);

            double minutosArredondados = Math.Floor(tempoPermanencia.TotalMinutes / 60);
            valorFinal += minutosArredondados * precoVigente.ValorAdicional;

            if (tempoPermanencia.Minutes > 10)
            {
                valorFinal += precoVigente.ValorAdicional;
            }

            return valorFinal;
        }
        public void RegistrarMovimentoSaida(RegistroMovimento registroMovimento, double precoTotal)
        {
            _context.Update(registroMovimento);
            _context.SaveChanges();
        }
        public RegistroMovimento? RecuperarMovimentoEntrada(string inputPlaca)
        {
            RegistroMovimento? movimento = _context.RegistroMovimento
                        .Where(r => r.Placa == inputPlaca && r.DataSaida == null)
                        .OrderByDescending(r => r.DataEntrada)
                        .FirstOrDefault();
            return movimento;
        }
        public bool isSaidaPendente(string placa)
        {
            RegistroMovimento? movimento = _context.RegistroMovimento.FirstOrDefault(r => r.Placa == placa && r.DataSaida == null);
            return movimento != null;
        }

    }
}
