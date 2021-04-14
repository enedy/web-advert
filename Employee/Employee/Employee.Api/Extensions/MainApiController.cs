using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Employee.Core.Communication.Mediator;
using Employee.Core.Messages.Notifications;
using Employee.Core.Messages.Notifications.Mediator;

namespace Employee.Api.Extensions
{
    [ApiController]
    public abstract class MainApiController : ControllerBase
    {
        protected bool IsAuthenticated { get; private set; }
        protected long Id { get; private set; }
        protected string Name { get; private set; }
        protected long CompanyId { get; set; }
        protected long EmployeeId { get; set; }
        protected long EmployeeCompanyId { get; set; }
        protected string UsuPrivil { get; set; }
        protected int UserType { get; set; }
        protected string Guid { get; set; }
        protected IEnumerable<long> AppsId { get; set; }

        private readonly ICurrentUserApi _currentUserApi;
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;
        protected MainApiController(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediatorHandler, ICurrentUserApi currentUserApi)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
            _currentUserApi = currentUserApi;

            if (_currentUserApi.IsAuthenticated())
            {
                IsAuthenticated = true;
                Id = _currentUserApi.GetUserId();
                Name = _currentUserApi.GetName();
                CompanyId = _currentUserApi.GetCompanyId();
                EmployeeId = _currentUserApi.GetEmployeeId();
                EmployeeCompanyId = _currentUserApi.GetEmployeeCompanyId();
                UsuPrivil = _currentUserApi.GetUsuPrivil();
                UserType = _currentUserApi.GetUserType();
                Guid = _currentUserApi.GetGuid();
                AppsId = _currentUserApi.GetAppsId();
            }
        }

        protected bool CheckOperation()
        {
            return !_notifications.ExistsNotification();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(c => c.Value).ToList();
        }

        //protected IActionResult CustomResponse(object result = null)
        //{
        //    if (CheckOperation())
        //    {
        //        return Ok(new
        //        {
        //            Success = true,
        //            Data = result
        //        });
        //    }

        //    return BadRequest(new
        //    {
        //        Success = false,
        //        Error = _notifications.GetNotifications().Select(n => n.Value)
        //    });
        //}

        protected IActionResult CustomOk(object result = null, string message = null)
        {
            return Ok(new
            {
                Success = true,
                Data = result,
                Message = message
            });

        }

        protected IActionResult CustomNotFound(string message)
        {
            return NotFound(new
            {
                Success = false,
                Message = message
            });
        }

        protected IActionResult CustomResponseError(string message)
        {
            //this.NotificarErro(key, value);
            //return CustomResponse();

            return BadRequest(new
            {
                Success = false,
                Message = message
            });
        }

        //protected void NotificarErro(string codigo, string mensagem)
        //{
        //    _mediatorHandler.PublishNotification(new DomainNotification(codigo, mensagem));
        //}
    }
}
