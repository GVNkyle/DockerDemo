using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class vGetAllCategories
    {
        [Required]
        [StringLength(50)]
        public string ParentProductCategoryName { get; set; }
        [StringLength(50)]
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryID { get; set; }
    }
}