using Microsoft.AspNetCore.Mvc;
using NexusCRM.DAL;
using NexusCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NexusCRM.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private NexusContext db = new NexusContext();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Companies company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Companies company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Companies company)
        {
            var companyToUpdate = db.Companies.FirstOrDefault(c => c.CompaniesID == company.CompaniesID);

            if (companyToUpdate != null && ModelState.IsValid)
            {
                companyToUpdate.CompanyName = company.CompanyName;
                companyToUpdate.ContactType = company.ContactType;
                companyToUpdate.Website = company.Website;
                companyToUpdate.Phone = company.Phone;
                companyToUpdate.LinkedIn = company.LinkedIn;
                companyToUpdate.Address = company.Address;
                companyToUpdate.City = company.City;
                companyToUpdate.State = company.State;
                companyToUpdate.Zip = company.Zip;
                companyToUpdate.Country = company.Country;
                companyToUpdate.Notes = company.Notes;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        [HttpDelete]
        public ActionResult Delete(int? companyID)
        {
            if (companyID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Companies company = db.Companies.Find(companyID);

            if (company == null)
            {
                return HttpNotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}