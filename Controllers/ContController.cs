using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Initiere.Models;
namespace Initiere.Controllers
{
    public class ContController : Controller
    {
        // GET: Cont
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Cont> cont = db.Cont.ToList();
            ViewBag.Cont = cont;
            return View();
        }
        public ActionResult Cont()
        {
            var warrning = "Oops! Se pare ca nu aveti cont, va rugam sa va inregistrati.";
            return Content(warrning);
        }
        

    }
}