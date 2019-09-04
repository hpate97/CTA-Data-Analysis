using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class TopTenInfoModel : PageModel  
    {  
				public List<Models.TopTen> TopTen { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  TopTen = new List<Models.TopTen>();
					
					// make input available to web page:
					
					
					// clear exception:
					EX = null;
					
					try
					{
							string sql;

							sql = string.Format(@"SELECT TOP 10 Name, Sum(DailyTotal) AS TotalRidership, 
                            ROW_NUMBER() OVER (ORDER BY Sum(DailyTotal) DESC) AS RowNum
                            From Riderships
                            Inner Join Stations on Stations.StationID = Riderships.StationID
                            Group by Stations.Name
                            Order by TotalRidership desc;");
                            
							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.TopTen tt = new Models.TopTen();

                                tt.RowNum = Convert.ToInt32(row["RowNum"]);
								tt.StationName = Convert.ToString(row["Name"]);
                                tt.TotalRiders = Convert.ToInt32(row["TotalRidership"]);
                                
                                TopTen.Add(tt);
							}
						
					}//try
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  // nothing at the moment
				  }
				}
			
    }//class  
}//namespace