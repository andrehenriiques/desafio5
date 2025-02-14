
using PostgresRepo = Desafio5.Data.Postgres.Repository;
using Desafio5.Domain.Entity;
using IPostgres = Desafio5.Domain.Interfaces.Postgres;
using Desafio5.Data.Postgres.Context;using System.Threading.Tasks;
using Desafio5.Domain.Interfaces.Repository;

namespace Desafio5.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

		//contexts
        private readonly PostgresDbContext _postgresContext;
        //repositorys
         private IPostgres.IRepositoryBase<Product>? _ProductRepository;
         private IPostgres.IRepositoryBase<Order>? _OrderRepository;
         private IPostgres.IRepositoryBase<Client>? _ClientRepository;
        
        public UnitOfWork(
            PostgresDbContext postgresContext)
                    {
			            //constructor
            _postgresContext = postgresContext;
            //repositoryInject
                        
        }

      //injections
        public IPostgres.IRepositoryBase<Product> ProductRepository => _ProductRepository ?? (_ProductRepository = new PostgresRepo.RepositoryBase<Product>(_postgresContext));
        public IPostgres.IRepositoryBase<Order> OrderRepository => _OrderRepository ?? (_OrderRepository = new PostgresRepo.RepositoryBase<Order>(_postgresContext));
        public IPostgres.IRepositoryBase<Client> ClientRepository => _ClientRepository ?? (_ClientRepository = new PostgresRepo.RepositoryBase<Client>(_postgresContext));


        public async Task<bool> Commit()
        {
            return await _postgresContext.SaveChangesAsync() >= 0;
        }
    }
}