using Application;
using Application.Interfaces;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
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
#if DEBUG
                RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(
                    studentViewModel.Name,
                    studentViewModel.Email,
                    studentViewModel.BirthDate,
                    studentViewModel.Phone);
                if (!registerStudentCommand.IsValid())
                {
                    List<string> errorInfos = new List<string>();
                    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                    {
                        errorInfos.Add(error.ErrorMessage);
                    }
                    ViewBag.ErrorData = errorInfos;
                    return View(studentViewModel);
                        
                }
#endif
                // 执行添加方法
                _studentAppService.Register(studentViewModel);

                ViewBag.success = "Student Registered!";

                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}
