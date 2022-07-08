using Newtonsoft.Json;
using System.Net;

namespace dotnet_ServerApi.Classes
{
    public class Weather
    {
        private const string _currentWeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?id={0}&appid=7b0e188042a78e695f1e712ba98bedf0&units={1}";
        private const string _forecastWeatherApiUrl = "https://api.openweathermap.org/data/2.5/forecast?id={0}&appid=7b0e188042a78e695f1e712ba98bedf0&units={1}";

        public static Models.Weather Get(int cityId, string unit)
        {
            if(unit == string.Empty || (unit != "imperial" && unit != "metric"))
            {
                throw new Exception("Invalid metric system");
            }
            string _currentWeatherUri = String.Format(_currentWeatherApiUrl, cityId, unit);
            string _forecastWeatherUri = String.Format(_forecastWeatherApiUrl, cityId, unit);
            var currentWeather = JsonConvert.DeserializeObject<Models.Weather>(CallExternalApi(_currentWeatherUri));
            var forecastWeather = JsonConvert.DeserializeObject<Models.Forecast>(CallExternalApi(_forecastWeatherUri));

            currentWeather.forecastWeatherList = forecastWeather.list.DistinctBy(x => x.time.Value.Date).ToList();
            return currentWeather;
        }

        private static string CallExternalApi(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
