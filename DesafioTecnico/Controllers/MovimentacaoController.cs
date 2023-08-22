using DesafioTecnico.DAL;
using DesafioTecnico.Models;
using DesafioTecnico.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Text.RegularExpressions;

namespace DesafioTecnico.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoVeiculoService _movimentacaoPrecoService;
        public MovimentacaoController(IMovimentacaoVeiculoService movimentacaoPrecoService)
        {
            _movimentacaoPrecoService = movimentacaoPrecoService;
        }
        public ActionResult Index()
        {
            SetViewBags();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEntrada(string inputPlaca)
        {
            if (!isPlacaValida(inputPlaca))
            {
                SetViewBags("Placa invalida!");
                return View("Index");
            }
            if (_movimentacaoPrecoService.isVeiculoEstacionado(inputPlaca))
            {
                SetViewBags("Registro de saída pendente para o veículo " + inputPlaca);
                return View("Index");
            }

            _movimentacaoPrecoService.RegistrarMovimentoEntrada(new RegistroMovimento(inputPlaca, DateTime.Now));
            ViewBag.MovimentacaoVeiculo = _movimentacaoPrecoService.RecuperarMovimentacoes();
            return View("Index");
        }

        public IActionResult RegistrarSaida(string inputPlaca)
        {
            if (!isPlacaValida(inputPlaca))
            {
                SetViewBags("Placa invalida!");
                return View("Index");
            }
            TabelaPreco? precoVigente = _movimentacaoPrecoService.ListarPrecosVigentes();
            RegistroMovimento? registroEntrada = _movimentacaoPrecoService.RecuperarMovimentoEntrada(inputPlaca);

            if (registroEntrada == null)
            {
                SetViewBags("Este veículo nao esta registrado");
                return View("Index");
            }
            if (precoVigente == null)
            {
                SetViewBags("Voce precisa ter um preco vigente!");
                return View("Index");
            }

            registroEntrada.DataSaida = DateTime.Now;
            registroEntrada.PrecoTotal = _movimentacaoPrecoService.CalcularPrecoTotal(precoVigente, registroEntrada);

            _movimentacaoPrecoService.RegistrarMovimentoSaida(registroEntrada, registroEntrada.PrecoTotal);

            SetViewBags();
            return View("Index");
        }

        private bool isPlacaValida(string inputPlaca)
        {
            Regex regex = new Regex($"^[a-zA-Z]{{3}}[0-9][A-Za-z0-9][0-9]{{2}}$");
            Match regexResult = regex.Match(inputPlaca);

            if (string.IsNullOrEmpty(inputPlaca) || inputPlaca.Length > 7 || !regexResult.Success)
            {
                ModelState.AddModelError("placa", "Valor Inválido");
                return false;
            }
            return true;
        }

        private void SetViewBags()
        {
            ViewBag.MovimentacaoVeiculo = _movimentacaoPrecoService.RecuperarMovimentacoes();
        }
        private void SetViewBags(string errorMessage)
        {
            ViewBag.MovimentacaoVeiculo = _movimentacaoPrecoService.RecuperarMovimentacoes();
            ViewBag.ErrorMessage = errorMessage;
        }
    }
}
