using SystemMidterm_19070006058.Context;

namespace SystemMidterm_19070006058.Source
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public MidtermContext _context;

        public GenericService(MidtermContext context)
        {
            _context = context;
        }

        public void TAdd(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void TDelete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> TGetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T TGetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void TUpdate(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }

}
