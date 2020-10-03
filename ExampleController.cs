using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult AllEmployees()
        {
            var context = new LttsEntities();
            var model = context.EmpTables.ToList();
            return View(model);
        }
        public ViewResult Find(string id)
        {
            int empID = int.Parse(id);
            var context = new LttsEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == empID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new LttsEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == emp.EmpID);
            model.EmpName = emp.EmpName;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
        
        public ViewResult NewEmployee()
        {
            var model = new EmpTable();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            var context = new LttsEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
            


    }
}