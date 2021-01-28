using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CvCrearing.Migrations
{
    public partial class CvBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateID);
                });

            migrationBuilder.CreateTable(
                name: "Careerinformations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateID = table.Column<int>(nullable: false),
                    CompamnyName = table.Column<string>(nullable: true),
                    CompanyBusiness = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careerinformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Careerinformations_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInformation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateID = table.Column<int>(nullable: false),
                    LavelOfEducation = table.Column<string>(nullable: true),
                    ExamName = table.Column<string>(nullable: true),
                    MajorSub = table.Column<string>(nullable: true),
                    InstuteName = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    YearOfPassing = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInformation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EducationalInformation_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfoTabs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfoTabs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalInfoTabs_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferanceInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Relation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferanceInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReferanceInfos_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraningInformation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidateID = table.Column<int>(nullable: false),
                    TraningTitle = table.Column<string>(nullable: true),
                    Topicscoverd = table.Column<string>(nullable: true),
                    Institute = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    TraningYear = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraningInformation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TraningInformation_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Careerinformations_CandidateID",
                table: "Careerinformations",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalInformation_CandidateID",
                table: "EducationalInformation",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfoTabs_CandidateID",
                table: "PersonalInfoTabs",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferanceInfos_CandidateID",
                table: "ReferanceInfos",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_TraningInformation_CandidateID",
                table: "TraningInformation",
                column: "CandidateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Careerinformations");

            migrationBuilder.DropTable(
                name: "EducationalInformation");

            migrationBuilder.DropTable(
                name: "PersonalInfoTabs");

            migrationBuilder.DropTable(
                name: "ReferanceInfos");

            migrationBuilder.DropTable(
                name: "TraningInformation");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
