using System;

namespace Luxury.Helper.ViewModel
{
    public class RoomViewModel
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string CategoryId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomStatus { get; set; }
        public DateTime DateEntered { get; set; } 
        public DateTime LastDateModified { get; set; }
    }
}
