﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueObjects
{
    public class OrderId
    {
        public Guid Value { get; }
        private OrderId(Guid value)
        {
            Value = value;
        }
        public static OrderId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if(value == Guid.Empty)
            {
                throw new DomainException("Order Id can't be empty");
            }
            return new OrderId(value);
        }
    }
}
