using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.Jobs
{
    public class JobVM
    {
        public Guid JobId { get; set; }
        public string Company { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public Guid JobCategoryID { get; set; }
        
        public DateOnly? ClosingDate { get; set; }

        public string? HiringManager { get; set; }

        public string? Referrer { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    
}
