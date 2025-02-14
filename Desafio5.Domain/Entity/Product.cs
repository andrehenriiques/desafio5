namespace Desafio5.Domain.Entity;

public class Product : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}