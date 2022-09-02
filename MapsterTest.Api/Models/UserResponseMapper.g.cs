using MapsterTest.Api.Dto;

namespace MapsterTest.Api.Dto
{
    public static partial class UserResponseMapper
    {
        public static UserResponse AdaptToUserResponse(this UserResponse p1)
        {
            return p1 == null ? null : new UserResponse()
            {
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Country = p1.Country,
                City = p1.City
            };
        }
        public static UserResponse AdaptTo(this UserResponse p2, UserResponse p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserResponse result = p3 ?? new UserResponse();
            
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.Country = p2.Country;
            result.City = p2.City;
            return result;
            
        }
    }
}