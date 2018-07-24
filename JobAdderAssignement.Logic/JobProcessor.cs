using AutoMapper;
using JobAdderAssignement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobAdderAssignement.Logic
{
    public class JobProcessor
    {
        List<Job> _jobs;
        List<Candidate> _candidates;
        IMapper _iMapper;

        public JobProcessor(List<Job> jobs, List<Candidate> candidates)
        {
            _jobs = jobs;
            _candidates = candidates;
            _iMapper = config.CreateMapper();
        }

        public List<ProcessedJob> GetProcessedJobs()
        {
            List<ProcessedJob> ret = new List<ProcessedJob>();
            foreach (var job in _jobs)
            {
                ProcessedJob pj = _iMapper.Map<Job, ProcessedJob>(job);
                pj.Process(_candidates);
                ret.Add(pj);
            }
            return ret;
        }

        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Job, ProcessedJob>();
        });
    }
}
