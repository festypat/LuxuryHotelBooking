using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Luxury.Domain.Entities
{
    public class Rooms : BaseEntity
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string CategoryId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomStatus { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public DateTime DateEntered { get; set; } = DateTime.Now;
        public DateTime LastDateModified { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }
}
