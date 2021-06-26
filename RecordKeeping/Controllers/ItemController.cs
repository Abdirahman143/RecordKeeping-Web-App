using Microsoft.AspNetCore.Mvc;
using RecordKeeping.Data;
using RecordKeeping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordKeeping.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
             IEnumerable<Item> ObjList = _db.Items;
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
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //DELETE_GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id==0)
            {
                return NotFound();
  
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }





        //DELETE_POST

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Items.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();

            }

            _db.Items.Remove(obj);
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
            
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }

        //POST UPDATE
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
