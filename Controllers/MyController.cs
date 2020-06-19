using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Xml.Serialization;
using aspcourse.Models;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            var students = _context.Students
                .Include(s => s.notes)
                .ToList();
            
            return View(students);
        }


        public IActionResult Show(int id)
        {
            return View(_context.Students.First(s => s.Id == id));
        }

        [HttpGet]
        public IActionResult New()
        {

            return View();
        }

        [HttpPost]
        public IActionResult New(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            TempData["message"] = "success";
            return RedirectToAction("Edit", new { id = student.Id });
        }

        [HttpGet]
        public  IActionResult Edit(int id)
        {
            var student =  _context.Students
                .Include(s => s.notes)
                .First(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student,ICollection<Note> notes)
        {

            if (ModelState.IsValid)
            {
                student.notes = notes;
                _context.Update(student);


                _context.SaveChanges();
                TempData["message"] = "success";
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var m in allErrors)
                    TempData["message"] = m.ErrorMessage;
            }
            return RedirectToAction("Edit", new { id = student.Id });
        }
        
        public IActionResult Delete(int id, Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
            TempData["message"] = "success";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Produces("application/xml")]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public IActionResult ShowXml(int id)
        {
            Student s = _context.Students.Include(s=>s.notes).First(s => s.Id == id);

            //XElement xml = new XElement("Student",

            //    new XElement("firstname", s.firstname),
            //    new XElement("lastname", s.lastname),
            //    new XElement("egn", s.egn),
            //    new XElement("notes", "")
            //    );
            

                    
            return Ok(s);

        }

        [Consumes("application/xml")]
        [HttpPost]
      
        public IActionResult Input([FromBody] Student student)
        {
            if (ModelState.IsValid) {
                Student s = new Student();
                s = student;
                if(_context.Students.Any(old=>old.Id == s.Id))
                {
                    _context.Update(s);
                }
                else
                {
                    _context.Add(s);
                }
                


                _context.SaveChanges();
                return Ok(s);

            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Ok(allErrors);
            }

            

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

    }
}
