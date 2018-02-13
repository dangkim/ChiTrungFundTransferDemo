using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class GameEventsViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The TransactionID is Required")]
        public Guid TransactionId { get; set; }

        [Required(ErrorMessage = "The MerchantID is Required")]
        public string MerchantId { get; set; }

        [Required(ErrorMessage = "The MemberId is Required")]
        public string MemberId { get; set; }

        [Required(ErrorMessage = "The GameId is Required")]
        public string GameId { get; set; }

        [Required(ErrorMessage = "The CreatedDate is Required")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date, ErrorMessage = "Wrong date format")]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "The Event is Required")]
        public string Event { get; set; }
    }
}
