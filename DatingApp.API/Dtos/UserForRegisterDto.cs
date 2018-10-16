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
    }
}