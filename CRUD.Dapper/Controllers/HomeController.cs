using CRUD.Dapper.Models;
using CRUD.Dapper.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Dapper.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repo = new ProductRepository();
        // GET: Home
        public ActionResult Index()
        {
            
                return View(_repo.GetAll());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetById(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Product _product)
        {
            _repo.Insert(_product);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {           
            return View(_repo.GetById(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Product _product)
        {
            _repo.Update(_product);
             return RedirectToAction("Index");
           
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
          
            return View(_repo.GetById(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
