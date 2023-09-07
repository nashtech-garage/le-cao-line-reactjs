using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Common
{
    public abstract class EntityBase
    {
        public string Id { get; protected set; }
    }
}
