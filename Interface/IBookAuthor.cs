namespace EF_CORE_EMPTY_CONTROLLER.Interface
{
    public interface IBookAuthor<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);       
        Task Add(T t);
        Task Update(int id, T t);        
        Task DeleteById(int id);
    }


}
