using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class CandidateTab
    {
        public CandidateTab()
        {
            this.Careerinformations = new HashSet<Careerinformation>();
            this.EducationalInformations = new HashSet<EducationalInformation>();
            this.PersonalInfoTabs = new HashSet<PersonalInfoTab>();
            this.ReferanceInfoes = new HashSet<ReferanceInfo>();
            this.TraningInformations = new HashSet<TraningInformation>();
        }
        [Key]
        public int CandidateID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }


        public virtual ICollection<Careerinformation> Careerinformations { get; set; }

        public virtual ICollection<EducationalInformation> EducationalInformations { get; set; }

        public virtual ICollection<PersonalInfoTab> PersonalInfoTabs { get; set; }

        public virtual ICollection<ReferanceInfo> ReferanceInfoes { get; set; }

        public virtual ICollection<TraningInformation> TraningInformations { get; set; }
    }
}
