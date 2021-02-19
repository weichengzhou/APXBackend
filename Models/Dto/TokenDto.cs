
using System.ComponentModel.DataAnnotations;

namespace APX.Models.Dto
{
    public class TokenDto
    {
        [Required]
        public string Body { get; set; }
        

        [Required]
        [MaxLength(50)]
        public string CreatedUser { get; set; }


        [Required]
        [MaxLength(50)]
        public string UpdatedUser { get; set; }
    }
}