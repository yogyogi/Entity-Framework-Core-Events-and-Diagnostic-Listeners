using EFCoreLogging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreLogging.Controllers
{
    public class LogController : Controller
    {
        private CompanyContext context;
        public LogController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            return View();
        }

        // EF Core events
        public IActionResult Event()
        {
            context.Add(
                new Employee
                {
                    Name = "Rock",
                    Company = "WWE",
                    Designation = "Heavy Weight Champion"
                });

            //var e = context.Employee.FirstOrDefault();

            //e.Name = "Brock";

            //context.Remove(context.Employee.Where(a => a.Name == "John").FirstOrDefault());

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // EF Core Diagnostic Listeners
        public IActionResult DL()
        {
            context.Add(
                new Employee
                {
                    Name = "Rock",
                    Company = "WWE",
                    Designation = "Heavy Weight Champion"
                });

            context.Remove(context.Employee.Where(a => a.Name == "John").FirstOrDefault());

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
