using Desafio5.Domain.Entity;
using Desafio5.Domain.Interfaces.Repository;
using Desafio5.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Desafio5.Application.Services;

public class ClientService(IUnitOfWork iUniftOfWork): IClientService
{
    public async Task<List<Client>> GetAllAsync()
    {
        return await iUniftOfWork.ClientRepository.GetAllAsync();
    }
    
    public async Task<Client> GetById(Guid id)
    {
        var client = await iUniftOfWork.ClientRepository.GetAsync(true, c => c.Include(a => a.Address), clientF => clientF.ID == id);
        return client;
    }
    
    public async Task<Guid> PostClient(Client client)
    {
        var clientInsert = iUniftOfWork.ClientRepository.Insert(client);
        await iUniftOfWork.Commit();
        return clientInsert;
    }
    
    public async Task<bool> DeleteClient(Guid id)
    {
        var client = await iUniftOfWork.ClientRepository.GetAsync(true, c => c.Include(a => a.Address), clientF => clientF.ID == id);
        if (client is null) throw new ArgumentException("Client não encontrado");
        iUniftOfWork.ClientRepository.Delete(client);
        await iUniftOfWork.Commit();
        return true;
    }
    
    public async Task<Client> UpdateClient(Guid id, Client client)
    {
        var clientRep = await iUniftOfWork.ClientRepository.GetAsync(true, c => c.Include(a => a.Address), clientF => clientF.ID == id);
        if (clientRep is null) throw new ArgumentException("Client não encontrado");
        clientRep.Name = client.Name;
        clientRep.Email = client.Email;
        clientRep.Phone = client.Phone;
        clientRep.Address = client.Address;
        iUniftOfWork.ClientRepository.Update(clientRep);
        await iUniftOfWork.Commit();
        var clientUpdate = await GetById(id);
        return clientUpdate;
    }
}