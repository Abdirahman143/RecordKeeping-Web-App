using Microsoft.AspNetCore.Mvc;
using RecordKeeping.Data;
using RecordKeeping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordKeeping.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> ObjList = _db.Expenses;
            return View(ObjList);
        }
        //GET_CREATE
        public IActionResult Create()
        {
            return View();

        }
        //GET_POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //DELETE_GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
         

        }





        //DELETE_POST

        public IActionResult DeletePost(int? id)
            {
                var obj = _db.Expenses.Find(id);
                if(obj==null)
                {
                    return NotFound();
                }
                
                    _db.Expenses.Remove(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
           
            }

        //  GET UPDATE
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }

        //POST UPDATE
        //GET_POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }



    }
}
