using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class EducationalInformation
    {
        public int ID { get; set; }
        public int CandidateID { get; set; }
        public string LavelOfEducation { get; set; }
        public string ExamName { get; set; }
        public string MajorSub { get; set; }
        public string InstuteName { get; set; }
        public string Result { get; set; }
        public string YearOfPassing { get; set; }
        public Nullable<int> Duration { get; set; }

        public virtual CandidateTab CandidateTab { get; set; }
    }
}
