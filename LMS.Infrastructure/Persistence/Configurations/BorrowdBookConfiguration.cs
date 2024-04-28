

using LMS.SharedKernel.Core;
using LMS.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations;

public class BorrowdBookConfiguration : IEntityTypeConfiguration<BorrowdBook>
{
    public void Configure(EntityTypeBuilder<BorrowdBook> builder)
    {
        builder.ToTable("BorrowdBooks");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Member).WithMany(x => x.BorrowdBooks).HasForeignKey(x => x.MemberId);
        builder.HasOne(x => x.Book).WithMany(x => x.BorrowdBooks).HasForeignKey(x => x.BookId);
        builder.HasData(new BorrowdBook
        {
            Id = 1,
            BookId = 1,
            MemberId = 1,
            BorrowDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(7),
            Status = BookStatus.Borrowed,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new BorrowdBook
        {
            Id = 2,
            BookId = 2,
            MemberId = 2,
            BorrowDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(7),
            Status = BookStatus.Borrowed,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new BorrowdBook
        {
            Id = 3,
            BookId = 3,
            MemberId = 3,
            BorrowDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(7),
            Status = BookStatus.Borrowed,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new BorrowdBook
        {
            Id = 4,
            BookId = 4,
            MemberId = 4,
            BorrowDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(7),
            Status = BookStatus.Borrowed,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new BorrowdBook
        {
            Id = 5,
            BookId = 5,
            MemberId = 5,
            BorrowDate = DateTimeOffset.UtcNow,
            ReturnDate = DateTimeOffset.UtcNow.AddDays(7),
            Status = BookStatus.Borrowed,
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
