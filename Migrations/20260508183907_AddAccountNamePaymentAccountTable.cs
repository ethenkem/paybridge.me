using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayBridge.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountNamePaymentAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "account_name",
                table: "payment_accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "account_name",
                table: "payment_accounts");
        }
    }
}
