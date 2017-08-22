using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class WithdrawalViewModel
    {
        [Key]
        public string WitCode { get; set; }

        [Required(ErrorMessage = "The Account code is Required")]
        [MaxLength(20)]
        [DisplayName("AccCode")]
        public string AccCode { get; set; }

        [Required(ErrorMessage = "The amount is Required")]
        [DisplayName("Amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "The Atm code is Required")]
        [MaxLength(20)]
        [DisplayName("AtmCode")]
        public string AtmCode { get; set; }

        [Required(ErrorMessage = "The Transaction date is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Wrong date format")]
        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
    }
}
