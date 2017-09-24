﻿using Newtonsoft.Json;
using SocialTap.Location;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SocialTap
{
    public class GooglePlacesApiData
    {

        public async Task<GooglePlacesApiResponse> GetApiResponseData()
        {
            CurrentCoordinate currentCoordinate = new CurrentCoordinate();
            currentCoordinate.CalculateCurrentCoordinates();
            String currentCoordinates = CoordinatesConverter.GetConvertedCoordinates(currentCoordinate.latitude, currentCoordinate.longitude);
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get,"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                +currentCoordinates+ "&rankby=distance&key=AIzaSyAoqL_K1g-5kTuinL-60Tmcf9udFtc9SLg");
            HttpResponseMessage responseMessage =await client.SendAsync(requestMessage);
            GooglePlacesApiResponse responseData = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(await responseMessage.Content.ReadAsStringAsync());
            return responseData;
        }
        public async Task<GooglePlacesApiResponse> GetApiResponseData(String type)
        {
            CurrentCoordinate currentCoordinate = new CurrentCoordinate();
            currentCoordinate.CalculateCurrentCoordinates();
            String currentCoordinates = CoordinatesConverter.GetConvertedCoordinates(currentCoordinate.latitude, currentCoordinate.longitude);
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + currentCoordinates + "&rankby=distance&type="+type+"&key=AIzaSyAoqL_K1g-5kTuinL-60Tmcf9udFtc9SLg");
            HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
            GooglePlacesApiResponse responseData = JsonConvert.DeserializeObject<GooglePlacesApiResponse>(await responseMessage.Content.ReadAsStringAsync());
            return responseData;
        }
    }
}
