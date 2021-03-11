using NexusCRM.DAL;
using NexusCRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace NexusCRM.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private NexusContext db = new NexusContext();

        // GET: People
        public ActionResult Index()
        {
            List<People> peopleView = new List<People>();

            var people = db.People
                           .Include(c => c.Companies)
                           .ToList();

            return View(people);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(People people)
        {
            if(ModelState.IsValid)
            {
                db.People.Add(people);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            People people = db.People.Find(id);

            if(people == null)
            {
                return HttpNotFound();
            }

            return View(people);
        }

        [HttpPost]
        public ActionResult Edit(People people)
        {
            var personToUpdate = db.People.FirstOrDefault(p => p.PeopleID == people.PeopleID);

            if(personToUpdate != null)
            {
                personToUpdate.FirstName = people.FirstName;
                personToUpdate.LastName = people.LastName;
                personToUpdate.Title = people.Title;
                personToUpdate.Email = people.Email;
                personToUpdate.Phone = people.Phone;
                personToUpdate.LinkedIn = people.LinkedIn;
                personToUpdate.Tags = people.Tags;
                personToUpdate.Notes = people.Notes;
                personToUpdate.CompaniesID = people.CompaniesID;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(people);
        }

        [HttpDelete]
        public ActionResult Delete(int? peopleID)
        {
            if(peopleID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var people = db.People.Find(peopleID);

            if(people == null)
            {
                return HttpNotFound();
            }

            db.People.Remove(people);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}