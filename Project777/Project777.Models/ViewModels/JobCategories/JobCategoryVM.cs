using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.JobCategories
{
    public class JobCategoryVM
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Job Category Name
        /// </summary>
        
        public string Name { get; set; } = string.Empty;

    }
}

