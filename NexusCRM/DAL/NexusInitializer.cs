using NexusCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexusCRM.DAL
{
    public class NexusInitializer : System.Data.Entity.DropCreateDatabaseAlways<NexusContext>
    {
        protected override void Seed(NexusContext context)
        {
            var companies = new List<Companies>
            {
                new Companies {CompanyName="Apple",ContactType="Potential Customer",Website=@"apple.com",Phone="(828) 292-0092",LinkedIn="",Address="116 Walden Galleria",City="Buffalo",State="NY",Zip="14227",Country="US",Notes="Hipsters"},
                new Companies {CompanyName="Microsoft",ContactType="Current Customer",Website=@"microsoft.com",Phone="(888) 902-0110",LinkedIn="microsoft",Address="952 Union Rd",City="West Seneca",State="NY",Zip="14224",Country="US",Notes="Enduser friendly"},
                new Companies {CompanyName="Samsung",ContactType="Other",Website=@"",Phone="(211) 393-1145",LinkedIn="samsung-electronics",Address="105 Challenger Rd",City="Ridgefield Park",State="NJ",Zip="07660",Country="US",Notes="Vendor"},
                new Companies {CompanyName="Barns and Nobles",ContactType="Current Customer",Website=@"barnsandnobles.com",Phone="(453) 121-8621",LinkedIn="",Address="105 Challenger Rd",City="Ridgefield Park",State="NJ",Zip="07660",Country="US",Notes="Vendor"},
                new Companies {CompanyName="Disney",ContactType="Potential Customer",Website=@"disney.com",Phone="(665) 319-4589",LinkedIn="",Address="105 Challenger Rd",City="Ridgefield Park",State="NJ",Zip="07660",Country="US",Notes="Vendor"}
            };
            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var people = new List<People>
            {
                new People {CompaniesID=1,FirstName="Steve",LastName="Jobs",Email="steve.jobs@apple.com",Phone="(734) 758-9883",Title="Founder",LinkedIn="",Tags="Follow Up",Notes=""},
                new People {CompaniesID=2,FirstName="Bill",LastName="Gates",Email="gates.bill@microsoft.com",Phone="(646) 290-7143",Title="CEO",LinkedIn="travus-gonzalez-849a121a3",Tags="",Notes="Very wealthy"},
                new People {CompaniesID=3,FirstName="Sam",LastName="Sung",Email="ssung@samsung.com",Phone="(434) 361-9440",Title="President",LinkedIn="",Tags="",Notes=""}
            };
            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();

            var opportunities = new List<Opportunities>
            {
                new Opportunities {CompaniesID=1, ShortDescription="Website Project",Priority="Normal",Stage="Won",Value=5325.14M, Source="Word of mouth",CloseByDate="12/12/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Tech Support",Priority="Normal",Stage="Won",Value=1000.25M, Source="Social Media",CloseByDate="02/25/2021",LossReason="",Notes=""},
                new Opportunities {CompaniesID=1, ShortDescription="Security Audit",Priority="High",Stage="Abandoned",Value=25.05M, Source="Contact Form",CloseByDate="06/01/2021",LossReason="",Notes=""},
                new Opportunities {CompaniesID=3, ShortDescription="Website Project",Priority="Low",Stage="Won",Value=5500.00M, Source="Word of mouth",CloseByDate="11/10/2020",LossReason="Outbid",Notes=""},
                new Opportunities {CompaniesID=1, ShortDescription="Rebranding",Priority="Normal",Stage="Lost",Value=1230.11M, Source="Contact Form",CloseByDate="04/05/2021",LossReason="",Notes=""},
                new Opportunities {CompaniesID=1, ShortDescription="Tech Support",Priority="low",Stage="Lost",Value=230.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Security Audit",Priority="low",Stage="Qualified",Value=644.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Tech Support",Priority="low",Stage="Negotiation",Value=292.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=3, ShortDescription="Security Audit",Priority="low",Stage="Negotiation",Value=100.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=1, ShortDescription="Tech Support",Priority="low",Stage="ContractSent",Value=1090.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Website Project",Priority="low",Stage="Presentation",Value=739.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Tech Support",Priority="low",Stage="Presentation",Value=301.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=3, ShortDescription="Security Audit",Priority="low",Stage="Presentation",Value=373.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=1, ShortDescription="Website Project",Priority="low",Stage="Followup",Value=934.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=3, ShortDescription="Website Project",Priority="low",Stage="Qualified",Value=965.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""},
                new Opportunities {CompaniesID=2, ShortDescription="Tech Support",Priority="low",Stage="Qualified",Value=111.00M, Source="Social Media",CloseByDate="12/24/2020",LossReason="",Notes=""}
            };
            opportunities.ForEach(s => context.Opportunities.Add(s));
            context.SaveChanges();
        }
    }
}