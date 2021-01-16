using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Initiere.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Initiere.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client
        public ActionResult Index()
        {
            List<Client> clients = db.Clienti.ToList();
            ViewBag.Clienti = clients;
            return View();
        }
        public ActionResult Client()
        {
            var mesaj = "Buna! Bine ai revenit pe pagina noastra.";
            return Content(mesaj);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Client clnt = db.Clienti.Find(id);

                if (clnt != null)
                {
                    return View(clnt);
                }
                return HttpNotFound("Nu s-a putut gasi clientul cu id-ul: " + id.ToString());
            }
            return HttpNotFound("Lipseste id-ul clientului!");

        }

        [HttpGet]
        public ActionResult Create()
        {
            Client clnt = new Client();
            //clnt.ProgramariList = GetAllProgramari();
            clnt.Cont = new Cont();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client clientRequest)
        {
            try
            {
                //contRequest.ProgramariList = GetAllProgramari();
                if (ModelState.IsValid)
                { //vom sterge ulterior
                  // antrenoriRequest.Clnt = (ICollection<Client>)db.Clienti.FirstOrDefault(
                  //   p => p.IdClient.Equals(1));
                    db.Clienti.Add(clientRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(clientRequest);
            }
            catch (Exception e)
            {
                return View(clientRequest);
            }
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                Client clnt = db.Clienti.Find(id);
               
                if (clnt == null)
                { return HttpNotFound("Nu s-a putut gasi clientul cu id-ul:" + id.ToString()); }
                //clnt.ProgramariList = GetAllProgramari();
                return View(clnt);
            }
            return HttpNotFound("Nu exista clientul cu paramtreul specificat");
        }
        [HttpPut]
        public ActionResult Update(int id, Client clientRequest)
        {
            Client clnt = db.Clienti.SingleOrDefault(b => b.IdClient.Equals(id));
            Cont cont = db.Cont.SingleOrDefault(b => b.IdCont.Equals(id));
            try

            {
                //clientRequest.ProgramariList = GetAllProgramari();
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(clnt))
                    {
                        clnt.Nume = clientRequest.Nume;
                        //clnt.AreCont = clientRequest.AreCont;
                        clnt.Cont.UserName = clientRequest.Cont.UserName;
                        clnt.Cont.Password = clientRequest.Cont.Password;
                        db.SaveChanges();
                    }
                    RedirectToAction("Index");
                }
                return View(clientRequest);
            }
            catch (Exception e)
            {
                return View(clientRequest);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Client clnt = db.Clienti.Find(id);
            Cont cont = db.Cont.Find(id);
            if (clnt != null)
            {

                db.Clienti.Remove(clnt);
                db.Cont.Remove(cont);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("nu s a gasit asta" + id.ToString());
        }

        /*public IEnumerable<SelectListItem> GetAllProgramari()
        {
            var selectList = new List<SelectListItem>();
            foreach (var prog in db.Programari.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = prog.IdProgramari.ToString(),
                    Text = prog.Zi.ToString() + prog.Luna.ToString() + prog.An.ToString()
                });

            }
            return selectList;
        }*/
    }
}