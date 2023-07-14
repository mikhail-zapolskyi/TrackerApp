using Project777.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.Jobs
{
    public class CreateJobVM
    {
        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public Guid JobCategoryId { get; set; }
        
        public DateOnly? ClosingDate { get; set; }

        public string? HiringManager { get; set; }

        public string? Referrer { get; set; }

        public string? Notes { get; set; }
    }
}
