using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvc.Models;
namespace DemoMvc.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> emplist = null;
        public void CreateList()
        {
             emplist = new List<Employee>
            {
                new Employee{Empno=101,Name="Tom",Salary=40000,Dept="HR"},
                new Employee{Empno=102,Name="Jerry",Salary=70000,Dept="TR"},
                new Employee{Empno=103,Name="Raj",Salary=80000,Dept="HR"},
                new Employee{Empno=104,Name="Ali",Salary=60000,Dept="TR"},
                new Employee{Empno=105,Name="Jay",Salary=30000,Dept="HR"},
                new Employee{Empno=106,Name="Bob",Salary=20000,Dept="TR"}
            };
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(int empid)
        {
            CreateList();
            var data = emplist.Where(emp => emp.Empno == empid).FirstOrDefault();
            ViewBag.Emp = data;
            return View();
        }
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
            ViewBag.Date = dt;
            string name = "Tom";
            ViewBag.Name = name;
            TempData["Name"] = ViewBag.Name;
            return View();
        }
        public ActionResult Display()
        {
            ViewBag.Name = TempData["Name"];

            Employee emp = new Employee { Empno = 101, Name = "Tom", Salary = 70000, Dept = "HR" };
            return View(emp);
        }
        public ActionResult List()
        {
            CreateList();
            ViewBag.Name = TempData["Name"];
            
            // extension methods
            int count = emplist.Count();
            int total = emplist.Sum(emp => emp.Salary);
            ViewData["Count"] = count;
            ViewBag.TotalSalary = total;
            ViewBag.Name = TempData["Name"];
            return View(emplist);
        }

    }
}