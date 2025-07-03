using System.ComponentModel.DataAnnotations;

namespace ModernAPI.Api.Models
{
    public class CreateUserModel
    {
        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 3)]
        public required string UserName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
    }
}
