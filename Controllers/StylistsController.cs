using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller{
        
        private readonly SalonContext _db;

        public StylistsController(SalonContext db)
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
        Stylists thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.stylistId == id);
        List<Customers> customerList = _db.Customers.Where(customers => customers.customerId == id).ToList();
        ViewBag.RelatedCustomers = customerList;
        return View(thisStylist);
        }
         [HttpGet]
        public ActionResult Delete(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.stylistId == id);
        return View(thisStylist);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.stylistId ==  id);
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
        Stylists thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.stylistId == id);
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