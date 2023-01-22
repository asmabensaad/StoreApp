using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class EmployerController : Controller
    {

        private readonly ApplicationDBContext _db;

        public EmployerController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employer> objEmployerList = _db.Employers.ToList();

            return View(objEmployerList);
        }


        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employer obj)
        {
            if (obj.Name == obj.password)
            {
                ModelState.AddModelError("CustomerError", "the Name cannot exactly match the Password.");
            }
            if (ModelState.IsValid)
            {
                _db.Employers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "employer added successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Login()
        {

            return View();
        }
    }
}
