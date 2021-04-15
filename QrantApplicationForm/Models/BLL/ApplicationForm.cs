using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QrantApplicationForm.Models.BLL
{
    public class ApplicationForm
    {
        public int Id { get; set; }

        //Brief information about the project
        public string AboutProject { get; set; }

        //Applicant
        public string AppNameSurane { get; set; }
        public string AppOrganizationRepresented { get; set; }
        public string TypeActivityOrganization { get; set; }
        public string ProjectsImplemented { get; set; }

        //Project details
        public string WorkDoneWithinProject { get; set; }
        public string PurposeOfProject { get; set; }
        public string Beneficiaries { get; set; }
        public string ResultsYouGetFromProject { get; set; }
        public string ProjectCostDirections { get; set; }
        public string DoYouHaveSponsorOrSupporter { get; set; }
        public string NameOfProjectManager { get; set; }
        public string ImageCode { get; set; }

        //Aplication Plan
        public string ActionPlan { get; set; }
        public string VideoCode { get; set; }


        //Contact
        public string NameSurnameFatherName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
