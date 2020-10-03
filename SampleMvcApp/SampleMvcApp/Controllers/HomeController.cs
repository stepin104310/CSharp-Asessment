using System.Linq;
using System.Web.Mvc;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //Read and display all the details of the employee
        public ViewResult EmployeeDetails()
        {
            var context = new lttstrainingEntities();
            var model = context.Employees.ToArray();
            return View(model);
        } 

        //Find the Employee data and edit the data
        public ViewResult Find(string id)
        {
            var empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Find(Employee emp)
        {
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == emp.EmployeeId);
            model.EmployeeName = emp.EmployeeName;
            model.EmployeeAddress = emp.EmployeeAddress;
            model.EmployeeSalary = emp.EmployeeSalary;
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }

        //Create new Employee Registration
        public ViewResult NewEmployee()
        {
            var model = new Employee();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewEmployee(Employee emp)
        {
            var context = new lttstrainingEntities();
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }

        //Delete or Remove any employee data 
        public ViewResult Delete(string id)
        {
            var empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id, string confirmButton)
        {
            int empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            context.Employees.Remove(model);
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }
    }
} 