namespace SystemMidterm_19070006058.Source
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetAll();
        T TGetById(int id);
    }
}
