using System.Globalization;

namespace BlazorApp1.Clients;

public class PhrasesApiClient: HttpClient
{
    private readonly HttpClient _client;
    
    public PhrasesApiClient(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient(nameof(PhrasesApiClient));
    }
    
    public async Task<string> GetPhraseByDate(DateTime date)
        => await _client.GetStringAsync($"day/{date.ToString(
            "o", 
            CultureInfo.InvariantCulture)}");
    
}