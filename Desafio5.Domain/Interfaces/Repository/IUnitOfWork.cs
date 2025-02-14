
using IPostgres = Desafio5.Domain.Interfaces.Postgres;
using Desafio5.Domain.Entity;using System.Threading.Tasks;

namespace Desafio5.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
		//methods
            IPostgres.IRepositoryBase<Product> ProductRepository { get; }
            IPostgres.IRepositoryBase<Order> OrderRepository { get; }
            IPostgres.IRepositoryBase<Client> ClientRepository { get; }
    }
}