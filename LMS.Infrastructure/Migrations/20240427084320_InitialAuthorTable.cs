using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    AuthorBio = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorBio", "AuthorName", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, "Kazi Nazrul Islam, known as the \"Rebel Poet,\" was a Bengali poet, musician, and revolutionary thinker. His works encompassed themes of freedom, social justice, and rebellion against oppression. A pioneer of modern Bengali literature, his poetry and songs continue to inspire generations.", "Kazi Nazrul Islam", 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9797), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 2L, "Jasimuddin, the eminent Bengali poet, is celebrated for his poignant portrayal of rural life and folk culture. Through his evocative poetry, he captures the essence of Bengal's countryside, depicting its simplicity, struggles, and rich traditions. His works resonate with themes of love, nature, and the human experience, earning him enduring admiration and acclaim in Bengali literature.", "Jasimuddin", 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 3L, "Kaykobad, a luminary in Bengali literature, excels in crafting captivating science fiction narratives. His visionary tales delve into technology, society, and the human condition, sparking contemplation about the future and present complexities. As a trailblazer in Bangladeshi science fiction, Kaykobad's works inspire with their imaginative storytelling and thought-provoking themes.", "Kaykobad", 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 4L, "Mir Mosharraf Hossain, a revered Bengali writer, intricately explores societal nuances through masterpieces like \"Bishad Shindhu\" and \"Adbhut Lok.\" His narratives, rich in character and vivid in depiction, delve into morality, societal norms, and human relationships. Hossain's legacy as a pioneering figure inspires generations with his timeless contributions to Bengali literature.", "Mir Mosharraf Hossain", 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 0, 0, 0, 0)), null, null },
                    { 5L, "Abu Ishaque, a luminary in Bengali literature, mesmerizes with his profound storytelling and poetic finesse. Through his works, he delves into human emotions, society, and spirituality, offering insightful reflections on life's myriad experiences.", "Abu Ishaque", 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9804), new TimeSpan(0, 0, 0, 0, 0)), null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
