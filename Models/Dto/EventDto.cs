
using System.ComponentModel.DataAnnotations;

namespace APX.Models.Dto
{
    public class EventDto
    {
        [Required]
        [MaxLength(16)]
        public string APISystem { get; set; }


        [Required]
        [MaxLength(16)]
        public string APIName { get; set; }


        [MaxLength(8)]
        public string APIVersion { get; set; }


        [Required]
        [MaxLength(64)]
        public string Source { get; set; }


        [MaxLength(64)]
        public string Name { get; set; }
        

        [Required]
        [DataType(DataType.DateTime)]
        public string Time { get; set; }


        /// <summary>
        /// Input the string `IN` or `OUT`.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Flow { get; set; }


        [MaxLength(20)]
        public string IPAddress { get; set; }



        [MaxLength(255)]
        public string Status { get; set; }



        [MaxLength(255)]
        public string Desc { get; set; }


        /// <summary>
        /// The field is required when create(post) event.
        /// </summary>
        [MaxLength(50)]
        public string CreatedUser { get; set; }


        /// <summary>
        /// The field is required when update(put) event.
        /// </summary>
        [MaxLength(50)]
        public string UpdatedUser { get; set; }
    }
}