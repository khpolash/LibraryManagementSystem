using LMS.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(a => a.Id);
        builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
        builder.Property(x => x.Title).HasMaxLength(85);
        builder.Property(x => x.ISBN).HasMaxLength(20);
        builder.HasData(new Book
        {
            Id = 1,
            Title = "Sojan Badiya Ghat",
            ISBN = "0-061-96436-0",
            AuthorId = 2,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1933, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 2,
            Title = "Bandhan Hara",
            ISBN = "0-061-96436-0",
            AuthorId = 2,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1927, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 3,
            Title = "Bhisher Banshi",
            ISBN = "0-061-96436-0",
            AuthorId = 1,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1924, 08, 24, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 4,
            Title = "Chhaynat",
            ISBN = "0-061-96436-0",
            AuthorId = 1,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1925, 09, 21, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 5,
            Title = "Sanchita",
            ISBN = "0-061-96436-0",
            AuthorId = 1,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1928, 11, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 6,
            Title = "Agnibeena",
            ISBN = "984-555-309-5",
            AuthorId = 1,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1922, 11, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 7,
            Title = "Sufi Mohammed Mizanur Rahman",
            ISBN = "9789849647201",
            AuthorId = 3,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1992, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 8,
            Title = "Newroner Onuronon",
            ISBN = "984-70096-0125-5",
            AuthorId = 3,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1992, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 9,
            Title = "Bishad Shindhu",
            ISBN = "98447012791",
            AuthorId = 4,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1992, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Book
        {
            Id = 10,
            Title = "Jomidar Dorpon",
            ISBN = "9788129524188",
            AuthorId = 4,
            AvailableCopies = 3,
            TotalCopies = 4,
            PublishedDate = new DateTimeOffset(1992, 10, 1, 0, 0, 0, TimeSpan.Zero),
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
