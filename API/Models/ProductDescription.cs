using System.ComponentModel.DataAnnotations;


namespace API.Models
{
    public partial class ProductDescription
    {

        /// <summary>
        /// Primary key for ProductDescription records.
        /// </summary>
        [Key]
        public int ProductDescriptionID { get; set; }

        /// <summary>
        /// Description of the product.
        /// </summary>
        [Required]
        [StringLength(400)]
        public string Description { get; set; }

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