using MediatR;
using System.Collections.Generic;
using System.Linq;
using Employee.Core.Communication.Mediator;
using Employee.Core.Messages.Notifications;
using Employee.Core.Messages.Notifications.Mediator;
using Employee.Infra.CrossCutting.IoC;

namespace Employee.Function.Extensions
{
    public abstract class FunctionBase
    {
        public readonly DomainNotificationHandler _notifications;
        public readonly IMediatorHandler _mediatorHandler;

        public FunctionBase()
        {
            var resolver = new DependencyResolver();
            _notifications = (DomainNotificationHandler)resolver.ServiceProvider.GetService(typeof(INotificationHandler<DomainNotification>));
            _mediatorHandler = (IMediatorHandler)resolver.ServiceProvider.GetService(typeof(IMediatorHandler));
        }

        protected bool CheckOperation()
        {
            return !_notifications.ExistsNotification();
        }

        protected IEnumerable<string> GetNotifications()
        {
            return _notifications.GetNotifications().Select(c => c.Value).ToList();
        }
    }
}
