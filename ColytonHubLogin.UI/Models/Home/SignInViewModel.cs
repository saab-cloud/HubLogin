using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColytonHubLogin.UI.Models.Home
{
    public class SignInViewModel
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "* First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "* Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "* Card Number")]
        public int CardNum { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Required]
        [Display(Name = "* Checking this box validates as your SIGNATURE")]
        public bool IsSignature { get; set; }

        public string ErrorSignature { get; set; }
        
        public DateTime SignInDateTime { get; set; }

        public DateTime SignOutDateTime { get; set; }

        //public bool FlagSignOut { get; set; }
    }
}
