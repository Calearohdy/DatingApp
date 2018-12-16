using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required] //Attribute
        public string Username {get; set;}

        [Required] //Attribute
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Between 4 to 8 characters allowed")]
        public string Password {get; set;}

        [Required]
        public string KnownAs { get; set;}

        [Required]
        public string Gender { get; set;}

        [Required]
        public string City { get; set;}

        [Required]
        public string Country { get; set;}
        
        [Required]
        public DateTime DateOfBirth { get; set;}
        public DateTime Created { get; set;}
        public DateTime LastActive { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
        
    }
}