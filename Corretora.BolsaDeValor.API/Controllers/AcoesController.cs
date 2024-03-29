using Delivery.Core.DomainObjects;
using Delivery.Core.Mediator;
using Delivery.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;
using Serilog;

namespace Corretora.BolsaDeValor.API.Controllers
{
    [Route("api/[Controller]")]
    public class AcoesController(IAcoesRepository AcoesRepository) : MainController
    {
        [HttpGet]
        public async Task<PagedResult<Acoes>> Get([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null) =>await AcoesRepository.GetAll(ps, page, q);
        

        [HttpGet("nome")]
        public async Task<List<string>> List(string nome) => await AcoesRepository.GetAcoes(nome);

        [HttpGet("{id}")]
        public async Task<Acoes> Details(Guid id) => await AcoesRepository.GetById(id);
        
    }
}