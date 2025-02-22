using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeGuide.Repositary.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Uni_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Uni_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Col_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeesEgy = table.Column<float>(type: "real", nullable: false),
                    FeesInternational = table.Column<float>(type: "real", nullable: false),
                    AppFeesEgy = table.Column<float>(type: "real", nullable: false),
                    AppFeesInternational = table.Column<float>(type: "real", nullable: false),
                    FirstInstallment = table.Column<float>(type: "real", nullable: false),
                    SecInstallment = table.Column<float>(type: "real", nullable: false),
                    DurationOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uni_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Col_Id);
                    table.ForeignKey(
                        name: "FK_Colleges_Universities_Uni_Id",
                        column: x => x.Uni_Id,
                        principalTable: "Universities",
                        principalColumn: "Uni_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAids",
                columns: table => new
                {
                    Aid_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aid_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AidDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uni_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAids", x => x.Aid_Id);
                    table.ForeignKey(
                        name: "FK_FinancialAids_Universities_Uni_Id",
                        column: x => x.Uni_Id,
                        principalTable: "Universities",
                        principalColumn: "Uni_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Rec_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Col_Id = table.Column<int>(type: "int", nullable: false),
                    Uni_Id = table.Column<int>(type: "int", nullable: false),
                    UniversityUni_Id = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Rec_Id);
                    table.ForeignKey(
                        name: "FK_Recommendations_Colleges_Col_Id",
                        column: x => x.Col_Id,
                        principalTable: "Colleges",
                        principalColumn: "Col_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recommendations_Universities_UniversityUni_Id",
                        column: x => x.UniversityUni_Id,
                        principalTable: "Universities",
                        principalColumn: "Uni_Id");
                    table.ForeignKey(
                        name: "FK_Recommendations_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colleges_Uni_Id",
                table: "Colleges",
                column: "Uni_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAids_Uni_Id",
                table: "FinancialAids",
                column: "Uni_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_Col_Id",
                table: "Recommendations",
                column: "Col_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UniversityUni_Id",
                table: "Recommendations",
                column: "UniversityUni_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_User_Id",
                table: "Recommendations",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialAids");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
