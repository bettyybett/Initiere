using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Initiere.Models;
namespace Initiere.Controllers
{
    public class ProgramariController : Controller
    {
        // GET: Programari
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client
        public ActionResult Index()
        {
            List<Programari> programari = db.Programari.ToList();
            ViewBag.Programari = programari;
            return View();
        }
      
        public ActionResult Programare()
        {
            var mesaj = "Buna! Nu uita sa iti faci o programare!";
            return Content(mesaj);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Programari prog = db.Programari.Find(id);

                if (prog != null)
                {
                    return View(prog);
                }
                return HttpNotFound("Nu s-a putut gasi Programarea cu id-ul: " + id.ToString());
            }
            return HttpNotFound("Lipseste id-ul programarii!");

        }

        [HttpGet]
        public ActionResult Create()
        {
            Programari prog = new Programari();
            prog.AntrenoriList = GetAllAntrenori();
            prog.ClientList = GetAllClienti();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Programari progRequest)
        {
            try
            {
                progRequest.AntrenoriList = GetAllAntrenori();
                progRequest.ClientList = GetAllClienti();
                if (ModelState.IsValid)
                { //vom sterge ulterior
                  // antrenoriRequest.Clnt = (ICollection<Client>)db.Clienti.FirstOrDefault(
                  //   p => p.IdClient.Equals(1));
                    db.Programari.Add(progRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(progRequest);
            }
            catch (Exception e)
            {
                return View(progRequest);
            }
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                Programari prog = db.Programari.Find(id);
                if (prog == null)
                { return HttpNotFound("Nu s-a putut gasi programarea cu id-ul:" + id.ToString()); }
                prog.AntrenoriList = GetAllAntrenori();
                prog.ClientList = GetAllClienti();
                return View(prog);
            }
            return HttpNotFound("Nu exista programarea cu paramtreul specificat");
        }
        [HttpPut]
        public ActionResult Update(int id, Programari progRequest)
        {
            Programari prog= db.Programari.SingleOrDefault(b => b.IdProgramari.Equals(id));
            try

            {
                progRequest.AntrenoriList = GetAllAntrenori();
                progRequest.ClientList = GetAllClienti();
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(prog))
                    {
                        prog.Zi = progRequest.Zi;
                        prog.Luna = progRequest.Luna;
                        prog.An = progRequest.An;
                        prog.IdAntrenori = progRequest.IdAntrenori;
                        prog.IdClient = progRequest.IdClient;
                        db.SaveChanges();
                    }
                    RedirectToAction("Index");
                }
                return View(progRequest);
            }
            catch (Exception e)
            {
                return View(progRequest);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Programari prog= db.Programari.Find(id);
            if (prog != null)
            {

                db.Programari.Remove(prog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound(" " + id.ToString());
        }
        [NonAction]
        public IEnumerable<SelectListItem> GetAllAntrenori()
        {var selectList = new List<SelectListItem>();
            foreach(var cover in db.Antrenori.ToList())
            {selectList.Add(new SelectListItem
            {   Value = cover.IdAntrenori.ToString(),
                Text = cover.Nume});
            }
            return selectList;
        }
        public IEnumerable<SelectListItem> GetAllClienti()
        {
            var selectList = new List<SelectListItem>();
            foreach (var clt in db.Clienti.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = clt.IdClient.ToString(),
                    Text = clt.Nume
                });
            }
            return selectList;
        }
    }
}