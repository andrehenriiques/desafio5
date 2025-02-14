namespace Desafio5.Api.Dto;

public class ClientDto
{ 
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public AddressDto Address { get; set; }
}