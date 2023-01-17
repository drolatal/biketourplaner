namespace BikeTourPlaner.Models.ModelViews
{
    public class UserTourData
    {
        public Udatum UData { get; private set; }

        public List<TourResult> TourResults { get; private set; }
        public List<TourApply> TourApplies { get; private set; }
        public List<TourPlan> TourPlans { get; private set; }

        public UserTourData(long id)
        {
            BikeTourData btd = new BikeTourData();

            UData = btd.Udata.Where(e=>e.Uid== id).First();
            TourApplies = btd.TourApplies.Where(e => e.Uid == id).ToList();
            TourResults = new List<TourResult>();
            TourPlans = new List<TourPlan>();
            foreach (TourApply apply in TourApplies) {
                TourResults.Add(btd.TourResults.Where(e => e.Tid == apply.Tid).First());
                TourPlans.Add(btd.TourPlans.Where(e => e.Tid == apply.Tid).First());
            }
        }
    }
}
