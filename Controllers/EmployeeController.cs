using EmployeeTest.Data;
using EmployeeTest.Models;
using EmployeeTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTest.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields
        private readonly IEmployeeRepository _repository;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            var employees = _repository.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public JsonResult GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            return Json(employee);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertEmployee(employee);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateEmployee(employee);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _repository.DeleteEmployee(id);
            return Json(new { success = true });
        }
        #endregion
    }
}
