using AutoMapper;
using RP.Data;
using RP.Repo;

namespace RP.Service
{
    public abstract class EntityService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> repository;
        protected readonly IMapper mapper;

        public EntityService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            repository = repositoryFactory.GetRepository<T>();
            this.mapper = mapper;
        }
    }
}