using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudOperations.Models
{
    public class Model
    {
        [Display(Name = "enter user Id")]
        [Required] 
        public int login_id { get; set; }

        [Display(Name = "enter user name")]
        [Required]
        public string user_name { get; set; }

        [Display(Name = "enter password")]
        [Required]
        [DataType(DataType.Password)]

        public string password { get; set; } 
    }
}