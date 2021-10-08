namespace Domain.SeedWork
{
    //public interface IRepository<T> where T : IAggregateRoot
    //{
    //    IUnitOfWork UnitOfWork { get; }

    //}
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}