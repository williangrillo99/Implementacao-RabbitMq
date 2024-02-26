using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Model.Entity;
using Rabbit.Services;
using Rabbit.Services.Interface;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMensagensController : ControllerBase
    {
        private IRabbitMensagemService _rabbitMensagemService;

        public RabbitMensagensController(IRabbitMensagemService rabbitMensagemService) {

            _rabbitMensagemService =  rabbitMensagemService;
        }

        [HttpPost]
        public void AddMensagem(RabbitMensagem mensagem)
        {
            _rabbitMensagemService.SedMensagem(mensagem);
        }
    }
}
