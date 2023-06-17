using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.Entities
{
    public class JobCategory :BaseEntity<Guid> 
    {

        public string Name { get; set; }

    }
}
