using Rabbit.Model.Entity;
using Rabbit.Repositories.Interfaces;
using Rabbit.Services.Interface;

namespace Rabbit.Services
{
    public class RabbitMensagemService : IRabbitMensagemService
    {
        private IRabbitMensagemRepository _rabbitMensagemRepository;

        public RabbitMensagemService(IRabbitMensagemRepository rabbitMensagemRepository) {

            _rabbitMensagemRepository = rabbitMensagemRepository;
        }
        public void SedMensagem(RabbitMensagem mensagem)
        {
            _rabbitMensagemRepository.SedMensagem(mensagem);
        }
    }
}
