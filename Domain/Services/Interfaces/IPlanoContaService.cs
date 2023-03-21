using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using praticasimplementacao_myfinance_dotnet.Models;

namespace praticasimplementacao_myfinance_dotnet.Domain.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListarRegistros();

        void Salvar(PlanoContaModel model);

        PlanoContaModel RetornarRegistro(int id);

        void Excluir(int id);
    }
}