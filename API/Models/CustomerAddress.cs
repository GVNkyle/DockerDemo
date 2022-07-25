using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class CustomerAddress
    {

        [Key]
        public int CustomerID { get; set; }

        [Key]
        public int AddressID { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressType { get; set; }

        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}