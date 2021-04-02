using System;

namespace IntercomTest
{
    public static class ExtentionMethods
    {
        public static double ToRadians(this double degree)
        {
            return degree * Math.PI / 180.0;
        }

        public static double ToDegrees(this double radian)
        {
            return radian / Math.PI * 180.0;
        }

    }
}
