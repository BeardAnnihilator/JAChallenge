using System;
using System.Collections.Generic;
using System.Linq;
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
            return null;
            //todo next
        }
    }
}
