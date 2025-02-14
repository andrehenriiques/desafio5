using System.Text.Json.Serialization;
namespace Desafio5.Domain.Entity;

public class Address
{
    public Guid ID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    [JsonIgnore] 
    public virtual Client Client { get; set; }
}