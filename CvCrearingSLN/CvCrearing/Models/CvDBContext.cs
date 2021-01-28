using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvCrearing.Models
{
    public class CvDBContext:DbContext
    {
        public CvDBContext(DbContextOptions<CvDBContext> options) : base(options)
        { }
        public DbSet<CandidateTab> Candidates { get; set; }
        public DbSet<Careerinformation> Careerinformations { get; set; }
        public DbSet<EducationalInformation> EducationalInformation { get; set; }
        public DbSet<PersonalInfoTab> PersonalInfoTabs { get; set; }
        public DbSet<ReferanceInfo> ReferanceInfos { get; set; }
        public DbSet<TraningInformation> TraningInformation { get; set; }

    }
}
