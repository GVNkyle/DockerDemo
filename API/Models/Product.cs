using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class Product
    {
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Unique product identification number.
        /// </summary>
        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        /// <summary>
        /// Product color.
        /// </summary>
        [StringLength(15)]
        public string Color { get; set; }

        /// <summary>
        /// Standard cost of the product.
        /// </summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Selling price.
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Product size.
        /// </summary>
        [StringLength(5)]
        public string Size { get; set; }

        /// <summary>
        /// Product weight.
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. 
        /// </summary>
        public int? ProductCategoryID { get; set; }

        /// <summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        public int? ProductModelID { get; set; }

        /// <summary>
        /// Date the product was available for sale.
        /// </summary>
        public DateTime SellStartDate { get; set; }

        /// <summary>
        /// Date the product was no longer available for sale.
        /// </summary>
        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// Date the product was discontinued.
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }

        /// <summary>
        /// Small image of the product.
        /// </summary>
        public byte[] ThumbNailPhoto { get; set; }

        /// <summary>
        /// Small image file name.
        /// </summary>
        [StringLength(50)]
        public string ThumbnailPhotoFileName { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}