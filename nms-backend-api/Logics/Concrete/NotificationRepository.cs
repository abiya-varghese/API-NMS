using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Concrete
{
    public class NotificationRepository
    {
        public readonly MyContext contextClass;

        public NotificationRepository(MyContext contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(Notification entity)
        {
            /*            entity.GeneraterandomMessage();
                        entity.notificationId=Guid.NewGuid().ToString();*/
            try
            {
                entity.notificationId = new Random().Next(1000, 10000).ToString();
                contextClass.notification.Add(entity);
                contextClass.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(string id)
        {
            try
            {
                Notification notification = contextClass.notification.Find(id);
                contextClass.notification.Remove(notification);
                contextClass.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Notification Get(string id)
        {
            try
            {
                return contextClass.notification.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Notification> GetAll()
        {
            try
            {
                return contextClass.notification.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Notification entity)
        {
            try
            {
                contextClass.Update(entity);
                contextClass.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
