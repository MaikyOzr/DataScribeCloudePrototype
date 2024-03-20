using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataScribeCloudePrototype.Server.Migrations
{
    /// <inheritdoc />
    public partial class MigrationDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audio",
                columns: table => new
                {
                    AudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlAidio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.AudioId);
                    table.ForeignKey(
                        name: "FK_Audio_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocFiles",
                columns: table => new
                {
                    DocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocFiles", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_DocFiles_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserIDId",
                        column: x => x.UserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pdf",
                columns: table => new
                {
                    PDFId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PDFUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrUserIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdf", x => x.PDFId);
                    table.ForeignKey(
                        name: "FK_Pdf_Users_CurrUserIDId",
                        column: x => x.CurrUserIDId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audio_UserIDId",
                table: "Audio",
                column: "UserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_DocFiles_UserIDId",
                table: "DocFiles",
                column: "UserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserIDId",
                table: "Images",
                column: "UserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserIDId",
                table: "Notes",
                column: "UserIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Pdf_CurrUserIDId",
                table: "Pdf",
                column: "CurrUserIDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "DocFiles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Pdf");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
