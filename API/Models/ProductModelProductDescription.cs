using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class ProductModelProductDescription
    {

        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        [Key]
        public int ProductModelID { get; set; }

        /// <summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        /// </summary>
        [Key]
        public int ProductDescriptionID { get; set; }

        /// <summary>
        /// The culture for which the description is written
        /// </summary>
        [Key]
        [StringLength(6)]
        public string Culture { get; set; }
        public Guid rowguid { get; set; }


        public DateTime ModifiedDate { get; set; }
    }
}