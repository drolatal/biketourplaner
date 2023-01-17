using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeTourPlaner.Models.ModelViews
{
    public class TourAppliesOfUser
    {
        private readonly List<SelectListItem> _applies;

        public List<SelectListItem> Applies
        {
            get { return _applies; }
        }

        public TourAppliesOfUser(HttpContext httpContext)
        {
            long UId;
            _applies = new List<SelectListItem>();
            if (long.TryParse(httpContext.Session.GetString("_LoggedInUId"), out UId))
            {
                BikeTourData btd = new BikeTourData();
                List<TourApply> applies = btd.TourApplies.ToList();
                List<TourPlan> plans = btd.TourPlans.ToList();
                foreach (TourPlan plan in plans)
                {
                    foreach (TourApply apply in applies)
                    {
                        if (apply.Uid == UId && plan.Tid == apply.Tid)
                        {
                            SelectListItem sli = new SelectListItem($"{plan.TourName}, Date: {plan.TourDate}, Cost{plan.Cost}", plan.Tid.ToString());
                            _applies.Add(sli);
                        }
                    }
                }
            }
        }
    }
}
