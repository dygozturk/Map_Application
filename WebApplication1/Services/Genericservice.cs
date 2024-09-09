public interface IGenericService<T>
{
    List<T> GetAll();
    T GetById(long id);
    T Add(T entity);
    T Update(long id, T entity);
    bool Delete(long id);
}

public class GenericService<T> : IGenericService<T>
{
    // Bu genel sınıf, CRUD işlemlerinin temelini sağlar.
    public virtual List<T> GetAll() { /* Genel get all işlemi */ return null; }
    public virtual T GetById(long id) { /* Genel get by id işlemi */ return default; }
    public virtual T Add(T entity) { /* Genel add işlemi */ return default; }
    public virtual T Update(long id, T entity) { /* Genel update işlemi */ return default; }
    public virtual bool Delete(long id) { /* Genel delete işlemi */ return false; }
}
