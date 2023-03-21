using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using praticasimplementacao_myfinance_dotnet.Models;

namespace praticasimplementacao_myfinance_dotnet.Domain.Services.Interfaces
{
    public interface ITransacaoService
    {
        List<TransacaoModel> ListarRegistros();

        void Salvar(TransacaoModel model);

        TransacaoModel RetornarRegistro(int id);

        void Excluir(int id);
    }
}