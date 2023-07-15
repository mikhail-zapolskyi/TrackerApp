using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.Jobs
{
    public class UpdateJobVM
    {
        [Required]
        public string Company { get; set; } = string.Empty;

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        public DateTime? ClosingDate { get; set; }

        public string? HiringManager { get; set; } 

        public string? Referrer { get; set; }

        public string? Notes { get; set; }
    }
}
