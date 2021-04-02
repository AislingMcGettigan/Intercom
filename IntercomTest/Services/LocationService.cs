using System;

namespace IntercomTest.Services
{
    public class LocationService
    {
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double dist = 0;
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return dist;
            }
            else
            {
                double theta = lon1 - lon2;
                dist = Math.Sin(lat1.ToRadians()) * Math.Sin(lat2.ToRadians()) + Math.Cos(lat1.ToRadians()) * Math.Cos(lat2.ToRadians()) * Math.Cos(theta.ToRadians());
                dist = Math.Acos(dist);
                dist = dist.ToDegrees();
                dist = dist * 60 * 1.1515;
                dist *= 1.609344;

                return dist;
            }
        }
    }
}
