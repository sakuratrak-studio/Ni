using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ni.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NiUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    HeadImgFileKey = table.Column<int>(nullable: false),
                    PreferedLanguage = table.Column<string>(nullable: true),
                    AccountCreateTime = table.Column<DateTime>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiWebsites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    AllowOrigin = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiWebsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NiWebsites_NiUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "NiUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NiComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    SenderId = table.Column<string>(nullable: true),
                    CommentWebsiteId = table.Column<Guid>(nullable: false),
                    ReplyParentId = table.Column<int>(nullable: true),
                    SendTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NiComments_NiWebsites_CommentWebsiteId",
                        column: x => x.CommentWebsiteId,
                        principalTable: "NiWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NiComments_NiComments_ReplyParentId",
                        column: x => x.ReplyParentId,
                        principalTable: "NiComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NiComments_NiUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "NiUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiComments_CommentWebsiteId",
                table: "NiComments",
                column: "CommentWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_NiComments_ReplyParentId",
                table: "NiComments",
                column: "ReplyParentId");

            migrationBuilder.CreateIndex(
                name: "IX_NiComments_SenderId",
                table: "NiComments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NiWebsites_OwnerId",
                table: "NiWebsites",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiComments");

            migrationBuilder.DropTable(
                name: "NiWebsites");

            migrationBuilder.DropTable(
                name: "NiUsers");
        }
    }
}
