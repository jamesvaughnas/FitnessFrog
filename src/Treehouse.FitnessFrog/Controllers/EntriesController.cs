using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Treehouse.FitnessFrog.Data;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;

        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
        }

        public ActionResult Index()
        {
            List<Entry> entries = _entriesRepository.GetEntries();

            // Calculate the total activity.
            double totalActivity = entries
                .Where(e => e.Exclude == false)
                .Sum(e => e.Duration);

            // Determine the number of days that have entries.
            int numberOfActiveDays = entries
                .Select(e => e.Date)
                .Distinct()
                .Count();

            ViewBag.TotalActivity = totalActivity;
            ViewBag.AverageDailyActivity = (totalActivity / (double)numberOfActiveDays);

            return View(entries);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        // public ActionResult AddPost()
        public ActionResult Add( DateTime? date, int? activityId, 
           double? duration, Entry.IntensityLevel? intensity, 
           bool? exclude, string notes)
       {
            // use header or Request.Form
            //string date = Request.Form["Date"];
            //// ActivityId
            //// Duration
            //// Intensity
            //// Exclude

            // using the HtmlHelp method in the view means we do not need this code
            // now lets send data back to the page
            //ViewBag.Date = ModelState["Date"].Value.AttemptedValue;  // date;
            //ViewBag.ActivityId = ModelState["ActivityId"].Value.AttemptedValue;  //activityId;
            //ViewBag.Duration = ModelState["Duration"].Value.AttemptedValue;  //duration;
            //ViewBag.Intensity = ModelState["Intensity"].Value.AttemptedValue;  //intensity;
            //ViewBag.Exclude = ModelState["Exclude"].Value.AttemptedValue;  //exclude;
            //ViewBag.Notes = ModelState["Notes"].Value.AttemptedValue;  //notes;

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}