using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PublishedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowdBooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowdBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowdBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BorrowdBooks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 856, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 856, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AuthorBio", "AuthorName", "CreatedDate" },
                values: new object[] { "Dr. Mohammad Kaykobad, a luminary in Bengali literature, excels in crafting captivating science fiction narratives. His visionary tales delve into technology, society, and the human condition, sparking contemplation about the future and present complexities. As a trailblazer in Bangladeshi science fiction, Kaykobad's works inspire with their imaginative storytelling and thought-provoking themes.", "Dr. Mohammad Kaykobad", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 856, DateTimeKind.Unspecified).AddTicks(5481), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 856, DateTimeKind.Unspecified).AddTicks(5482), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 856, DateTimeKind.Unspecified).AddTicks(5483), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AvailableCopies", "CreatedBy", "CreatedDate", "ISBN", "ModifiedBy", "ModifiedDate", "PublishedDate", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1L, 2L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(483), new TimeSpan(0, 0, 0, 0, 0)), "0-061-96436-0", null, null, new DateTimeOffset(new DateTime(1933, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sojan Badiya Ghat", 4 },
                    { 2L, 2L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 0, 0, 0, 0)), "0-061-96436-0", null, null, new DateTimeOffset(new DateTime(1927, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bandhan Hara", 4 },
                    { 3L, 1L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(494), new TimeSpan(0, 0, 0, 0, 0)), "0-061-96436-0", null, null, new DateTimeOffset(new DateTime(1924, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bhisher Banshi", 4 },
                    { 4L, 1L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(496), new TimeSpan(0, 0, 0, 0, 0)), "0-061-96436-0", null, null, new DateTimeOffset(new DateTime(1925, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Chhaynat", 4 },
                    { 5L, 1L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(498), new TimeSpan(0, 0, 0, 0, 0)), "0-061-96436-0", null, null, new DateTimeOffset(new DateTime(1928, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sanchita", 4 },
                    { 6L, 1L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(500), new TimeSpan(0, 0, 0, 0, 0)), "984-555-309-5", null, null, new DateTimeOffset(new DateTime(1922, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Agnibeena", 4 },
                    { 7L, 3L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 0, 0, 0, 0)), "9789849647201", null, null, new DateTimeOffset(new DateTime(1992, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Sufi Mohammed Mizanur Rahman", 4 },
                    { 8L, 3L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 0, 0, 0, 0)), "984-70096-0125-5", null, null, new DateTimeOffset(new DateTime(1992, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Newroner Onuronon", 4 },
                    { 9L, 4L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(506), new TimeSpan(0, 0, 0, 0, 0)), "98447012791", null, null, new DateTimeOffset(new DateTime(1992, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bishad Shindhu", 4 },
                    { 10L, 4L, 3, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(508), new TimeSpan(0, 0, 0, 0, 0)), "9788129524188", null, null, new DateTimeOffset(new DateTime(1992, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Jomidar Dorpon", 4 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8450), new TimeSpan(0, 0, 0, 0, 0)), "mamun@gmail.com", "Manun", "Mia", null, null, "0191xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8448), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 0, 0, 0, 0)), "riyaz@gmail.com", "Riyaz", "Hossain", null, null, "0171xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 0, 0, 0, 0)), "rubel@gmail.com", "Rubel", "Hossain", null, null, "0181xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8454), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8456), new TimeSpan(0, 0, 0, 0, 0)), "mazharul@gmail.com", "Mazharul", "Islam", null, null, "0161xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8456), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 0, 0, 0, 0)), "nabib@gmail.com", "Nabib", "Hasan", null, null, "0171xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8458), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 0, 0, 0, 0)), "nawaj@gmail.com", "Nawaj", "Shah", null, null, "0181xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 0, 0, 0, 0)), "hasan@gmail.com", "Hasan", "Khan", null, null, "0191xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8462), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 0, 0, 0, 0)), "sakib@gmail.com", "Sakib", "Hasan", null, null, "0191xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8464), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8466), new TimeSpan(0, 0, 0, 0, 0)), "polash@gmail.com", "Polash", "Mia", null, null, "0161xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8466), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 0, 0, 0, 0)), "ratul@gmail.com", "Ratul", "Islam", null, null, "0191xxxxxxx", new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 858, DateTimeKind.Unspecified).AddTicks(8468), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "BorrowdBooks",
                columns: new[] { "Id", "BookId", "BorrowDate", "CreatedBy", "CreatedDate", "MemberId", "ModifiedBy", "ModifiedDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5207), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 0, 0, 0, 0)), 1L, null, null, new DateTimeOffset(new DateTime(2024, 5, 4, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5209), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 2L, 2L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5237), new TimeSpan(0, 0, 0, 0, 0)), 2L, null, null, new DateTimeOffset(new DateTime(2024, 5, 4, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 3L, 3L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5238), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 0, 0, 0, 0)), 3L, null, null, new DateTimeOffset(new DateTime(2024, 5, 4, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 4L, 4L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5241), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5242), new TimeSpan(0, 0, 0, 0, 0)), 4L, null, null, new DateTimeOffset(new DateTime(2024, 5, 4, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5241), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 5L, 5L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5243), new TimeSpan(0, 0, 0, 0, 0)), 1L, new DateTimeOffset(new DateTime(2024, 4, 27, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5245), new TimeSpan(0, 0, 0, 0, 0)), 5L, null, null, new DateTimeOffset(new DateTime(2024, 5, 4, 11, 8, 3, 857, DateTimeKind.Unspecified).AddTicks(5244), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowdBooks_BookId",
                table: "BorrowdBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowdBooks_MemberId",
                table: "BorrowdBooks",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowdBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9797), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9801), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AuthorBio", "AuthorName", "CreatedDate" },
                values: new object[] { "Kaykobad, a luminary in Bengali literature, excels in crafting captivating science fiction narratives. His visionary tales delve into technology, society, and the human condition, sparking contemplation about the future and present complexities. As a trailblazer in Bangladeshi science fiction, Kaykobad's works inspire with their imaginative storytelling and thought-provoking themes.", "Kaykobad", new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9802), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9803), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 27, 8, 43, 19, 305, DateTimeKind.Unspecified).AddTicks(9804), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
