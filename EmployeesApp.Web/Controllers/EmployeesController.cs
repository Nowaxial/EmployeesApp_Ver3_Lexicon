using EmployeesApp.Web.Models;
using EmployeesApp.Web.Services;
using EmployeesApp.Web.Services.Interfaces;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesApp.Web.Controllers
{
    public class MyLogFilterAttribute(ILogger<MyLogFilterAttribute> logger) 
        : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Action is about to be executed");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogWarning("Action has now been executed");
        }
    }


    public class EmployeesController(IEmployeeService service) : Controller
    {

        [TypeFilter(typeof(MyLogFilterAttribute))]
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = service.GetAll();

            var viewModel = new IndexVM()
            {
                EmployeeVMs = model
                .Select(e => new IndexVM.EmployeeVM()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ShowAsHighlighted = service.CheckIsVIP(e),
                })
                .ToArray()
            };

            return View(viewModel);
        }

        [TypeFilter(typeof(MyLogFilterAttribute))]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

            
        [HttpPost("create")]
        public IActionResult Create(CreateVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            Employee employee = new()
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
            };

            service.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        [TypeFilter(typeof(MyLogFilterAttribute))]
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var model = service.GetById(id);

            DetailsVM viewModel = new()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
            };

            return View(viewModel);
        }
    }
}
