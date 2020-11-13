using FirstMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvc.Controllers
{
    public class UserController : Controller
    {
        mvcFirstEntities db = new mvcFirstEntities();

        // GET: User
        public ActionResult Index()
        {
            ViewBag.firstList = db.User.ToList();
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User use = db.User.FirstOrDefault(x => x.ID == id);
            if (use == null)
            {
                return HttpNotFound();
            }
            ViewBag.singlePro = use;
            return View();
        }
        [HttpPost]
        public ActionResult Detail(int id, string FullName,string Email,string Phone)
        {
            
            User use = db.User.FirstOrDefault(x => x.ID == id);
            if (use == null)
            {
                return HttpNotFound();
            }
            use.FullName = FullName;
            use.Email = Email;
            use.Phone = Phone;
            db.SaveChanges();
            ViewBag.singlePro = use;
            return RedirectToAction("Index");
        }
    }
}