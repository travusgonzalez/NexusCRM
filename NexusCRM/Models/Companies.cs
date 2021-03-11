using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NexusCRM.Models
{
    public class Companies
    {
        public int CompaniesID { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Contact Type")]
        public string ContactType { get; set; }

        [RegularExpression(@"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)", ErrorMessage ="Invalid Url")]
        public string Website { get; set; }
        
        [Phone]
        public string Phone { get; set; }

        public string LinkedIn { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage="Invalid Zip")]
        public string Zip { get; set; }
        
        public string Country { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<People> Employees { get; set; }
    }
}