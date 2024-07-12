using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noberto.mealControl.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableScheduleLocalEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_schedule_local_events_tb_administrators_administrator_id",
                table: "tb_schedule_local_events");

            migrationBuilder.AlterColumn<Guid>(
                name: "administrator_id",
                table: "tb_schedule_local_events",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_schedule_local_events_tb_administrators_administrator_id",
                table: "tb_schedule_local_events",
                column: "administrator_id",
                principalTable: "tb_administrators",
                principalColumn: "id_administrator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_schedule_local_events_tb_administrators_administrator_id",
                table: "tb_schedule_local_events");

            migrationBuilder.AlterColumn<Guid>(
                name: "administrator_id",
                table: "tb_schedule_local_events",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_schedule_local_events_tb_administrators_administrator_id",
                table: "tb_schedule_local_events",
                column: "administrator_id",
                principalTable: "tb_administrators",
                principalColumn: "id_administrator",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
