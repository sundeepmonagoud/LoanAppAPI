using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApp.WebAPI.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLoanDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoanNumber = table.Column<long>(nullable: false),
                    LoanId = table.Column<long>(nullable: false),
                    Balance = table.Column<decimal>(nullable: true),
                    Interest = table.Column<decimal>(nullable: true),
                    EarlyRePaymentFee = table.Column<decimal>(nullable: true),
                    PayoutAmount = table.Column<decimal>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LoanDetailsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLoanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerLoanDetails_LoanDetails_LoanDetailsId",
                        column: x => x.LoanDetailsId,
                        principalTable: "LoanDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLoanDetails_LoanDetailsId",
                table: "CustomerLoanDetails",
                column: "LoanDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLoanDetails");

            migrationBuilder.DropTable(
                name: "LoanDetails");
        }
    }
}
