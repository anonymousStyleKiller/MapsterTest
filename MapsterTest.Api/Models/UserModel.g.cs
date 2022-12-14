using System;

namespace MapsterTest.Api.Models
{
    public partial class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid Id { get; set; }
    }
}