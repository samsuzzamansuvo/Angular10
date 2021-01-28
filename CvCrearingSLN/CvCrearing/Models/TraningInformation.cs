using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class TraningInformation
    {
        public int ID { get; set; }
        public int CandidateID { get; set; }
        public string TraningTitle { get; set; }
        public string Topicscoverd { get; set; }
        public string Institute { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string TraningYear { get; set; }
        public string Duration { get; set; }

        public virtual CandidateTab CandidateTab { get; set; }
    }
}
