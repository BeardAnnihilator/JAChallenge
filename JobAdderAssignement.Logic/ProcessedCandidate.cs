using JobAdderAssignement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobAdderAssignement.Logic
{
    public class ProcessedCandidate : Candidate
    {
        public int NbSkillMatching { get; set; }
        public int SkillWeight { get; set; }
        public int FirstSkillMatchedIndex { get; set; }
        public int PercentSkills { get; set; }

        public void Process(string jobskills)
        {
            //todonext
        }
    }
}
