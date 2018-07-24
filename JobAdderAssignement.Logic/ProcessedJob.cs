using AutoMapper;
using JobAdderAssignement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobAdderAssignement.Logic
{
    public class ProcessedJob : Job
    {
        readonly int CANDIDATE_COUNT = 3;
        IMapper _iMapper;
        private List<ProcessedCandidate> _candidates;

        public List<ProcessedCandidate> SortedCandidates
        {
            get
            {
                return _candidates.OrderByDescending(c => c.NbSkillMatching)
                                    .ThenBy(c => c.SkillWeight)
                                    .ThenBy(c => c.FirstSkillMatchedIndex)
                                    .Take(CANDIDATE_COUNT).ToList();    
            }
        }

        public void Process(List<Candidate> candidates)
        {
            foreach (Candidate c in candidates)
            {
                ProcessedCandidate pc = _iMapper.Map<Candidate, ProcessedCandidate>(c);
                pc.Process(this.skills);
                _candidates.Add(pc);
            }
        }

        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Candidate, ProcessedCandidate>();
        });
    }
}
