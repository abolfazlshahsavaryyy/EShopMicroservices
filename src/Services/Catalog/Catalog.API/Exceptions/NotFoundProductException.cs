namespace Catalog.API.Exceptions
{
    public class NotFoundProductException:Exception
    {
        private object Id { get; set; }
        public NotFoundProductException(object id) : base($"Product not found with id : {id}")
        {
            Id = id;
        }
    }
}
