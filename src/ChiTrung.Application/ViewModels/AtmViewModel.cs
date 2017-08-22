using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class AtmViewModel
    {
        [Key]
        public string AtmCode { get; set; }

        [Required(ErrorMessage = "The Atm name is Required")]
        [MaxLength(100)]
        [DisplayName("AtmName")]
        public string AtmName { get; set; }

        [Required(ErrorMessage = "The bank name is Required")]
        [MaxLength(20)]
        [DisplayName("BankCode")]
        public string BankCode { get; set; }
    }
}
