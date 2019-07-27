﻿using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcModels.Controllers
{
    public class HomeController: Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int? id)
        {
            Person person;
            if (id.HasValue && (person = repository[id.Value]) != null)
                return View(person);
            else
                return NotFound();
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);
    }
}