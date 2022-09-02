using MapsterTest.Api.Models;

namespace MapsterTest.Api.Models
{
    public static partial class UserMapper
    {
        public static UserModel AdaptToModel(this User p1)
        {
            return p1 == null ? null : new UserModel()
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
        public static UserModel AdaptTo(this User p2, UserModel p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserModel result = p3 ?? new UserModel();
            
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Country = p2.Country;
            result.City = p2.City;
            result.Address = p2.Address;
            result.CreatedOn = p2.CreatedOn;
            result.Id = p2.Id;
            return result;
            
        }
        public static User AdaptToUser(this User p4)
        {
            return p4 == null ? null : new User()
            {
                FirstName = p4.FirstName,
                LastName = p4.LastName,
                Country = p4.Country,
                City = p4.City,
                Address = p4.Address,
                CreatedOn = p4.CreatedOn,
                Id = p4.Id
            };
        }
        public static User AdaptTo(this User p5, User p6)
        {
            if (p5 == null)
            {
                return null;
            }
            User result = p6 ?? new User();
            
            result.FirstName = p5.FirstName;
            result.LastName = p5.LastName;
            result.Country = p5.Country;
            result.City = p5.City;
            result.Address = p5.Address;
            result.CreatedOn = p5.CreatedOn;
            result.Id = p5.Id;
            return result;
            
        }
    }
}