using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        [Route("/Search/Results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            //initialize list of Dictionaries for job data
            List<Dictionary<string, string>> jobs;

            if (searchTerm != null)
            {
                //checks if the search was in all columns
                if (searchType == "all")
                {
                    jobs = JobData.FindByValue(searchTerm);
                }
                //checks if search has column and value
                else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
                //pass into view
                ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;
                ViewBag.jobs = jobs;
                //return a different view than would normally
                return View("Index");
            }

            else
            {
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
        }
    }
}
