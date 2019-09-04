//
// One CTA Station
//

namespace program.Models
{

  public class Stops
	{
	
		// data members with auto-generated getters and setters:
	    public int StationID { get; set; }
        public int stopID { get; set; }
        public string stopName { get; set; }
        public char Direction { get; set; }
        public int ADA { get; set; }
        public string adaYN { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Color { get; set; }

        // default constructor:
        public Stops()
		{ }
		
		// constructor:
		public Stops(int id, int sid, string name, char direction, int ada, string yesNo, double latitude, double longitude, string color)
		{
			StationID = id;
            stopID = sid;
            stopName = name;
            Direction = direction;
            ADA = ada;
            adaYN = yesNo;
            Latitude = latitude;
            Longitude = longitude;
            Color = color;

           
          
        }

    }//class

}//namespace