using Rabbit.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Services.Interface
{
    public interface IRabbitMensagemService
    {
        void SedMensagem(RabbitMensagem rabbitMensagem);
    }
}
    