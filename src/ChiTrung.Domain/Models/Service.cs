using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Service : Entity
    {
        public Service(string serviceName, int duration, decimal price, bool isDeleted = false)
        {
            ServiceName = serviceName;
            Duration = duration;
            Price = price;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected Service() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; private set; }

        public string ServiceName { get; private set; }

        public int Duration { get; private set; }

        public decimal Price { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
