using Employee.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Employee.Core.Communication.Mediator;
using Employee.Core.Messages.Notifications;
using Employee.Domain.Queries;

namespace Employee.Api.v1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainApiController
    {
        private readonly ISynchronizationQueries _synchronizationQueries;
        public TesteController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediatorHandler, ICurrentUserApi currentUserApi, ISynchronizationQueries synchronizationQueries) :
            base(notifications, mediatorHandler, currentUserApi)
        {
            _synchronizationQueries = synchronizationQueries;
        }

        [Route("{id}"), HttpGet]
        public async Task<IActionResult> GetAfdValidations(int id)
        {
            var sync = await _synchronizationQueries.GetSynchronizationFirstAsync();

            if (sync != null)
                return CustomOk(sync);
            else
                return CustomNotFound("Dados não encontrados");
        }
    }
}
