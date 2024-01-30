using Corretora.BolsaDeValor.Infra.Intaface;
using Delivery.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using Delivery.WebAPI.Core.Controllers;

namespace Corretora.BolsaDeValor.API.Controllers
{
    [Route("api/[controller]")]
    
    public class TransacaoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoController(IMediatorHandler mediator, ITransacaoRepository transacaoRepository)
        {
            _mediator = mediator;
            _transacaoRepository = transacaoRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post(AddTransacaoCommand command)
        {
           return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpPatch]
        public async Task<IActionResult> Pacth(UpdateTransacaoCommand command)
        {
            return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _transacaoRepository.Get());
        }
    }
}
