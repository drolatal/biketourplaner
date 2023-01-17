using BikeTourPlaner.Models;
using BikeTourPlaner.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BikeTourPlaner.Controllers
{
    public class TourManagerController : Controller
    {
        private static int _runs = 0;

        public IActionResult NewTour(NewTourMV nt)
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            if (ModelState.IsValid)
            {
                BikeTourData btd = new BikeTourData();
                TourPlan tp = new TourPlan();
                tp.TourName = nt.TourName;
                tp.TourDate = nt.TourDate;
                tp.Cost = nt.Cost;
                tp.PlannedDistance = nt.PlannedDistance;
                btd.Add(tp);
                btd.SaveChanges();
                HttpContext.Session.SetString("_DataManipResponse", "Making new tour");
                return RedirectToAction("AllGood","Response");
            }
            return View(nt);
        }

        public IActionResult ApplyTour(ApplyTourMV at)
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            if (_runs % 2 != 0)
            {
                if (ModelState.IsValid)
                {
                    BikeTourData btd = new();
                    TourApply ta = new();
                    ta.Tid = at.ChoosenTour;
                    ta.Uid = long.Parse(HttpContext.Session.GetString("_LoggedInUId"));
                    btd.TourApplies.Add(ta);
                    btd.SaveChanges();
                    HttpContext.Session.SetString("_DataManipResponse", "Applying to tour ");
                    return RedirectToAction("AllGood", "Response");
                }
            }
            _runs++;
            return View(at);
        }

        public IActionResult TourResult(TourResultMV tr)
        {
            ViewData["_LoggedInUId"] = HttpContext.Session.GetString("_LoggedInUId");
            ViewData["_LoggedInUNN"] = HttpContext.Session.GetString("_LoggedInUNN");
            TourAppliesOfUser taou = new TourAppliesOfUser(HttpContext);
            ViewData["_TAOU"] = taou;
            if (_runs % 2 != 0)
            {
                if (ModelState.IsValid)
                {
                    BikeTourData btd = new();
                    TourResult newtr = new TourResult();
                    newtr.Tid = tr.ChoosenTour;
                    newtr.Uid = long.Parse(HttpContext.Session.GetString("_LoggedInUId"));
                    newtr.Rain = tr.Rain;
                    newtr.Accident = tr.Accident;
                    newtr.Kcalories = tr.KCalories;
                    newtr.DailyTemp = tr.Temperature;
                    newtr.TravelTime = tr.TravelTime;
                    newtr.DistanceTraveled = tr.DistanceTravelled;
                    btd.Add(newtr);
                    btd.SaveChanges();
                    HttpContext.Session.SetString("_DataManipResponse", "Adding Results To Tour ");
                    return RedirectToAction("AllGood", "Response");
                }
            }
            _runs++;
            return View(tr);
        }
    }
}
