using System;

namespace Luxury.Domain.Entities
{
    public class RoomCategory : BaseEntity
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateEntered { get; set; } = DateTime.Now;
        public DateTime LastDateModified { get; set; }
    }
}
