using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class ProductModel
    {

        [Key]
        public int ProductModelID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}