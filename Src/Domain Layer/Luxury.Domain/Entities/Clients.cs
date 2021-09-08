using System;

namespace Luxury.Domain.Entities
{
    public class Clients
    {
        public string ClientsId { get; set; }
        public string RoomId { get; set; }
        public string BookingReference { get; set; } 
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientStatus { get; set; }
        public DateTime DateCheckedIn { get; set; } = DateTime.Now;
        public DateTime DateCheckedOut { get; set; }
        public DateTime LastDateModified { get; set; }
    }
}
