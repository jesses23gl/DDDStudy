using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace UI.Web.ViewComponents
{
    public class AlertsViewComponent : ViewComponent
    {
        //private IMemoryCache _cache;
        private readonly DomainNotificationHandler _notifications;
        public AlertsViewComponent(
            //IMemoryCache cache
            INotificationHandler<DomainNotification> notifications
            )
        {
            //_cache = cache;
            _notifications = (DomainNotificationHandler)notifications;
        }
        /// <summary>
        /// Alerts 视图组件
        /// 可以异步，也可以同步，注意方法名称，同步的时候是Invoke
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var errorData = await Task.FromResult(_notifications.GetNotifications());

            errorData?.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}
