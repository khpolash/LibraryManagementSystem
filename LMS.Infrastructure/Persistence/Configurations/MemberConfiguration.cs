using LMS.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(85);
        builder.Property(x => x.LastName).HasMaxLength(85);
        builder.Property(x => x.Email).HasMaxLength(85);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);
        builder.HasData(new Member
        {
            Id = 1,
            FirstName = "Manun",
            LastName = "Mia",
            Email = "mamun@gmail.com",
            PhoneNumber = "0191xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 2,
            FirstName = "Riyaz",
            LastName = "Hossain",
            Email = "riyaz@gmail.com",
            PhoneNumber = "0171xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 3,
            FirstName = "Rubel",
            LastName = "Hossain",
            Email = "rubel@gmail.com",
            PhoneNumber = "0181xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 4,
            FirstName = "Mazharul",
            LastName = "Islam",
            Email = "mazharul@gmail.com",
            PhoneNumber = "0161xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 5,
            FirstName = "Nabib",
            LastName = "Hasan",
            Email = "nabib@gmail.com",
            PhoneNumber = "0171xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 6,
            FirstName = "Nawaj",
            LastName = "Shah",
            Email = "nawaj@gmail.com",
            PhoneNumber = "0181xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 7,
            FirstName = "Hasan",
            LastName = "Khan",
            Email = "hasan@gmail.com",
            PhoneNumber = "0191xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 8,
            FirstName = "Sakib",
            LastName = "Hasan",
            Email = "sakib@gmail.com",
            PhoneNumber = "0191xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 9,
            FirstName = "Polash",
            LastName = "Mia",
            Email = "polash@gmail.com",
            PhoneNumber = "0161xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Member
        {
            Id = 10,
            FirstName = "Ratul",
            LastName = "Islam",
            Email = "ratul@gmail.com",
            PhoneNumber = "0191xxxxxxx",
            RegistrationDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
