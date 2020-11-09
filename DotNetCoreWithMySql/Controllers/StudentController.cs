using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWithMySql.Models.DatabaseContext;
using DotNetCoreWithMySql.Models.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWithMySql.Controllers
{
    public class StudentController : Controller
    {
        private MyDbContext context;

        public StudentController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> model = context.Set<Student>().ToList().Select(s => new Student
            {
                Id = s.Id,
                Name = $"{s.Name} ",
                Age = s.Age,
                Gender =s.Gender,
                Phone = s.Phone,
                Address = s.Address,
                Permanent_Address = s.Permanent_Address,
                E_Mail = s.E_Mail
            });
            return View("Index", model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student model = new Student();
            if (id > 0)
            {
                Student student = context.Set<Student>().SingleOrDefault(c => c.Id == id);
                if (student != null)
                {
                    model.Id = student.Id;
                    model.Name = student.Name;
                    model.Age = student.Age;
                    model.Address = student.Address;
                    model.Permanent_Address = student.Permanent_Address;
                    model.Gender = student.Gender;
                    model.Phone = student.Phone;
                    model.E_Mail = student.E_Mail;
                }
            }
            return View("~/Views/Student/Details.cshtml", model);
        }
        [HttpGet]
        // GET: Student/Create
        public ActionResult Create()
        {
            Student model = new Student();
            return View("Create",model);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Student student = new Student();
                 //   {
                        // AddedDate = DateTime.UtcNow
                  //  } : context.Set<Student>().SingleOrDefault(s => s.Id == id);
                    student.Name = model.Name;
                    student.Age = model.Age;
                    student.Address = model.Address;
                    student.Permanent_Address = model.Permanent_Address;
                    student.Gender = model.Gender;
                    student.Phone = model.Phone;
                    student.E_Mail = model.E_Mail;
                    // student.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    // student.ModifiedDate = DateTime.UtcNow;
                   // if (isNew)
                   // {
                        context.Add(student);
                  //  }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student model = new Student();
           
                Student student = context.Set<Student>().SingleOrDefault(c => c.Id == id);
                if (student != null)
                {
                    //model.Id = student.Id;
                    model.Name = student.Name;
                    model.Age = student.Age;
                    model.Address = student.Address;
                    model.Permanent_Address = student.Permanent_Address;
                    model.Gender = student.Gender;
                    model.Phone = student.Phone;
                    model.E_Mail = student.E_Mail;
                }
            
            return View("~/Views/Student/Edit.cshtml", model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Student student = context.Set<Student>().SingleOrDefault(c => c.Id == id);
                   

                 //   Student student = new Student();
                  // {
                  //      AddedDate = DateTime.UtcNow
                  //  } : context.Set<Student>().SingleOrDefault(s => s.Id == id);
                    student.Name = model.Name;
                    student.Age = model.Age;
                    student.Address = model.Address;
                    student.Permanent_Address = model.Permanent_Address;
                    student.Gender = model.Gender;
                    student.Phone = model.Phone;
                    student.E_Mail = model.E_Mail;
                    // student.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    // student.ModifiedDate = DateTime.UtcNow;
                    //   if (isNew)
                    //   {
                    //      context.Add(student);
                    //  }
                    context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = context.Set<Student>().SingleOrDefault(c => c.Id == id);
            Student model = student;
          //  {
           //     Name = $"{student.Name}"
          //  };
            return View("~/Views/Student/Delete.cshtml", model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection,Student model)
        {
            Student student = context.Set<Student>().SingleOrDefault(c => c.Id == id);
            context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
