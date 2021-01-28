using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class PersonalInfoTab
    {
        public int ID { get; set; }
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public virtual CandidateTab CandidateTab { get; set; }
    }
}
