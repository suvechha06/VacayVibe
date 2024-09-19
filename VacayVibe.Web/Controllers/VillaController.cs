using Microsoft.AspNetCore.Mvc;
using VacayVibe.Domain.Entities;
using VacayVibe.Infrastructure.Data;

namespace VacayVibe.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if ((villa.Name == villa.Description))
            {
                ModelState.AddModelError("Name", "The Name and Description cannot be same");                
            }
            if (ModelState.IsValid)
            {
                _context.Villas.Add(villa);
                _context.SaveChanges();
                TempData["success"] = "Villa created successfully!";
                return RedirectToAction(nameof(Index)); //other alternative, you can also simply return "Index"
            }
            return View(villa);
        }

        public IActionResult Update(int villaId)
        {
            Villa? villa = _context.Villas.FirstOrDefault(u => u.Id == villaId);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id>0)
            {
                _context.Villas.Update(villa);
                _context.SaveChanges();
                TempData["success"] = "Villa details updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(villa);
        }

        public IActionResult Delete(int villaId)
        {
            Villa? villa = _context.Villas.FirstOrDefault(u => u.Id == villaId);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? villaFromDb = _context.Villas.FirstOrDefault(u => u.Id == villa.Id);
            if (villaFromDb != null)
            {
                _context.Villas.Remove(villaFromDb);
                _context.SaveChanges();
                TempData["success"] = "Villa deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Villa could not be deleted!"; 
            return View(villa);
        }
    }
}
