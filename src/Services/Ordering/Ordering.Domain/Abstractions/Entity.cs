﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get ; set; }
        public DateTime Created { get ; set ; }
        public string? CreateBy { get ; set ; }
        public DateTime LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
