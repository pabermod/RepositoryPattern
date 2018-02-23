using AutoMapper;
using RP.Data;
using RP.Repo;

namespace RP.Service
{
    public abstract class EntityService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> repository;
        protected readonly IMapper iMapper;

        public EntityService(IRepositoryFactory repositoryFactory, IMapper iMapper)
        {
            repository = repositoryFactory.GetRepository<T>();
            this.iMapper = iMapper;
        }
    }
}