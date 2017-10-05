using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class ScheduleViewModel
    {
        [Key]
        public string ScheduleId { get; set; }

        [Required(ErrorMessage = "The EmployeeId is Required")]
        [DisplayName("EmployeeId")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "The From is Required")]
        [DisplayName("From")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "The To is Required")]
        [DisplayName("To")]
        public DateTime To { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
