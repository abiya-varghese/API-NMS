namespace nms_backend_api.Logics.Contract
{
    public interface INotificationRepository<T> where T : class
    {

        T Get(string id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);

    }
}
