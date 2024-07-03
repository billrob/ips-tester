// See https://aka.ms/new-console-template for more information
using IpsTester;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var baseUrl = configuration["baseUrl"] ?? throw new InvalidOperationException("Could not find 'baseUrl' in appSettings.");
var bearerToken = configuration["bearerToken"] ?? throw new InvalidOperationException("Could not find 'bearerToken' in appSettings.");


var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(baseUrl);
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "kredit-IpsTester");

if (args.Length > 0 && String.Equals(args[0], "chunked", StringComparison.OrdinalIgnoreCase))
  Console.WriteLine(args[0]);

HttpRequestMessage requestMessage = null;

var baseAddress = new Uri(baseUrl);

var apiRequest = new ApiRequest();
for (int i = 0; i < 2000; i++)
{
  apiRequest.Ssns.Add(new ApiRequest.Ssn("555115555"));
}

if (args.Length > 0 && String.Equals(args[0], "chunked", StringComparison.OrdinalIgnoreCase))
{
  requestMessage = new HttpRequestMessage(HttpMethod.Get, "getAccountBatch")
  {
    RequestUri = new Uri(baseAddress, "getAccountBatch"),
    Content = JsonContent.Create(apiRequest),
  };
}
else
{
  var jsonBody = JsonSerializer.Serialize(apiRequest);
  requestMessage = new HttpRequestMessage(HttpMethod.Get, "getAccountBatch")
  {
    RequestUri = new Uri(baseAddress, "getAccountBatch"),
    Content = new StringContent(jsonBody, Encoding.UTF8, "application/json"),
  };
}


var httpResponse = await httpClient.SendAsync(requestMessage);

var response = await httpResponse.Content.ReadAsStringAsync();
Console.WriteLine(response);