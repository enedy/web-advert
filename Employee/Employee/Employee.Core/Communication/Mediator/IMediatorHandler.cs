using Employee.Core.Messages;
using Employee.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace Employee.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        // COMANDO CQRS
        Task<bool> SendCommand<T>(T comando) where T : Command;
        // EXCECOES/NOTIFICACOES PARA O USUARIO
        Task SendNotification<T>(T notificacao) where T : DomainNotification;
    }
}
