using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ColytonHubLogin.DataAccessLayer.Models
{
    public class LoginDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int CardNum { get; set; }

        public string Reason { get; set; }

        [Required]
        public bool Signature { get; set; }

        public DateTime SignInDateTime { get; set; }

        public DateTime SignOutDateTime { get; set; }
    }
}
