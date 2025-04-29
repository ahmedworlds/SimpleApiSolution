using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            HttpResponseMessage response = await client.GetAsync("weather");
            if (response.IsSuccessStatusCode)
            {
                string weatherData = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Weather Data: " + weatherData);
            }
            else
            {
                Console.WriteLine("Error fetching weather data.");
            }
        }
    }
}