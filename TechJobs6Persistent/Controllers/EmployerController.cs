using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController (JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer>? employers = context.Employers?.ToList();
            return View(employers);
        }

        [HttpGet]
        [Route("/Create")]
        public IActionResult Create()
        {
            AddEmployerViewModel? addEmployerViewModel = new AddEmployerViewModel(); //?????????
            return View(addEmployerViewModel);
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult Create(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer anEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers?.Add(anEmployer);
                context.SaveChanges();

                return Redirect("/Create");
            }
                
            return View();

        }


        

        public IActionResult About(int id)
        {
            Employer employer = context.Employers?.Find(id);

            return View(employer);
        }

    }
}

