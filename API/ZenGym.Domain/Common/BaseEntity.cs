using System;
using System.Collections.Generic;
using System.Text;

namespace ZenGym.Domain.Common
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        public  DateTime CreationDate { get; set; }
        
    }
}
