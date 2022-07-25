using System.ComponentModel.DataAnnotations;


namespace API.Models
{
    public partial class SalesOrderDetail
    {

        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// </summary>
        [Key]
        public int SalesOrderID { get; set; }

        /// <summary>
        /// Primary key. One incremental unique number per product sold.
        /// </summary>
        [Key]
        public int SalesOrderDetailID { get; set; }

        /// <summary>
        /// Quantity ordered per product.
        /// </summary>
        public short OrderQty { get; set; }

        /// <summary>
        /// Product sold to customer. Foreign key to Product.ProductID.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Selling price of a single product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount amount.
        /// </summary>
        public decimal UnitPriceDiscount { get; set; }

        /// <summary>
        /// Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.
        /// </summary>
        public decimal LineTotal { get; set; }

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