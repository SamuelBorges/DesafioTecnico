using DesafioTecnico.DAL;
using DesafioTecnico.EntityFramework;
using DesafioTecnico.Models;
using DesafioTecnico.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioTecnico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITabelaPrecoService _tabelaPrecoService;

        public HomeController(ITabelaPrecoService tabelaPrecoService)
        {
            _tabelaPrecoService = tabelaPrecoService;
        }

        public ActionResult Index()
        {
            DateTime dataAtual = DateTime.Now;
            ViewBag.PrecoVigente = _tabelaPrecoService.ListarPrecosVigentes();
            ViewBag.PrecosFuturos = _tabelaPrecoService.ListarPrecosFuturos();

            return View();
        }
        public IActionResult CadastroMovimentacao()
        {
            return View();
        }
    }
}