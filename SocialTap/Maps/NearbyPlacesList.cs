using SocialTap.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTap.Maps
{
   public  class NearbyPlacesList
    {
    public async Task<List<NearbyPlace>> GetNearbyPlacesListAsync(String type)
        {
            GooglePlacesApiData nearbyPlacesData = new GooglePlacesApiData();
            GooglePlacesApiResponse placesData =await nearbyPlacesData.GetApiResponseData(type);
            List<NearbyPlace> placesList = new List<NearbyPlace>();
            for (int i = 0; i < 5; i++)
            {
                placesList.Insert(i, new NearbyPlace(placesData.results[i].name, placesData.results[i].vicinity, CoordinatesConverter.GetConvertedCoordinates(placesData.results[i].geometry.location.lat, placesData.results[i].geometry.location.lng)));
            }
            return placesList;
        }

    }
}
