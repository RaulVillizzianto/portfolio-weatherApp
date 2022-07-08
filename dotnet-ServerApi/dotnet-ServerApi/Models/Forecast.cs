namespace dotnet_ServerApi.Models
{
    public class Forecast
    {
        public List<list> list { get; set; } = new List<list>();
    }
    public class list
    {
        public long dt { get; set; }
        public main main { get; set; } = new main();
        public List<weather> weather { get; set; } = new List<weather>();
        public clouds clouds { get; set; } = new clouds();
        public wind wind { get; set; } = new wind();
        private string _dt_txt = string.Empty;

        public string? dt_txt
        {
            get
            {
                return this._dt_txt;
            }
            set
            {
                this._dt_txt = value;
                time = DateTime.Parse(value);
                dayofweek = time.Value.DayOfWeek.ToString();
            }
        }
        public DateTime? time { get; set; }
        public string? dayofweek { get; set; }
    }
}
