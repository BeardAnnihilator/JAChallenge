using JobAdderAssignement.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JobAdderAssignement.Service
{

    [ServiceContract]
    public interface IProcessedJobService
    {

        [OperationContract]
        ProcessedJobsResponse GetProcessedJobs();
    }

    [DataContract]
    public class ProcessedJobsResponse
    {
        [DataMember]
        public List<ProcessedJob> ProcessedJobs { get; set; }
    }

}
