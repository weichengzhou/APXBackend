
using System.ComponentModel.DataAnnotations;

namespace APX.Models.Dto
{
    public class CodeKindDto
    {
        /// <summary>
        /// Name is required when created, nullable when updated.
        /// </summary>
        [MaxLength(10)]
        public string Name { get; set; }


        [MaxLength(20)]
        public string NameT { get; set; }
    }
}