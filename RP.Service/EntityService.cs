using AutoMapper;
using RP.Data;
using RP.Repo;

namespace RP.Service
{
    public abstract class EntityService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<T> repository;
        protected readonly IMapper iMapper;

        public EntityService(IUnitOfWork unitOfWork, IMapper iMapper)
        {
            this.unitOfWork = unitOfWork;
            repository = this.unitOfWork.GetRepository<T>();
            this.iMapper = iMapper;
        }
    }
}