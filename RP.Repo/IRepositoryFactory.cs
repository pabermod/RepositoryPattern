using RP.Data;

namespace RP.Repo
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}