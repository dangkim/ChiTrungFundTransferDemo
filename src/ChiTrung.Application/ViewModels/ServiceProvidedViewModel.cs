using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class ServiceProvidedViewModel
    {
        [Key]
        public string ServiceProvidedId { get; set; }

        [Required(ErrorMessage = "The AppointmentId is Required")]
        [DisplayName("AppointmentId")]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "The ServiceId is Required")]
        [DisplayName("ServiceId")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
