using System.Net.Http.Json;
using MonkeyFinder.Interfaces.Services;

namespace MonkeyFinder.Services;

public class MonkeyService : IMonkeyService
{
    HttpClient httpClient;

    IList<Monkey> monkeyList = new List<Monkey>();

    public MonkeyService()
    {
        httpClient = new();
    }

    public async Task<IList<Monkey>> GetMonkeys()
    {
        if( monkeyList?.Count > 0)
            return monkeyList;

        string url = "https://montemagno.com/monkeys.json";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;
    }
}
