using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace v2.Models
{
    public class EmailViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }          
        
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}