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
            List<Stylist> model = _db.Stylists.ToList();
            return View(model);
        }
          [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
         [HttpGet]
        public ActionResult Show(int id)
        {
        Stylist thisDish = _db.Stylists.FirstOrDefault( stylists => stylists.StylistId == id);
        List<Customer> CustomerList = _db.Customers.Where(customers => customers.StylistId == id).ToList();
        ViewBag.RelatedCustomers = CustomerList;
        return View(thisDish);
        }
         [HttpGet]
        public ActionResult Delete(int id)
        {
        Stylist thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.StylistId == id);
        return View(thisStylist);
        }
         [HttpPost, ActionName("Delete")]
        public ActionResult Destroy(int id)
        {
        Stylist thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.StylistId ==  id);
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
          [HttpGet]
        public ActionResult Update(int id)
        {
        Stylist thisStylist = _db.Stylists.FirstOrDefault( stylists => stylists.StylistId == id);
        return View(thisStylist);
        }
         [HttpPost, ActionName("Update")]
        public ActionResult Update(Stylist stylist)
        {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}