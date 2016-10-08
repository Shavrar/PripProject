using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{

    public class HomeController : Controller
    {
        float factorial(int n)
        {
            float i, x = 1;
            for (i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }

        Dictionary<int, DayOfWeek> getMonth()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            Dictionary<int, DayOfWeek> month = new Dictionary<int, DayOfWeek>();

            month.Add(DateTime.Now.Day, DateTime.Now.DayOfWeek);

            for (int i = DateTime.Now.Day - 1; i > 0; i--)
            {
                switch (month[i + 1])
                {

                    case DayOfWeek.Monday:

                        month.Add(i, DayOfWeek.Sunday);
                        break;

                    case DayOfWeek.Tuesday:

                        month.Add(i, DayOfWeek.Monday);
                        break;

                    case DayOfWeek.Wednesday:

                        month.Add(i, DayOfWeek.Tuesday);
                        break;


                    case DayOfWeek.Thursday:

                        month.Add(i, DayOfWeek.Wednesday);
                        break;


                    case DayOfWeek.Friday:

                        month.Add(i, DayOfWeek.Thursday);
                        break;


                    case DayOfWeek.Saturday:

                        month.Add(i, DayOfWeek.Friday);
                        break;

                    case DayOfWeek.Sunday:

                        month.Add(i, DayOfWeek.Saturday);
                        break;

                }

            }

            for (int i = DateTime.Now.Day + 1; i <= days; i++)
            {
                switch (month[i - 1])
                {

                    case DayOfWeek.Monday:

                        month.Add(i, DayOfWeek.Tuesday);
                        break;

                    case DayOfWeek.Tuesday:

                        month.Add(i, DayOfWeek.Wednesday);
                        break;

                    case DayOfWeek.Wednesday:

                        month.Add(i, DayOfWeek.Thursday);
                        break;


                    case DayOfWeek.Thursday:

                        month.Add(i, DayOfWeek.Friday);
                        break;


                    case DayOfWeek.Friday:

                        month.Add(i, DayOfWeek.Saturday);
                        break;


                    case DayOfWeek.Saturday:

                        month.Add(i, DayOfWeek.Sunday);
                        break;

                    case DayOfWeek.Sunday:

                        month.Add(i, DayOfWeek.Monday);
                        break;

                }

            }

            return month;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Calendar()
        {
            int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            Dictionary<int, DayOfWeek> month = getMonth();

            Dictionary<int, String> newmonth = new Dictionary<int, String>();

            int now = 0;

            switch(month[1]){
                case DayOfWeek.Monday:

                    now = 0;
                    break;

                case DayOfWeek.Tuesday:

                    now = 1;
                    break;

                case DayOfWeek.Wednesday:

                    now = 2;
                    break;


                case DayOfWeek.Thursday:

                    now = 3;
                    break;


                case DayOfWeek.Friday:

                    now = 4;
                    break;


                case DayOfWeek.Saturday:

                    now = 5;
                    break;

                case DayOfWeek.Sunday:

                    now = 6;
                    break;
            }

            ViewBag.now = now;

            for (int i = 1; i <= now; i++)
            {
                newmonth.Add(i , null);
            }

            for (int i = 1; i <= days; i++)
            {
                newmonth.Add(i + now, month[i].ToString());
            }

            

            if(days + now == 28)
            {

               now = days + now;
               days = 28;

                    
            }
            else if(days + now <= 35)
            {
                now = days + now;
                days = 35;
            }
            else if(days + now <= 42)
            {
                now = days + now;
                days = 42;
            }
            else
            {
                now = days + now;
                days = 49;
            }

            if (days != now)
            {
                for (int i = now + 1; i <= days; i++)
                {
                    newmonth.Add(i, null);
                }
            }


            ViewBag.days = days;

            ViewBag.month = newmonth;

            return View();
        }

        public ActionResult Contact(int id = 5)
        {
            ViewBag.Message = "Pascal Triangle";

            int[][] a = new int[id][];

            for(int i = 0; i < id; i++)
            {
                a[i] = new int[i + 1];

                for (int c = 0; c <= i; c++)
                {
                    
                    a[i][c]=(int)(factorial(i) / (factorial(c) * factorial(i - c))); 
                }
                
            }
            ViewBag.storage = a;

            return View();
        }
    }
}