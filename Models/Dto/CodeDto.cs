
using System.ComponentModel.DataAnnotations;

namespace APX.Models.Dto
{
    public class CodeDto
    {
        /// <summary>
        /// ID is required when created, nullable when updated.
        /// </summary>
        [MaxLength(20)]
        public string ID { get; set; }


        /// <summary>Name of CodeKind.</summary>
        [Required]
        [MaxLength(10)]
        public string Kind { get; set; }


        [MaxLength(7)]
        public string SortOrder { get; set; }


        [MaxLength(20)]
        public string NameT { get; set; }


        [MaxLength(50)]
        public string Content { get; set; }
    }
}