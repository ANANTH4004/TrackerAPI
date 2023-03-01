using Twilio.Clients;
using Twilio.Http;
using HttpClient = System.Net.Http.HttpClient;

namespace PortfolioTracker.Service
{
    public class TwilioClient : ITwilioRestClient
    {
        private readonly ITwilioRestClient _client;
        public TwilioClient(IConfiguration config , HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            _client = new TwilioRestClient(
                config["Twilio:AccountSid"],
                config["Twilio:AccountSid"],
                httpClient : new SystemNetHttpClient(httpClient)
                
                );
        }
        public string AccountSid => _client.AccountSid;

        public string Region => _client.Region;

        public Twilio.Http.HttpClient HttpClient => _client.HttpClient;

        public Response Request(Request request) =>
            _client.Request(request);

        public Task<Response> RequestAsync(Request request) => _client.RequestAsync(request);
    }
}
