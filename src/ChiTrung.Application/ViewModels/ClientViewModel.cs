using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Application.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "The ClientName is Required")]
        [DisplayName("ClientName")]
        [MaxLength(128)]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "The ContactMobile is Required")]
        [DisplayName("ContactMobile")]
        [MaxLength(128)]
        public string ContactMobile { get; set; }

        [Required(ErrorMessage = "The ContactMail is Required")]
        [DisplayName("ContactMail")]
        [MaxLength(128)]
        public string ContactMail { get; set; }

        [Required(ErrorMessage = "The IsDeleted is Required")]
        [DisplayName("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
