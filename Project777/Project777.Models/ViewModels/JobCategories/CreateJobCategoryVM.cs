using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.JobCategories
{
    public class CreateJobCategoryVM
    {
        /// <summary>
        /// Job Category Name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
