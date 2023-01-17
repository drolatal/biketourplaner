using System.ComponentModel.DataAnnotations;

namespace BikeTourPlaner.Models.ModelViews
{
    public class LoginUserMV
    {
        [Required, MaxLength(50)]
        public string NickName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
