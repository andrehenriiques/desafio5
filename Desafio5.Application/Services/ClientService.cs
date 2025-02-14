using Desafio5.Domain.Entity;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Domain.Interfaces.Services;

namespace Desafio5.Application.Services;

public class ClientService(IClientRepository clientRepository): IClientService
{
    public async Task<List<Client>> GetAllAsync()
    {
        return await clientRepository.GetAllAsync();
    }
    
    public async Task<Client> GetById(Guid id)
    {
        var client = await clientRepository.GetAsync(true, null, client => client.ID == id);
        return client;
    }
    
    public Guid PostClient(Client client)
    {
        var clientInsert = clientRepository.Insert(client);
        clientRepository.Commit();
        return clientInsert;
    }
    
    public async Task<bool> DeleteClient(Guid id)
    {
        var client = await clientRepository.GetAsync(true, null, client => client.ID == id);
        if (client is null) throw new ArgumentException("Client não encontrado");
        clientRepository.Delete(client);
        clientRepository.Commit();
        return true;
    }
    
    public async Task<Client> UpdateClient(Guid id, Client client)
    {
        var clientRep = await clientRepository.GetAsync(true, null, clientF => clientF.ID == id);
        if (clientRep is null) throw new ArgumentException("Client não encontrado");
        clientRep.Name = client.Name;
        clientRep.Email = client.Email;
        clientRep.Phone = client.Phone;
        clientRep.Address = client.Address;
        clientRepository.Update(clientRep);
        clientRepository.Commit();
        var clientUpdate = await GetById(id);
        return clientUpdate;
    }
}