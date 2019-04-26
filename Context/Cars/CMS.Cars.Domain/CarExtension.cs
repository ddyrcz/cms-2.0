using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Domain
{
    public static class CarExtension
    {
        public static bool IsExpirationApproaching(this Car car, int approachingExpirationDaysBefore)
        {
            return
                (car.TermTechnicalResearch?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (car.OcExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (car.AcExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (car.LiftUdtExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (car.TachoLegalizationExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore;
        }
    }
}
