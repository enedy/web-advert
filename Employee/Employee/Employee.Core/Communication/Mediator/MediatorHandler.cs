using Employee.Core.Messages;
using Employee.Core.Messages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Employee.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task SendNotification<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}
