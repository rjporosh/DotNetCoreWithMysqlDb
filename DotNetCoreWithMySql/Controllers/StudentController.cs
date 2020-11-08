﻿using System;
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
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
