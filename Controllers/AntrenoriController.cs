using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Initiere.Models;


namespace Initiere.Controllers
{
    public class AntrenoriController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public AntrenoriController()
        { }
        public ActionResult Index()
        {
            List<Antrenori> antrenori = db.Antrenori.ToList();
            ViewBag.Antrenori = antrenori;
            return View();
        }

        // GET: Antrenori
        /*public ActionResult Random()
        {
            var clienti = new List<Client>
             { new Client{Nume = "Popescu Andreea" },
                new Client{Nume = "Vasile Ioana" } };
            var antrenor_principal = new Antrenori() { Nume = "Rusu Eduard" };

            return View(clienti);
        }*/
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult NumeAntrenor(string nume)
        {
            return Content(nume);
        }
        public ActionResult Antrenor()
        {
            var antrenor_principal = "Eduard Rusu";
            return Content(antrenor_principal);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Antrenori antre = db.Antrenori.Find(id);

                if (antre != null)
                {
                    return View(antre);
                }
                return HttpNotFound("Nu s-a putut gasi antrenorul cu id-ul: " + id.ToString());
            }
            return HttpNotFound("Lipseste id-ul antrenorului!");
            
        }

        [HttpGet]
        public ActionResult CreateAntrenori()
        {  
            Antrenori antrenor = new Antrenori();
            
            antrenor.Clnt = new List<Client>();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAntrenori(Antrenori antrenoriRequest)
        {
            try
            {
               
                if (ModelState.IsValid)
                { //vom sterge ulterior
                   // antrenoriRequest.Clnt = (ICollection<Client>)db.Clienti.FirstOrDefault(
                     //   p => p.IdClient.Equals(1));
                    db.Antrenori.Add(antrenoriRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(antrenoriRequest);
            }
            catch (Exception e)
            {
                return View(antrenoriRequest);
            }
        }
        [HttpGet]
        public ActionResult UpdateAntrenori(int? id)
        {
            if (id.HasValue)
            {
                Antrenori antre = db.Antrenori.Find(id);
                if (antre == null)
                { return HttpNotFound("Nu s-a putut gasi antrenorul cu id-ul:" + id.ToString()); }
               
                return View(antre);
            }
            return HttpNotFound("Nu exista antrenorul cu paramtreul specificat");
        }
        [HttpPut]
        public ActionResult UpdateAntrenori(int id, Antrenori antreRequest)
        {
            Antrenori antre = db.Antrenori.SingleOrDefault(b => b.IdAntrenori.Equals(id));
            try
                    
            {
               
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(antre))
                    {
                        antre.Nume = antreRequest.Nume;
                        db.SaveChanges();
                    }
                    RedirectToAction("Index");
                }
                return View(antreRequest);
            }
            catch (Exception e)
            {
                return View(antreRequest);
            }
        }
        [HttpDelete]
        public ActionResult DeleteAntrenori(int id)
        {
            Antrenori antre = db.Antrenori.Find(id);
            if (antre != null)
            {

                db.Antrenori.Remove(antre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound(" " + id.ToString());
        }
       
        
    }
}