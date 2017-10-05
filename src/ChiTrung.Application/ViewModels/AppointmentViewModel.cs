using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class AppointmentViewModel
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "The DateCreated is Required")]
        [DisplayName("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "The EmployeeCreated is Required")]
        [DisplayName("EmployeeCreated")]
        public int EmployeeCreated { get; set; }

        [Required(ErrorMessage = "The ClientId is Required")]
        [DisplayName("ClientId")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "The EmployeeId is Required")]
        [DisplayName("EmployeeId")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "The ClientName is Required")]
        [MaxLength(128)]
        [DisplayName("ClientName")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "The ContactMobile is Required")]
        [MaxLength(128)]
        [DisplayName("ContactMobile")]
        public string ContactMobile { get; set; }

        [Required(ErrorMessage = "The StartTime is Required")]
        [DisplayName("StartTime")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "The EndTimeExpected is Required")]
        [DisplayName("EndTimeExpected")]
        public DateTime EndTimeExpected { get; set; }

        [Required(ErrorMessage = "The EndTime is Required")]
        [DisplayName("EndTime")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "The PriceExpected is Required")]
        [DisplayName("PriceExpected")]
        public decimal PriceExpected { get; set; }

        [Required(ErrorMessage = "The PriceFull is Required")]
        [DisplayName("PriceFull")]
        public decimal PriceFull { get; set; }

        [Required(ErrorMessage = "The PriceFinal is Required")]
        [DisplayName("PriceFinal")]
        public decimal PriceFinal { get; set; }

        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "The Cancelled is Required")]
        [DisplayName("Cancelled")]
        public string Cancelled { get; set; }

        [DisplayName("CancellationReason")]
        public string CancellationReason { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
