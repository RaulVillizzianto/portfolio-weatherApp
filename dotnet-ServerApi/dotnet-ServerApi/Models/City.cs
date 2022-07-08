namespace dotnet_ServerApi.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }    
        public string State { get; set; }
        public string Country { get; set; }
        public coord  Coord { get; set; } = new coord();
    }
}
