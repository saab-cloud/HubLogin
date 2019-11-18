using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColytonHubLogin.UI.Models.Home
{
    public class SignOutViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "* Card Number")]
        public int CardNum { get; set; }

        public string ErrorStr { get; set; }

        public DateTime SignInDateTime { get; set; }

        public DateTime SignOutDateTime { get; set; }
    }
}
