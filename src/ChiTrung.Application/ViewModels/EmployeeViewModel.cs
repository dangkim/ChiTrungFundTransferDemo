using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "The FirstName is Required")]
        [DisplayName("FirstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName is Required")]
        [DisplayName("LastName")]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
