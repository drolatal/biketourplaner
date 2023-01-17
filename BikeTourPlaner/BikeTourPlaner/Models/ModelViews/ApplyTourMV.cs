using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class ApplyTourMV
    {
        private readonly List<SelectListItem> _plans;

        public List<SelectListItem> Plans
        {
            get { return _plans; }
        }

        public ApplyTourMV()
        {
            BikeTourData btd = new BikeTourData();
            List<TourPlan> plans = btd.TourPlans.ToList();
            _plans = new List<SelectListItem>();
            foreach (TourPlan plan in plans) {
                SelectListItem sli = new SelectListItem($"{plan.TourName}, Date: {plan.TourDate}, Cost{plan.Cost}",plan.Tid.ToString());
                _plans.Add(sli);
            }
        }

        [Required]
        public long ChoosenTour { get; set; }
    }
}
