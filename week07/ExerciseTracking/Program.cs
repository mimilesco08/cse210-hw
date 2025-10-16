using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // making a list of activities
        List<Activity> activities = new List<Activity>();

        // adding one of each type
        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling bike = new Cycling("04 Nov 2022", 45, 15.0);
        Swimming swim = new Swimming("05 Nov 2022", 25, 20);

        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        // show the summary for each
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
