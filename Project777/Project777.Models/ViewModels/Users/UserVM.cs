using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Models.ViewModels.Users
{
    public class UserVM
    {
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// User's First Name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User's lastname
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// user's email
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
