using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prova.MedGrupo.Framework.Enums;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Framework.Results;
using Prova.MedGrupo.Resources;

namespace Prova.MedGrupo.WebApi.Controlles
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected INotificationContext NotificationContext;
        public BaseController(INotificationContext notificationContext)
        {
            NotificationContext = notificationContext;
        }

        protected virtual async Task<IActionResult> TryExecuteAsync<T>(Task<T> task)
        {
            try
            {
                return GetActionResult(await task);
            }
            catch (Exception exception)
            {
                ///TODO: Criar mecanismo para logar exceptions
                return InternalServerErrorResult(exception);
            }
        }

        protected virtual IActionResult GetActionResult(object data = null)
        {
            var result = GetNotificationResult(false);
            if (result.Success)
            {
                result.Data = data;
            }
            else
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        private IActionResult InternalServerErrorResult(Exception exception)
        {
            NotificationContext.Clear();
            NotificationContext.Add(ENotificationType.Error, TextResource.InternalServerError);
            return StatusCode((int)HttpStatusCode.InternalServerError, GetNotificationResult(true));
        }

        private IResult GetNotificationResult(bool onlyErrors)
        {
            return new Result
            {
                Success = NotificationContext.Successfully,
                Notifications = onlyErrors ? NotificationContext.ErrorNotifications : NotificationContext.AllNotifications
            };
        }
    }
}