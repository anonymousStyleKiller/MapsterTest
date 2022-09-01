using MapsterTest.Api.Models;

namespace MapsterTest.Api.Models
{
    public static partial class UserMapper
    {
        public static User AdaptToUser(this User p1)
        {
            return p1 == null ? null : new User()
            {
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Country = p1.Country,
                City = p1.City,
                Address = p1.Address,
                CreatedOn = p1.CreatedOn,
                Id = p1.Id
            };
        }
        public static User AdaptTo(this User p2, User p3)
        {
            if (p2 == null)
            {
                return null;
            }
            User result = p3 ?? new User();
            
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Country = p2.Country;
            result.City = p2.City;
            result.Address = p2.Address;
            result.CreatedOn = p2.CreatedOn;
            result.Id = p2.Id;
            return result;
            
        }
    }
}