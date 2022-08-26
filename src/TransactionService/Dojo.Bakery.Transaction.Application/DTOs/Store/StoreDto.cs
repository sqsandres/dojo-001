using System;

namespace Dojo.Bakery.Transaction.Application.DTOs.Store
{
    public class StoreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string DocumentNumber { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
