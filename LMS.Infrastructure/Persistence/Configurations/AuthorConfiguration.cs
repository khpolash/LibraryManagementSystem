using LMS.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(a => a.Id);
        builder.Property(x => x.AuthorName).HasMaxLength(85);
        builder.Property(x => x.AuthorBio).HasMaxLength(400);
        builder.HasData(new Author
        {
            Id = 1,
            AuthorName = "Kazi Nazrul Islam",
            AuthorBio = "Kazi Nazrul Islam, known as the \"Rebel Poet,\" was a Bengali poet, musician, and revolutionary thinker. His works encompassed themes of freedom, social justice, and rebellion against oppression. A pioneer of modern Bengali literature, his poetry and songs continue to inspire generations.",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Author
        {
            Id = 2,
            AuthorName = "Jasimuddin",
            AuthorBio = "Jasimuddin, the eminent Bengali poet, is celebrated for his poignant portrayal of rural life and folk culture. Through his evocative poetry, he captures the essence of Bengal's countryside, depicting its simplicity, struggles, and rich traditions. His works resonate with themes of love, nature, and the human experience, earning him enduring admiration and acclaim in Bengali literature.",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Author
        {
            Id = 3,
            AuthorName = "Dr. Mohammad Kaykobad",
            AuthorBio = "Dr. Mohammad Kaykobad, a luminary in Bengali literature, excels in crafting captivating science fiction narratives. His visionary tales delve into technology, society, and the human condition, sparking contemplation about the future and present complexities. As a trailblazer in Bangladeshi science fiction, Kaykobad's works inspire with their imaginative storytelling and thought-provoking themes.",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Author
        {
            Id = 4,
            AuthorName = "Mir Mosharraf Hossain",
            AuthorBio = "Mir Mosharraf Hossain, a revered Bengali writer, intricately explores societal nuances through masterpieces like \"Bishad Shindhu\" and \"Adbhut Lok.\" His narratives, rich in character and vivid in depiction, delve into morality, societal norms, and human relationships. Hossain's legacy as a pioneering figure inspires generations with his timeless contributions to Bengali literature.",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        }, new Author
        {
            Id = 5,
            AuthorName = "Abu Ishaque",
            AuthorBio = "Abu Ishaque, a luminary in Bengali literature, mesmerizes with his profound storytelling and poetic finesse. Through his works, he delves into human emotions, society, and spirituality, offering insightful reflections on life's myriad experiences.",
            CreatedBy = 1,
            CreatedDate = DateTimeOffset.UtcNow,
        });
    }
}
