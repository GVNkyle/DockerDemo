using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class ProductCategory
    {
        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        [Key]
        public int ProductCategoryID { get; set; }

        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        public int? ParentProductCategoryID { get; set; }

        /// <summary>
        /// Category description.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}