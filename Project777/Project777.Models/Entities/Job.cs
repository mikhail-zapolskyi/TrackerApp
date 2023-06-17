using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.Entities
{
    public class Job: BaseEntity<Guid>
    {
        public string Company { get; set; }

        public string JobTitle { get; set; }

        public Guid JobCategoryID { get; set; }

        // This is a navigation property
        public JobCategory JobCategory { get; set; }
        
        public DateOnly? ClosingDate { get; set; }

        public string? HiringManager { get; set; }

        public string? Referrer { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
