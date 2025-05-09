using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public class ProductId
    {
        public Guid Value { get; }
        private ProductId(Guid value)
        {
            Value = value;
        }
        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if(value == Guid.Empty)
            {
                throw new DomainException("Product Id can't be empty");
            }
            return new ProductId(value);
        }
    }
}
