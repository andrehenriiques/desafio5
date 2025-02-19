using Desafio5.Domain.Models;
using MassTransit;

namespace Desafio5.MsgContracts.Interface;

public interface IConsumer<in TMessage> :
    IConsumer
    where TMessage : class
{
    Task Consume(ConsumeContext<TMessage> context);
}
