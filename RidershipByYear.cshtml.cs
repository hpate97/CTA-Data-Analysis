using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace program.Pages
{
    public class RidershipByYearModel : PageModel
    {
        public List<string> Years { get; set; }
        public List<int> NumRiders { get; set; }
        public Exception EX { get; set; }

        public void OnGet()
        {
            Years = new List<string>();
            NumRiders = new List<int>();

            EX = null;

            Years.Add("2001");
            Years.Add("2002");
            Years.Add("2003");
            Years.Add("2004");
            Years.Add("2005");
            Years.Add("2006");
            Years.Add("2007");
            Years.Add("2008");
            Years.Add("2009");
            Years.Add("2010");
            Years.Add("2011");
            Years.Add("2012");
            Years.Add("2013");
            Years.Add("2014");
            Years.Add("2015");
            Years.Add("2016");
            Years.Add("2017");
            Years.Add("2018");


            try
            {
                string sql = string.Format(@"
                SELECT Year(TheDate) AS TheYear, Sum(DailyTotal) AS NumRiders
                FROM Riderships
                GROUP BY Year(TheDate)
                ORDER BY Year(TheDate);");

                DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int numriders = Convert.ToInt32(row["NumRiders"]);

                    NumRiders.Add(numriders);
                }
            }
            catch (Exception ex)
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