using MaseratiTCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaseratiTCC.Services.Estabelecimentos
{
    public class EstabelecimentosServices : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://agilecuts.somee.com/Publish/Estabelecimentos";

        public EstabelecimentosServices()
        {
            _request = new Request();
        }

        public async Task<Estabelecimento> PostResgistrarEstabelecimentoAsync(Estabelecimento e)
        {
            //Registrar: Rota para o método da API que registrar o usuário
            string urlComplementar = "/Registrar";
            e.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, e);
            return e;
        }

        public async Task<Estabelecimento> PostAutenticarEstabelecimentoAsync(Estabelecimento e)
        {
            string urlComplementar = "/Autenticar";
            e = await _request.PostAsync(apiUrlBase + urlComplementar, e, string.Empty);

            return e;
        }
    }
}
