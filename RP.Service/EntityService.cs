using RP.Data;
using RP.Repo;

namespace RP.Service
{
    public abstract class EntityService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<T> repository;

        public EntityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = this.unitOfWork.GetRepository<T>();
        }
    }
}