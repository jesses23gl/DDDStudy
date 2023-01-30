using Microsoft.AspNetCore.Mvc;

namespace UI.Web.ViewComponents
{
    public class AlertsViewComponent : ViewComponent
    {
        /// <summary>
        /// Alerts 视图组件
        /// 可以异步，也可以同步，注意方法名称，同步的时候是Invoke
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.Run(() => (List<string>)ViewBag.ErrorData);

            notificacoes?.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c));

            return View();
        }
    }
}
