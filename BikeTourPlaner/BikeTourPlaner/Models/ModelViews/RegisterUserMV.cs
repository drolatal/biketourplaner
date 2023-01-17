using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class RegisterUserMV
    {
        [Required, MaxLength(50)]
        public string NickName { get; set; }

        [Required, MaxLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate{get; set;}

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RePassword { get; set; }

    }
}
