using System.Text.Json.Serialization;

namespace Desafio5.Domain.Entity;

public class Client : Base
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid AddressId { get; set; } 
    public virtual Address Address { get; set; }
    public virtual ICollection<Order> Order { get; set; }
}