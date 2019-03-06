using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Domain
{
    public static class CarExtension
    {
        public static bool IsExpirationApproaching(this Car car, int approachingExpirationDaysBefore)
        {
            return false;
        }
    }
}
