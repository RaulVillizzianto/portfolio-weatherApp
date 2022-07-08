using Newtonsoft.Json;
using System.Reflection;

namespace dotnet_ServerApi.Classes
{
    public class Geo
    {
        private static List<Models.City> _cityList = new List<Models.City>();
        public static List<Models.City> GetCitiesInformation(string cityName)
        {
            if(_cityList.Count == 0)
            {
                LoadCitiesInformation();
            }
            var cities =  _cityList.FindAll(x => x.Name.Contains(cityName));
            cities.AddRange(_cityList.FindAll(x => x.Name.Contains(cityName.Capitalize())));
            cities.AddRange(_cityList.FindAll(x => x.Name.Contains(cityName.ToUpper())));
            cities.AddRange(_cityList.FindAll(x => x.Name.Contains(cityName.ToLower())));
            return cities.DistinctBy(x => x.Name).ToList();
        }

        public static void LoadCitiesInformation()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string? directoryName = Path.GetDirectoryName(assemblyName);

            if (assemblyName == null)
            {
                return;
            }
            if(directoryName == null)
            {
                return;
            }
            string path = Path.Combine(directoryName, @"city.list.json");
            _cityList.AddRange(JsonConvert.DeserializeObject<List<Models.City>>(File.ReadAllText(path)));
        }
    }
}
