using Desafio5.Domain.Entity;

namespace Desafio5.Domain.Interfaces.Services;

public interface IClientService
{
    public Task<List<Client>> GetAllAsync();
    public Task<Client> GetById(Guid id);
    public Guid PostClient(Client client);
    public Task<bool> DeleteClient(Guid client);
    public Task<Client> UpdateClient(Guid id, Client client);
}