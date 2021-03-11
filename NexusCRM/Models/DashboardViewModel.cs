using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexusCRM.Models
{
    public class DashboardViewModel
    {
        public int TotalCompanies { get; set; }
        public int TotalPeople { get; set; }
        public int TotalOpportunities { get; set; }
        public decimal TotalOpportunityValue { get; set; }

        public int TotalOpportunitiesWon { get; set; }
        public int TotalOpportunitiesLost { get; set; }
        public int TotalOpportunitiesAbandoned { get; set; }

        public int TotalStageQualified { get; set; }
        public int TotalStageFollowup { get; set; }
        public int TotalStagePresentation { get; set; }
        public int TotalStageContractSent { get; set; }
        public int TotalStageNegotiation { get; set; }

        public decimal TotalStageQualifiedValue { get; set; }
        public decimal TotalStageFollowupValue { get; set; }
        public decimal TotalStagePresentationValue { get; set; }
        public decimal TotalStageContractSentValue { get; set; }
        public decimal TotalStageNegotiationValue { get; set; }

        public List<Opportunities> LatestOpportunities { get; set; }
        public List<Companies> NewestCompanies { get; set; }
    }
}