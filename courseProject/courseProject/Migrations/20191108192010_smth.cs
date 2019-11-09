using Microsoft.EntityFrameworkCore.Migrations;

namespace courseProject.Migrations
{
    public partial class smth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Therapy_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Full_Name = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: true),
                    Min = table.Column<int>(nullable: false),
                    Desc1 = table.Column<string>(nullable: true),
                    Max = table.Column<int>(nullable: false),
                    Desc2 = table.Column<string>(nullable: true),
                    TherapyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Therapies_TherapyId",
                        column: x => x.TherapyId,
                        principalTable: "Therapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Desc = table.Column<string>(nullable: true),
                    Url_Video = table.Column<string>(nullable: true),
                    TherapyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Therapies_TherapyId",
                        column: x => x.TherapyId,
                        principalTable: "Therapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Therapy",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TherapyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Therapy", x => new { x.UserId, x.TherapyId });
                    table.ForeignKey(
                        name: "FK_User_Therapy_Therapies_TherapyId",
                        column: x => x.TherapyId,
                        principalTable: "Therapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Therapy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Answers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Answers", x => new { x.UserId, x.SurveyId });
                    table.ForeignKey(
                        name: "FK_User_Answers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Answers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Role_Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Role_Name" },
                values: new object[] { 2, "patient" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Full_Name", "Login", "Password", "RoleId" },
                values: new object[] { 1, "admin", "admin", "admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Full_Name", "Login", "Password", "RoleId" },
                values: new object[] { 2, "patient 1", "test", "test", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_TherapyId",
                table: "Surveys",
                column: "TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Answers_SurveyId",
                table: "User_Answers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Therapy_TherapyId",
                table: "User_Therapy",
                column: "TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TherapyId",
                table: "Videos",
                column: "TherapyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Answers");

            migrationBuilder.DropTable(
                name: "User_Therapy");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
