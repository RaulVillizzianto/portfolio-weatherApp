using dotnet_ServerApi.Classes;

namespace dotnet_ServerApi.Models
{
    public class Weather 
    {
        public int dt { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
        public int cod { get; set; }
        public coord coord { get; set; } = new coord();
        public List<weather> weather { get; set; } = new List<weather>();
        public int visibility { get; set; }
        public sys sys { get; set; } = new sys();
        public clouds clouds { get; set; } = new clouds();
        public wind wind { get; set; } = new wind();
        public main main { get; set; } = new main();

        public List<Models.list> forecastWeatherList { get; set; } = new List<list>();

    }
    public class sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string? country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }
    public class clouds
    {
        public int all { get; set; }
    }
    public class wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }
    public class main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
    public class coord
    {
        public long lon { get; set; }
        public long lat { get; set; }
    }
    public class weather
    {
        public int id { get; set; }
        public string? main { get; set; }
        private string? _description = string.Empty;
        public string description
        {
            get
            {
                return this._description;
            }
            set
            { 
                this._description = value.Capitalize();
            }
        }
        private string? _icon = string.Empty;
        public string? icon
        {
            get
            {
                return this._icon;
            }
            set
            {
                switch(main)
                {
                    case "Rain": //rain
                        {
                            this._icon = "fa-cloud-rain";

                            break;
                        }
                    case "Clouds": //cloud
                        {
                            this._icon = "fa-cloud";
                            break;
                        }
                    default:
                        {
                            this._icon = "fa-sun";
                            break;
                        }
                }
                
            }
        }
    }
}