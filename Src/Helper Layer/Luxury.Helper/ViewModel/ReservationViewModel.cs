using System;

namespace Luxury.Helper.ViewModel
{
    public class ReservationViewModel
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
