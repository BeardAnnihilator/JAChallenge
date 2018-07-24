using JobAdderAssignement.Logic;
using JobAdderAssignement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JobAdderAssignement.Service
{
    public class ProcessedJobService : IProcessedJobService
    {
        readonly string APIURL = "https://jobadder1.docs.apiary.io/";

        public ProcessedJobsResponse GetProcessedJobs()
        {
            ProcessedJobsResponse ret = new ProcessedJobsResponse();
            List<Job> jobs = null;
            List<Candidate> cands = null;
            using (WebClient wc = new WebClient())
            {
                var jobsjson = wc.DownloadString(APIURL + "jobs");
                var candjson = wc.DownloadString(APIURL + "candidates");
                jobs = JsonConvert.DeserializeObject<List<Job>>(jobsjson);
                cands = JsonConvert.DeserializeObject<List<Candidate>>(candjson);
            }
            JobProcessor jp = new JobProcessor(jobs, cands);
            ret.ProcessedJobs = jp.GetProcessedJobs();
            return ret;
        }
    }
}
