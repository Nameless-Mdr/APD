namespace APD.DAL.Base;

public interface IBaseRepo<T, E>
{
    public Task<T> Create(E entity);

    public Task<IEnumerable<E>> GetAllModels();

    public Task<bool> Delete(T id);
}