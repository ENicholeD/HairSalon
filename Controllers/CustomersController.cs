using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Customer.Controllers
{
  public class CustomersController : Controller
  {
    private readonly SalonContext _db;
    public StoreController(SalonContext db)
    {
      _db = db;
    }
    [HttpGet]
    public ActionResult Index()
    {
      List<Customer> model = _db.Customers.Include(customers => customers.cutsomerName).ToList();
      return View(model);
    }
    [HttpGet]
    public ActionResult Create()
    {
         
        ViewBag.customerId = new SelectList(_db.Stylists, "stylistsId", "LastName");
        return View();
    }
    [HttpPost]
    public ActionResult Create(Customer customer)
    {
        _db.Stores.Add(customer);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
     [HttpGet]
    public ActionResult Show(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.customerId == id);

      return View(thisCustomer);
    }
     [HttpGet]
    public ActionResult Delete(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.customerId == id);
      return View(thisCustomer);
    }
     [HttpPost, ActionName("Delete")]
    public ActionResult Destroy(int id)
    {
      Store thisCustomer = _db.Customers.FirstOrDefault( customers => customers.customerId ==  id);
      _db.customers.Remove(thisCustomer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     [HttpGet]
    public ActionResult Update(int id)
    {
      Store thisCustomer = _db.Customers.FirstOrDefault( customers => customers.customerId == id);
      ViewBag.StylistId = new SelectList(_db.stylists, "StylistsId", "LastName");
      return View(thisCustomer);
    }
    [HttpPost, ActionName("Update")]
    public ActionResult Update(Customer customer)
    {
        _db.Entry(customer).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}