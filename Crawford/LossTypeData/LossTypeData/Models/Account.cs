using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LossTypeData.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
    }
}