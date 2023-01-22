using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StockController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Stock> objStockList = _db.Stocklist.ToList();
            return View(objStockList);
        }


        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stock obj)
        {
            if (obj.MSPEREF == "" || obj.position == 0)
            {
                ModelState.AddModelError("CustomerError", "MSPEREF or Position  could not be empty.");
            }
            else
            {
                _db.Stocklist.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "material added successfuly";
                return RedirectToAction("Index");
            }
                 return View(obj);
        }

        //POST

        public IActionResult Edit(string? MSPEREF)
        {
            if (MSPEREF == null || MSPEREF =="")
            {
                return NotFound();
            }
            var productFromDb = _db.Stocklist.Find(MSPEREF);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(u => u.Id == id);
            if (productFromDb == null)
            {
               //_db.SaveChanges();
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stock obj)
        {
            if (obj.MSPEREF == obj.position.ToString())
            {
                ModelState.AddModelError("CustomerError", "the MSPEREF  cannot exactly match the Position.");
            }
            if (ModelState.IsValid)
            {
                _db.Stocklist.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "product updated successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(string? MSPEREF)
        {
            if (MSPEREF == null || MSPEREF == "")
            {
                return NotFound();
            }
            var materielFromDb = _db.Stocklist.Find(MSPEREF);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(u => u.Id == id);
            if (materielFromDb == null)
            {
                return NotFound();
            }
            return View(materielFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string? MSPEREF)
        {
            var obj = _db.Stocklist.Find(MSPEREF);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Stocklist.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "material deleted successfuly";
            return RedirectToAction("Index");
        }

    }



}


    

