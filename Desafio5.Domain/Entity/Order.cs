namespace Desafio5.Domain.Entity;

public class Order : Base
{
    public string TotalAmount { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; }
    public virtual ICollection<Product> Product { get; set; } = new List<Product>();
}