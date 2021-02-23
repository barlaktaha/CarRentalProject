using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Condition:IEntity
    {
        public int ConditionId { get; set; }
        public string ConditionName { get; set; }
    }
}
