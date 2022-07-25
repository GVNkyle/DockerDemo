
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class vProductAndDescription
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductModel { get; set; }
        [Required]
        [StringLength(6)]
        public string Culture { get; set; }
        [Required]
        [StringLength(400)]
        public string Description { get; set; }
    }
}