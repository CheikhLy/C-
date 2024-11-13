using Cours.Enum;
using Cours.Repository;
using Cours.Repository.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Cours.Core.Factory
{
    public static class FactoryRepo
    {
        public static IClientRepository? CreateClientRepository(Persistence type, ApplicationDbContext? context = null)
        {
            return type switch
            {
                Persistence.DATABASE => 
                    context != null ? new ClientRepositoryEfImpl(context) : throw new ArgumentNullException(nameof(context)),
                
                Persistence.LIST => new ClientRepositoryImpl(),
                
                Persistence.DAPPER => new ClientRepositoryDapperImpl(new DataBaseConnection()), // Pour Dapper, pas besoin d’ApplicationDbContext
                
                _ => null
            };
        }
    }
}
