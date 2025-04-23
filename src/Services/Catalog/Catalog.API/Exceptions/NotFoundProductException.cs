using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions
{
    public class NotFoundProductException:NotFoundException
    {
        private object Id { get; set; }
        public NotFoundProductException(object id) : base("Product",id)
        {
            Id = id;
        }
    }
}
