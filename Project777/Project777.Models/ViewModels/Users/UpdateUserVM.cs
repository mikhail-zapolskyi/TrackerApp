using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.Users
{
    public class UpdateUserVM
    {
        /// <summary>
        /// User's First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User's lastname
        /// </summary>
        [Required]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// user's email
        /// </summary>
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
