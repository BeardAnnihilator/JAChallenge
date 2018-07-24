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
            int totalnbskills = 0;
            string[] jobskillsArray = jobskills.Split(',');
            for (int i = 0; i < jobskillsArray.Length; i++)
            {
                totalnbskills++;
                if (this.skillTags.Contains(jobskillsArray[i].Trim()))
                {
                    NbSkillMatching++;
                    SkillWeight += i;
                    if (FirstSkillMatchedIndex == 0)
                        FirstSkillMatchedIndex = i + 1;
                }
            }
            PercentSkills = (int)(((double)NbSkillMatching / totalnbskills) * 100);
        }
    }
}
