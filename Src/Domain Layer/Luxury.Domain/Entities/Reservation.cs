using System;

namespace Luxury.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public string ReservationId { get; set; }
        public string CustomerId { get; set; }
        public string BookingReferenceNo { get; set; }
        public string RoomId { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime LastDateModified { get; set; }
    }
}
