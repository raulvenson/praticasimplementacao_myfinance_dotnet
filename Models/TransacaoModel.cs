using Microsoft.AspNetCore.Mvc.Rendering;
using praticasimplementacao_myfinance_dotnet.Domain.Entities;

namespace praticasimplementacao_myfinance_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string? Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoContaModel ItemPlanoConta { get; set; }
        public IEnumerable<SelectListItem>? PlanoContas { get; set; }
    }
}