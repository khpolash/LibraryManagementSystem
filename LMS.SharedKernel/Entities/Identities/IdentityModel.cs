using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.SharedKernel.Entities.Identities;

public class IdentityModel
{
    [Table("Users")]
    public class User : IdentityUser<long>
    {
        public long CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }

    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<long>
    {
    }

    [Table("UserClaims")]
    public class UserClaim : IdentityUserClaim<long>
    {
    }

    public class UserLogin : IdentityUserLogin<long>
    {
    }

    public class RoleClaim : IdentityRoleClaim<long>
    {
    }

    [Table("UserTokens")]
    public class UserToken : IdentityUserToken<long>
    {
    }

    [Table("Roles")]
    public class Role : IdentityRole<long>
    {
        public Role()
        {
        }
        public Role(string name) { Name = name; }

        public int StatusId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public long? ModifiedBy { get; set; }
    }
}

