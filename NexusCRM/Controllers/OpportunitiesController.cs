using NexusCRM.DAL;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using NexusCRM.Models;
using System.Net;

namespace NexusCRM.Controllers
{
    [Authorize]
    public class OpportunitiesController : Controller
    {
        private NexusContext db = new NexusContext();

        // GET: Opportunities
        public ActionResult Index()
        {
            var opportunities = db.Opportunities
                                  .Include(c => c.Companies)
                                  .ToList();
            return View(opportunities);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Opportunities opp)
        {
            if (ModelState.IsValid)
            {
                db.Opportunities.Add(opp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opp);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Opportunities opp = db.Opportunities.Find(id);

            if (opp == null)
            {
                return HttpNotFound();
            }

            return View(opp);
        }

        [HttpPost]
        public ActionResult Edit(Opportunities opp)
        {
            var oppToUpdate = db.Opportunities.FirstOrDefault(c => c.OpportunitiesID == opp.OpportunitiesID);

            if (oppToUpdate != null)
            {
                oppToUpdate.CompaniesID = opp.CompaniesID;
                oppToUpdate.ShortDescription = opp.ShortDescription;
                oppToUpdate.Priority = opp.Priority;
                oppToUpdate.Stage = opp.Stage;
                oppToUpdate.Value = opp.Value;
                oppToUpdate.CloseByDate = opp.CloseByDate;
                oppToUpdate.Source = opp.Source;
                oppToUpdate.LossReason = opp.LossReason;
                oppToUpdate.Notes = opp.Notes; 

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opp);
        }

        [HttpDelete]
        public ActionResult Delete(int? oppID)
        {
            if (oppID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Opportunities opp = db.Opportunities.Find(oppID);

            if (opp == null)
            {
                return HttpNotFound();
            }

            db.Opportunities.Remove(opp);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}