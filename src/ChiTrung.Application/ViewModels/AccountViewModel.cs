using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        public string AccCode { get; set; }

        [Required(ErrorMessage = "The BankCode is Required")]
        [MaxLength(20)]
        [DisplayName("BankCode")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "The CusId is Required")]
        [DisplayName("Customer Id")]
        public string CusId { get; set; }
    }
}
