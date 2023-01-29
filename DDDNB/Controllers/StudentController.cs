using Application.Interfaces;
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
    }
}
