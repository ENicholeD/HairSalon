using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class CustomerController : Controller
  {
    private readonly SalonContext _db;
    public CustomerController(SalonContext db)
    {
      _db = db;
    }
    [HttpGet]
    public ActionResult Index()
    {
      List<Customer> model = _db.Customers.ToList();
      return View(model);
    }
    [HttpGet]
    public ActionResult Create()
    { 
        return View();
    }
    [HttpPost]
    public ActionResult Create(Customer customer)
    {
        _db.Customers.Add(customer);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
     [HttpGet]
    public ActionResult Show(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.CustomerId == id);

      return View(thisCustomer);
    }
     [HttpGet]
    public ActionResult Delete(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.CustomerId == id);
      return View(thisCustomer);
    }
     [HttpPost, ActionName("Delete")]
    public ActionResult Destroy(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.CustomerId ==  id);
      _db.Customers.Remove(thisCustomer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     [HttpGet]
    public ActionResult Update(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault( customers => customers.CustomerId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistsId", "LastName");
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