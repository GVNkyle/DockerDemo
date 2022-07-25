using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class vProductModelCatalogDescription
    {
        public int ProductModelID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Manufacturer { get; set; }
        [StringLength(30)]
        public string Copyright { get; set; }
        [StringLength(256)]
        public string ProductURL { get; set; }
        [StringLength(256)]
        public string WarrantyPeriod { get; set; }
        [StringLength(256)]
        public string WarrantyDescription { get; set; }
        [StringLength(256)]
        public string NoOfYears { get; set; }
        [StringLength(256)]
        public string MaintenanceDescription { get; set; }
        [StringLength(256)]
        public string Wheel { get; set; }
        [StringLength(256)]
        public string Saddle { get; set; }
        [StringLength(256)]
        public string Pedal { get; set; }
        public string BikeFrame { get; set; }
        [StringLength(256)]
        public string Crankset { get; set; }
        [StringLength(256)]
        public string PictureAngle { get; set; }
        [StringLength(256)]
        public string PictureSize { get; set; }
        [StringLength(256)]
        public string ProductPhotoID { get; set; }
        [StringLength(256)]
        public string Material { get; set; }
        [StringLength(256)]
        public string Color { get; set; }
        [StringLength(256)]
        public string ProductLine { get; set; }
        [StringLength(256)]
        public string Style { get; set; }
        [StringLength(1024)]
        public string RiderExperience { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}