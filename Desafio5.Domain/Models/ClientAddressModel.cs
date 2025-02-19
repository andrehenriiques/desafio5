namespace Desafio5.Domain.Models
{
    public  class ClientAddressModel:ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
    }
    
    public class AddressModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}