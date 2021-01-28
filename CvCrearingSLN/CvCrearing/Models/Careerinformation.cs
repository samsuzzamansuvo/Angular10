using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class Careerinformation
    {
        public int ID { get; set; }
        public int CandidateID { get; set; }
        public string CompamnyName { get; set; }
        public string CompanyBusiness { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual CandidateTab CandidateTab { get; set; }
    }
}
