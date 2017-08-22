using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class BankViewModel
    {
        [Key]
        [Required(ErrorMessage = "The BankCode is Required")]
        [MaxLength(20)]
        [DisplayName("BankCode")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "The BankName is Required")]
        [MaxLength(100)]
        [DisplayName("BankName")]
        public string BankName { get; set; }
    }
}
