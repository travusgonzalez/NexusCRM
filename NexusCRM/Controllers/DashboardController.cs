using NexusCRM.DAL;
using NexusCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexusCRM.Controllers
{
    public class DashboardController : Controller
    {
        private NexusContext db = new NexusContext();

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            model.TotalCompanies = db.Companies.Count();
            model.TotalPeople = db.People.Count();
            model.TotalOpportunities = db.Opportunities.Count();

            decimal totalValue = 0.0M;
            foreach(var opp in db.Opportunities.ToList())
            {
                totalValue += opp.Value;
            }
            model.TotalOpportunityValue = totalValue;

            model.LatestOpportunities = db.Opportunities.OrderByDescending(o => o.OpportunitiesID)
                                                      .Take(5)
                                                      .ToList();

            model.NewestCompanies = db.Companies.OrderByDescending(c => c.CompaniesID)
                                                .Take(5)
                                                .ToList();

            model.TotalOpportunitiesWon = db.Opportunities.Where(o => o.Stage == "Won").Count();
            model.TotalOpportunitiesLost = db.Opportunities.Where(o => o.Stage == "Lost").Count();
            model.TotalOpportunitiesAbandoned = db.Opportunities.Where(o => o.Stage == "Abandoned").Count();


            decimal totalStageValue = 0.0M;
            foreach (var opp in db.Opportunities.Where(o => o.Stage == "Qualified").ToList())
            {
                totalStageValue += opp.Value;
            }
            model.TotalStageQualifiedValue = totalStageValue;
            totalStageValue = 0.0M;


            foreach (var opp in db.Opportunities.Where(o => o.Stage == "Followup").ToList())
            {
                totalStageValue += opp.Value;
            }
            model.TotalStageFollowupValue = totalStageValue;
            totalStageValue = 0.0M;


            foreach (var opp in db.Opportunities.Where(o => o.Stage == "Presentation").ToList())
            {
                totalStageValue += opp.Value;
            }
            model.TotalStagePresentationValue = totalStageValue;
            totalStageValue = 0.0M;


            foreach (var opp in db.Opportunities.Where(o => o.Stage == "ContractSent").ToList())
            {
                totalStageValue += opp.Value;
            }
            model.TotalStageContractSentValue = totalStageValue;
            totalStageValue = 0.0M;


            foreach (var opp in db.Opportunities.Where(o => o.Stage == "Negotiation").ToList())
            {
                totalStageValue += opp.Value;
            }
            model.TotalStageNegotiationValue = totalStageValue;

            model.TotalStageQualified = db.Opportunities.Where(o => o.Stage == "Qualified").Count();
            model.TotalStageFollowup = db.Opportunities.Where(o => o.Stage == "Followup").Count();
            model.TotalStagePresentation = db.Opportunities.Where(o => o.Stage == "Presentation").Count();
            model.TotalStageContractSent = db.Opportunities.Where(o => o.Stage == "ContractSent").Count();
            model.TotalStageNegotiation = db.Opportunities.Where(o => o.Stage == "Negotiation").Count();

            return View(model);
        }
    }
}