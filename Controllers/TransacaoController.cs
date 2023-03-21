using Microsoft.AspNetCore.Mvc;
using praticasimplementacao_myfinance_dotnet.Domain.Services.Interfaces;
using praticasimplementacao_myfinance_dotnet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace praticasimplementacao_myfinance_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;

        public TransacaoController(ILogger<TransacaoController> logger,
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
            ViewBag.Transacoes = _transacaoService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{Id}")]
        public IActionResult Cadastro(int? id)
        {
            var model = new TransacaoModel();

            if (id != null)
            {
                model = _transacaoService.RetornarRegistro((int)id);
            }

            // model.PlanoContas = (IEnumerable<SelectedListItem>?) _planoContaService.ListarRegistros();
            var lista = _planoContaService.ListarRegistros();
            model.PlanoContas = new SelectList(lista, "Id", "Descricao");

            return View(model);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{Id}")]
        public IActionResult Cadastro(TransacaoModel model)
        {
            _transacaoService.Salvar(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir((int)id);
            return RedirectToAction("Index");
        }


    }
}