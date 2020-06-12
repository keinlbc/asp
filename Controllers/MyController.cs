using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using aspcourse.Models;
using Microsoft.AspNetCore.Mvc;
using student.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspcourse.Controllers
{
    public class MyController : Controller
    {

        private readonly StudentContext _context;

        public MyController(StudentContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Students);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

    }
}
