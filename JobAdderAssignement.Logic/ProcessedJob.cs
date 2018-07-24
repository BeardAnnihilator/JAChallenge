using JobAdderAssignement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobAdderAssignement.Logic
{
    public class ProcessedJob : Job
    {
        private List<ProcessedCandidate> _candidates;

        public List<ProcessedCandidate> SortedCandidates
        {
            get
            {
                //todonext
                return null;
            }
        }

        public void Process(List<Candidate> candidates)
        {
            //todonext
        }
    }
}
