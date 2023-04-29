namespace BlazorApp1.Clients;

public class ImagesApiClient
{
    private readonly HttpClient _client;
    
    public ImagesApiClient(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient(nameof(ImagesApiClient));
    }
    
    public async Task<string> GetRandomImageUrl()
        => await _client.GetStringAsync("random");
}