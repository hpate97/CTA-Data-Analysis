//
// One CTA Station
//

namespace program.Models
{

  public class TopTen
	{

        // data members with auto-generated getters and setters:

        public int RowNum { get; set; }
        public string StationName { get; set; }
        public int TotalRiders { get; set; }
       

        // default constructor:
        public TopTen()
		{ }
		
		// constructor:
		public TopTen(int rownum, string name, int totalridership)
		{
            RowNum = rownum;
			StationName = name;
            TotalRiders = totalridership;

        }

    }//class

}//namespace