using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program {
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary  = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode forecastNode = JsonNode.Parse(response)!;
        // Console.WriteLine(countryNode);
        JsonNode sysNode = forecastNode!["sys"]!;
        JsonNode countryNode = sysNode!["country"]!;
        // Console.WriteLine(tempNode);
        JsonNode mainNode = forecastNode!["main"]!;
        JsonNode tempNode = mainNode!["temp"]!;
        // Console.WriteLine(weather1Node);
        JsonNode weatherNode = forecastNode!["weather"]!;
        JsonNode weatherInfo = weatherNode[0];
        JsonNode weatherMainNode = weatherInfo!["main"]!;
        
        Console.WriteLine("Weather: " + weatherMainNode);
        Console.WriteLine("Temperature: " + tempNode);
        Console.WriteLine("Region: " + countryNode);
    }
}