using System;

namespace Luxury.Helper.ViewModel
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime LastDateModified { get; set; }
    }
}
