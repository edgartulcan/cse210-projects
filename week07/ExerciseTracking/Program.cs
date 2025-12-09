using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 4.8));   // 4.8 km
        activities.Add(new Cycling("03 Nov 2022", 45, 20));    // 20 kph
        activities.Add(new Swimming("03 Nov 2022", 25, 40));   // 40 laps

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
