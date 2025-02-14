using Desafio5.Data.Postgres.Context;
using Desafio5.Domain.Entity;
using Desafio5.Domain.Interfaces.Repository;

namespace Desafio5.Data.Postgres.Repository;

public class ClientRepository(PostgresDbContext context) : RepositoryBase<Client>(context), IClientRepository;