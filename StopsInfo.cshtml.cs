using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class StopsInfoModel : PageModel  
    {  
				public List<Models.Stops> StopsList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  StopsList = new List<Models.Stops>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						if (input == null)
						{
							
						}
						else  
						{
							string sql = string.Format(@"
                            SELECT Stops.StopID AS StopID, Name, Direction, ADA, Latitude, Longitude, Color
                            From Stops
                            JOIN StopDetails ON Stops.StopID = StopDetails.StopID
                            JOIN Lines ON StopDetails.LineID = Lines.LineID
                            WHERE StationID = '{0}'
                            ORDER BY Color, Name", input);
                            

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Stops si = new Models.Stops();

								si.stopID = Convert.ToInt32(row["StopID"]);
                                si.stopName = Convert.ToString(row["Name"]);
                                si.Direction = Convert.ToChar(row["Direction"]);
                                si.ADA = Convert.ToInt32(row["ADA"]);
                                
                                if (si.ADA == 1)
                                {
                                    si.adaYN = Convert.ToString(row["ADA"]);
                                    si.adaYN = "Yes";
                                }
                                else
                                {
                                    si.adaYN = Convert.ToString(row["ADA"]);
                                    si.adaYN = "No";
                                }
                                si.Latitude = Convert.ToDouble(row["Latitude"]);
                                si.Longitude = Convert.ToDouble(row["Longitude"]);
                                si.Color = Convert.ToString(row["Color"]);


                      
                        StopsList.Add(si);
							}
						}//else
					}
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