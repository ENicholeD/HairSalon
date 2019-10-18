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
      List<Customers> model = _db.Customers.Include(customers => customers.cutsomerName).ToList();
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
  }
}