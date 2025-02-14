using AutoMapper;
using Desafio5.Api.Dto;
using Desafio5.Domain.Entity;
using Desafio5.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio5.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientController(IClientService clientService, IMapper mapper) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetClients()
    { 
        var clients = await clientService.GetAllAsync(); 
        return Ok(clients);
    }
 
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var client = await clientService.GetById(id);
        return Ok(client);
    }
    
    [HttpPost]
    public IActionResult PostClient(ClientDto client)
    { 
        var mapClient = mapper.Map<ClientDto, Client>(client);
        return Ok(clientService.PostClient(mapClient));
    }
 
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateClient([FromBody]ClientDto client, Guid id)
    {
        var mapClient = mapper.Map<ClientDto, Client>(client);
        await clientService.UpdateClient(id, mapClient);
        return Ok();
    }
 
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClientById(Guid id)
    {
        await clientService.DeleteClient(id);
        return Ok();
    }
}