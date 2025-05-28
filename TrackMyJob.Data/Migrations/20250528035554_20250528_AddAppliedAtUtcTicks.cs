using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20250528_AddAppliedAtUtcTicks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AppliedAtUtcTicks",
                table: "JobApplications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedAtUtcTicks",
                table: "JobApplications");
        }
    }
}
