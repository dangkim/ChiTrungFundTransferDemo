using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class ServiceProvided : Entity
    {
        public ServiceProvided(int appointmentId, int serviceId, decimal price, bool isDeleted = false)
        {
            AppointmentId = appointmentId;
            ServiceId = serviceId;
            Price = price;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected ServiceProvided() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceProvidedId { get; private set; }

        public int AppointmentId { get; private set; }

        public int ServiceId { get; private set; }

        public decimal Price { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
