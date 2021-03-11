using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NexusCRM.Models
{
    public class People
    {
        public int PeopleID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LinkedIn { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }

        public int CompaniesID { get; set; }
        public Companies Companies { get; set; }
    }
}