using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class ServiceViewModel
    {
        [Key]
        public string ServiceId { get; set; }

        [Required(ErrorMessage = "The ServiceName is Required")]
        [DisplayName("ServiceName")]
        [MaxLength(128)]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "The Duration is Required")]
        [DisplayName("Duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
