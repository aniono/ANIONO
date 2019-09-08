namespace ANIONO.DddCommon.DddApplicationCore.Interfaces
{
    /// <summary>
    /// Implement it if necessary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}