using Microsoft.AspNetCore.Mvc;
using praticasimplementacao_myfinance_dotnet.Domain.Services.Interfaces;
using praticasimplementacao_myfinance_dotnet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace praticasimplementacao_myfinance_dotnet.Controllers
{
    [Route("[controller]")]
    public class RelatorioController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public RelatorioController(ILogger<TransacaoController> logger,
        ITransacaoService transacaoService,
        IPlanoContaService planoContaService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            List<TransacaoModel> transacoes = _transacaoService.ListarRegistros();
        

            ViewBag.Relatorio = transacoes;
            return View();
        }

        [HttpGet]
        [Route("Filtrar/{date1}/{date2}")]
        public IActionResult Filtrar([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            List<TransacaoModel> transacoes = _transacaoService.ListarRegistros();

            if (dataInicio != null && dataFim != null && dataInicio < dataFim)
            {
                transacoes = transacoes.FindAll(transacoes => transacoes.Data >= dataInicio && transacoes.Data <= dataFim); 
            }              

            ViewBag.Relatorio = transacoes;
            return View();
        }
    }
}