using System.Linq;
using Android.Gms.Location;
using Android.Util;

namespace wifilocation
{
    public class FusedLocationProviderCallback : LocationCallback
    {
        readonly MainActivity activity;

        public FusedLocationProviderCallback(MainActivity activity)
        {
            this.activity = activity;
        }

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("FusedLocationProviderSample", "IsLocationAvailable: {0}", locationAvailability.IsLocationAvailable);
        }

        public override void OnLocationResult(LocationResult result)
        {
            if (result.Locations.Any())
            {
                var location = result.Locations.First();
                var loc = $"{location.Longitude}, {location.Latitude}, {location.Accuracy}";
                activity.DisplayText(loc);
            }
            else
            {
                // No locations to work with.
            }
        }
    }
}