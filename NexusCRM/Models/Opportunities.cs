using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace NexusCRM.Models
{
    public class Opportunities
    {
        public int OpportunitiesID { get; set; }
        public string ShortDescription { get; set; }
        public string Priority { get; set; }
        public string Stage { get; set; }
        public decimal Value { get; set; }
        public string CloseByDate { get; set; }
        public string Source { get; set; }
        public string LossReason { get; set; }
        public string Notes { get; set; }

        public int CompaniesID { get; set; }
        public Companies Companies { get; set; }
    }
}