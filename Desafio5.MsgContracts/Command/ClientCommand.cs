
using Desafio5.Domain.Models;
using Desafio5.MsgContracts.Interface;
using MassTransit;

namespace Desafio5.MsgContracts.Command
{
    public class ClientCommand: MassTransit.IConsumer<ClientAddressModel>
    {
        public Task Consume(ConsumeContext<ClientAddressModel> context)
        {
            Console.WriteLine($"Client consume message{context.Message}");
            return Task.CompletedTask;
        }
    }
    
}