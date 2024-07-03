using System.Text.Json.Serialization;

namespace IpsTester;

internal class ApiRequest
{
  [JsonPropertyName("filterFirstName")]
  public List<FirstName> FirstNames { get; } = new();

  [JsonPropertyName("filterLastName")]
  public List<LastName> LastNames { get; } = new();

  [JsonPropertyName("filterSSN")]
  public List<Ssn> Ssns { get; } = new();

  [JsonPropertyName("filterCustomerZipCodes")]
  public List<ZipCode> ZipCodes { get; } = new();

  [JsonPropertyName("limit")]
  public int PageSize { get; } = 20;

  public class FirstName(string value)
  {
    [JsonPropertyName("firstName")]
    public string Value { get; } = value;
  }

  public class LastName(string value)
  {
    [JsonPropertyName("lastName")]
    public string Value { get; } = value;
  }

  public class Ssn(string value)
  {
    [JsonPropertyName("ssn")]
    public string Value { get; } = value;
  }

  public class ZipCode(string value)
  {
    [JsonPropertyName("zipCode")]
    public string Value { get; } = value;
  }
}