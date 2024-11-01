namespace WebForescasts.Model
{
    public class WeatherForecatHolder
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private List<WeatherForecast> weatherForecasts;

        public WeatherForecatHolder()
        {
            weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
        public IEnumerable<WeatherForecast> GetAll()
        {
            return weatherForecasts;
        }

        public IEnumerable<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return weatherForecasts.Where(x => x.Date > dateFrom && x.Date < dateTo);
        }

        public void Add(WeatherForecast forecast)
        {
            forecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
            weatherForecasts.Add(forecast);
        }
        public bool Update(DateTime date, int temperature)
        {
            WeatherForecast forecast = weatherForecasts.FirstOrDefault(x => x.Date == date);
            if(forecast is not null)
            {
                forecast.TemperatureC = temperature;
                return true;
            }
            return false;
        }

        public bool Delete(DateTime date)
        {
            WeatherForecast forecast = weatherForecasts.FirstOrDefault(x => x.Date == date);
            if (forecast is not null)
            {
                weatherForecasts.Remove(forecast);
                return true;
            }
            return false;
        }
    }
}
