using JobAdderAssignement.Logic;
using JobAdderAssignement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobAdderAssignement.Web.Controllers
{
    public class HomeController : Controller
    {
        static List<ProcessedJob> ProcessedJobs { get; set; }
        IProcessedJobService _processedJobService;

        public HomeController(IProcessedJobService processedJobService)
        {
            _processedJobService = processedJobService;
        }

        public ActionResult Index()
        {
            if (ProcessedJobs == null)
            {
                InitialDataLoad();
            }

            return View(ProcessedJobs);
        }

        private void InitialDataLoad()
        {
            ProcessedJobs = _processedJobService.GetProcessedJobs().ProcessedJobs;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}