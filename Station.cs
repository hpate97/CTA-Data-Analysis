//
// One CTA Station
//

namespace program.Models
{

  public class Station
	{
	
		// data members with auto-generated getters and setters:
        public int StationID { get; set; }
		public string StationName { get; set; }
		public int AvgDailyRidership { get; set; }
        public int NumStops { get; set; }
        public int HandicapCount { get; set; }
        public string HandyAccess { get; set; }

        // default constructor:
        public Station()
		{ }
		
		// constructor:
		public Station(int id, string name, int avgDailyRidership, int numstops, int handycount , string handyaccess)
		{
			StationID = id;
			StationName = name;
			AvgDailyRidership = avgDailyRidership;
            NumStops = numstops;
            HandicapCount = handycount;
            HandyAccess = handyaccess;
		}
		
	}//class

}//namespace