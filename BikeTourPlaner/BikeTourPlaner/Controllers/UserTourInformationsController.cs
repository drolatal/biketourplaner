using BikeTourPlaner.Models;
using BikeTourPlaner.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BikeTourPlaner.Controllers
{
    public class UserTourInformationsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            return View();
        }

        public IActionResult UserInfos()
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");

            UserTourData utd = new UserTourData(long.Parse(HttpContext.Session.GetString("_LoggedInUId")));

            return View(utd);
        }

        public IActionResult OneToursInfo(OneTourInfosMV oti)
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            UserTourData utd = new UserTourData(long.Parse(HttpContext.Session.GetString("_LoggedInUId")));
            ViewData["_UserTourData"] = utd;
            if (ModelState.IsValid) {
                if (oti.TId != 0) {
                    ViewData["_TourId"] = oti.TId;
                }
            }

            return View(oti);
        }

        public IActionResult FilterByTemprain(FilterByTempRainMV fbtr) 
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            if (ModelState.IsValid)
            {
                long uid = long.Parse(HttpContext.Session.GetString("_LoggedInUId"));
                UserTourData utd = new UserTourData(uid);
                List<TourPlan> tourPlans = new();
                List<TourResult> tourResults = new();

                if (fbtr.FilterType == FilterOption.TEMPERATURE)
                {
                    if (fbtr.RelationalSign == RelationalSignE.LESSER)
                    {
                        for (int i = 0; i < utd.TourResults.Count(); i++) {
                            if (utd.TourResults[i].DailyTemp < fbtr.Quantity) {
                                if (utd.TourResults[i].Tid == utd.TourPlans[i].Tid) {
                                    tourPlans.Add(utd.TourPlans[i]);
                                    tourResults.Add(utd.TourResults[i]);
                                }
                            }
                        }
                    }
                    else {
                        for (int i = 0; i < utd.TourResults.Count(); i++)
                        {
                            if (utd.TourResults[i].DailyTemp > fbtr.Quantity)
                            {
                                if (utd.TourResults[i].Tid == utd.TourPlans[i].Tid)
                                {
                                    tourPlans.Add(utd.TourPlans[i]);
                                    tourResults.Add(utd.TourResults[i]);
                                }
                            }
                        }
                    }

                }
                else {
                    if (fbtr.RelationalSign == RelationalSignE.LESSER)
                    {
                        for (int i = 0; i < utd.TourResults.Count(); i++)
                        {
                            if (utd.TourResults[i].Rain < fbtr.Quantity)
                            {
                                if (utd.TourResults[i].Tid == utd.TourPlans[i].Tid)
                                {
                                    tourPlans.Add(utd.TourPlans[i]);
                                    tourResults.Add(utd.TourResults[i]);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < utd.TourResults.Count(); i++)
                        {
                            if (utd.TourResults[i].Rain > fbtr.Quantity)
                            {
                                if (utd.TourResults[i].Tid == utd.TourPlans[i].Tid)
                                {
                                    tourPlans.Add(utd.TourPlans[i]);
                                    tourResults.Add(utd.TourResults[i]);
                                }
                            }
                        }
                    }
                }
                ViewData["TourPlans"] = tourPlans;
                ViewData["TourResults"] = tourResults;
            }
            return View(fbtr);
        }

        public IActionResult AvarageSpeeds(AvarageSpeedsMV avs)
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            UserTourData utd = new UserTourData(long.Parse(HttpContext.Session.GetString("_LoggedInUId")));
            ViewData["_UserTourData"] = utd;
            if (ModelState.IsValid)
            {
                foreach (TourResult tr in utd.TourResults)
                {
                    if (tr.Tid == avs.ChoosenTour)
                    {
                        double time = tr.TravelTime.Value.TotalHours;
                        ViewData["_AvgSpeed"] = tr.DistanceTraveled / time;
                    }
                }
            }
            return View(avs);
        }

        public IActionResult CaloriesInInterval(CaloriesInIntervalMV cii) {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            UserTourData utd = new UserTourData(long.Parse(HttpContext.Session.GetString("_LoggedInUId")));
            if (ModelState.IsValid) {
                int cals = 0;
                for(int i = 0; i < utd.TourResults.Count; i++)
                {
                    if (utd.TourPlans[i].TourDate > cii.IntervalLeft && utd.TourPlans[i].TourDate < cii.IntervalRight) {
                        cals += (int)utd.TourResults[i].Kcalories;
                    }
                }
                ViewData["_UsedCalories"] = cals;
            }
            return View(cii);
        }

        public IActionResult CircleChart(CircleChartMV cc) {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            UserTourData utd = new UserTourData(long.Parse(HttpContext.Session.GetString("_LoggedInUId")));
            ViewData["_UserTourData"] = utd;
            if (ModelState.IsValid)
            {
                long tourId = cc.ChoosenTour;
                BikeTourData btd = new BikeTourData();
                List<long> allies = btd.TourApplies.Where(e => e.Tid == tourId).Select(e => e.Uid).ToList();
                List<TourResult> results = btd.TourResults.Where(e => e.Tid == tourId && allies.Contains((long)e.Uid)).ToList();
                string people = "";
                for(int i = 0; i < allies.Count(); i++)
                {
                    people += $"['{btd.Udata.Where(e=>e.Uid == allies[i]).First().Name}',{results[i].DistanceTraveled}],";
                }
                ViewData["_people"] = people;
            }
            return View(cc);
        }
    }
}
