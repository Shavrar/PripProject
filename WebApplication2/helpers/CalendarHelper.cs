using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace WebApplication2.helpers
{
    public static class CalendarHelper
    {
        public static string NameOfMonth(int a)
        {
            switch (a)
            {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";
            }

            return "";
        }

        public static MvcHtmlString CreateCalendar(this HtmlHelper html, int month, int year, string day, int[] offdays)
        {

            int days = DateTime.DaysInMonth(year, month);

            string[] daysofweek = { "Monday","Tuesday", "Wednesday","Thursday", "Friday","Saturday", "Sunday" };

            int daysbefore = 0;
            int daysafter = 0;

            switch (day)
            {
                case "Monday":

                    daysbefore = 0;
                    break;

                case "Tuesday":

                    daysbefore = 1;
                    break;

                case "Wednesday":

                    daysbefore = 2;
                    break;


                case "Thursday":

                    daysbefore = 3;
                    break;


                case "Friday":

                    daysbefore = 4;
                    break;


                case "Saturday":

                    daysbefore = 5;
                    break;

                case "Sunday":

                    daysbefore = 6;
                    break;

                default:

                TagBuilder p = new TagBuilder("p");
                p.SetInnerText("Wrong day name");
                return new MvcHtmlString(p.ToString());
            }

            days += daysbefore;

            
             if (days <= 35 && days>28)
            {
                daysafter =35-days;
                days = 35;
            }
            else if (days <= 42)
            {
                daysafter = 42 - days;
                days = 42;
            }
            else
            {
                daysafter = 49 - days;
                days = 49;
            }

            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table table-bordered");

            TagBuilder tr = new TagBuilder("tr");

            for (int i = 0; i < 7; i++)
            {
                var td = new TagBuilder("td");
                td.SetInnerText(daysofweek[i]);
                tr.InnerHtml += td.ToString();
                td = null;
            }

            table.InnerHtml += tr;

            tr = null;

            for (int i = 0; i < days/7; i++)
            {
                tr = new TagBuilder("tr");

                for (int j = 1 + 7 * i,k = 1; j <= 7 + 7 * i; j++,k++)
                {
                    var td = new TagBuilder("td");
                    if (j > daysbefore && j <= days-daysafter)
                    {                        
                        td.SetInnerText((j-daysbefore).ToString());
                        if (k == 6 || k == 7)
                        {
                            td.AddCssClass("special");
                        }
                        if (offdays.Contains(j - daysbefore))
                        {
                            td.AddCssClass("special");
                        }
                        tr.InnerHtml += td.ToString();                       
                    }
                    else
                    {
                        
                        tr.InnerHtml += td.ToString();
                    }

                    td = null;
                }
                table.InnerHtml += tr;
                tr = null;
            }

            return new MvcHtmlString(table.ToString());

        }
    }
}
