using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Stylists.Controllers
{
    public class StylistsController : Controller{
        
        private readonly SalonContext _db;

        public CuisineController(SalonContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Stylists> model = _db.Stylists.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Stylists stylist)
        {
            _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( Stylists => Stylists.StylistId == id);
        // List<Store> storesList = _db.Stores.Where(Stores => Stores.CuisineId == id).ToList();
        // ViewBag.RelatedStores = storesList;
        return View(thisStylist);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( Stylists => Stylists.StylistId == id);
        return View(thisStylist);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( Stylists => Stylists.StylistId ==  id);
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( Stylists => Stylists.StylisteId == id);
        return View(thisStylist);
        }
        [HttpPost, ActionName("Update")]
        public ActionResult Update(Stylists stylist)
        {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

    }
}