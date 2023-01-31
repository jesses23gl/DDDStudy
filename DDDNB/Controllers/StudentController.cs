using Application;
using Application.Interfaces;
using AutoMapper;
using Domain.Commands;
using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IMapper _maooer;

        public readonly DomainNotificationHandler _notifications;

        public StudentController(IStudentAppService studentAppService,IMapper mapper, INotificationHandler<DomainNotification> notification)
        
        {
            _studentAppService = studentAppService;
            _notifications = (DomainNotificationHandler?)notification;

        }
        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                Guid id = Guid.NewGuid();
                studentViewModel.Id = id;
                // 视图模型验证
                if (!ModelState.IsValid)
                    return View(studentViewModel);

                #region klk
#if DEBUG
                //RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(
                //    studentViewModel.Name,
                //    studentViewModel.Email,
                //    studentViewModel.BirthDate,
                //    studentViewModel.Phone);
                //if (!registerStudentCommand.IsValid())
                //{
                //    List<string> errorInfos = new List<string>();
                //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                //    {
                //        errorInfos.Add(error.ErrorMessage);
                //    }
                //    ViewBag.ErrorData = errorInfos;
                //    return View(studentViewModel);
                        
                //}
#endif
                #endregion
                // 执行添加方法
                _studentAppService.Register(studentViewModel);

                if (!_notifications.HasNotifications())
                {
                    ViewBag.success = "Student Registered!";

                }

                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}
