using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noberto.mealControl.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_addresses",
                columns: table => new
                {
                    id_address = table.Column<Guid>(type: "uuid", nullable: false),
                    zip_code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    area = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    complement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_addresses", x => x.id_address);
                });

            migrationBuilder.CreateTable(
                name: "tb_workers",
                columns: table => new
                {
                    id_worker = table.Column<Guid>(type: "uuid", nullable: false),
                    registration = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    active_profile = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_workers", x => x.id_worker);
                });

            migrationBuilder.CreateTable(
                name: "tb_administrators",
                columns: table => new
                {
                    id_administrator = table.Column<Guid>(type: "uuid", nullable: false),
                    registration = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    active_profile = table.Column<bool>(type: "boolean", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_administrators", x => x.id_administrator);
                    table.ForeignKey(
                        name: "FK_tb_administrators_tb_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "tb_addresses",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_managers",
                columns: table => new
                {
                    id_manager = table.Column<Guid>(type: "uuid", nullable: false),
                    registration = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    active_profile = table.Column<bool>(type: "boolean", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_managers", x => x.id_manager);
                    table.ForeignKey(
                        name: "FK_tb_managers_tb_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tb_addresses",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_schedule_events",
                columns: table => new
                {
                    id_team = table.Column<Guid>(type: "uuid", nullable: false),
                    meal_date = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    atypical = table.Column<bool>(type: "boolean", nullable: false),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_schedule_events", x => x.id_team);
                    table.ForeignKey(
                        name: "FK_tb_schedule_events_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_works",
                columns: table => new
                {
                    id_work = table.Column<Guid>(type: "uuid", nullable: false),
                    identification = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    closing_date = table.Column<DateOnly>(type: "date", nullable: true),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_works", x => x.id_work);
                    table.ForeignKey(
                        name: "FK_tb_works_tb_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "tb_addresses",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_works_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_schedule_local_events",
                columns: table => new
                {
                    id_schedule_event = table.Column<Guid>(type: "uuid", nullable: false),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    work_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_schedule_local_event", x => x.id_schedule_event);
                    table.ForeignKey(
                        name: "FK_tb_schedule_local_events_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_schedule_local_events_tb_schedule_events_schedule_event_~",
                        column: x => x.schedule_event_id,
                        principalTable: "tb_schedule_events",
                        principalColumn: "id_team",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_schedule_local_events_tb_works_work_id",
                        column: x => x.work_id,
                        principalTable: "tb_works",
                        principalColumn: "id_work",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_team_management",
                columns: table => new
                {
                    id_teamManagement = table.Column<Guid>(type: "uuid", nullable: false),
                    sector = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    active_team = table.Column<bool>(type: "boolean", nullable: false),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manager_id = table.Column<Guid>(type: "uuid", nullable: false),
                    work_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_team_management", x => x.id_teamManagement);
                    table.ForeignKey(
                        name: "FK_tb_team_management_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_team_management_tb_managers_manager_id",
                        column: x => x.manager_id,
                        principalTable: "tb_managers",
                        principalColumn: "id_manager",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_team_management_tb_works_work_id",
                        column: x => x.work_id,
                        principalTable: "tb_works",
                        principalColumn: "id_work",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_teams",
                columns: table => new
                {
                    id_team = table.Column<Guid>(type: "uuid", nullable: false),
                    active_team = table.Column<bool>(type: "boolean", nullable: false),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manage_team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    worker_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_teams", x => x.id_team);
                    table.ForeignKey(
                        name: "FK_tb_teams_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_teams_tb_team_management_manage_team_id",
                        column: x => x.manage_team_id,
                        principalTable: "tb_team_management",
                        principalColumn: "id_teamManagement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_teams_tb_workers_worker_id",
                        column: x => x.worker_id,
                        principalTable: "tb_workers",
                        principalColumn: "id_worker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_meals",
                columns: table => new
                {
                    id_meal = table.Column<Guid>(type: "uuid", nullable: false),
                    coffe = table.Column<bool>(type: "boolean", nullable: false),
                    lunch = table.Column<bool>(type: "boolean", nullable: false),
                    dinner = table.Column<bool>(type: "boolean", nullable: false),
                    administrator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_local_event_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_meal", x => x.id_meal);
                    table.ForeignKey(
                        name: "FK_tb_meals_tb_administrators_administrator_id",
                        column: x => x.administrator_id,
                        principalTable: "tb_administrators",
                        principalColumn: "id_administrator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_meals_tb_schedule_local_events_schedule_local_event_id",
                        column: x => x.schedule_local_event_id,
                        principalTable: "tb_schedule_local_events",
                        principalColumn: "id_schedule_event",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_meals_tb_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "tb_teams",
                        principalColumn: "id_team",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_administrators_address_id",
                table: "tb_administrators",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_administrators_email",
                table: "tb_administrators",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_administrators_registration",
                table: "tb_administrators",
                column: "registration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_managers_AddressId",
                table: "tb_managers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_managers_email",
                table: "tb_managers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_managers_registration",
                table: "tb_managers",
                column: "registration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_meals_administrator_id",
                table: "tb_meals",
                column: "administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_meals_schedule_local_event_id",
                table: "tb_meals",
                column: "schedule_local_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_meals_team_id",
                table: "tb_meals",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_events_administrator_id",
                table: "tb_schedule_events",
                column: "administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_local_events_administrator_id",
                table: "tb_schedule_local_events",
                column: "administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_local_events_schedule_event_id",
                table: "tb_schedule_local_events",
                column: "schedule_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_local_events_work_id",
                table: "tb_schedule_local_events",
                column: "work_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_team_management_administrator_id",
                table: "tb_team_management",
                column: "administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_team_management_manager_id",
                table: "tb_team_management",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_team_management_work_id",
                table: "tb_team_management",
                column: "work_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_teams_administrator_id",
                table: "tb_teams",
                column: "administrator_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_teams_manage_team_id",
                table: "tb_teams",
                column: "manage_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_teams_worker_id",
                table: "tb_teams",
                column: "worker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_works_address_id",
                table: "tb_works",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_works_administrator_id",
                table: "tb_works",
                column: "administrator_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_meals");

            migrationBuilder.DropTable(
                name: "tb_schedule_local_events");

            migrationBuilder.DropTable(
                name: "tb_teams");

            migrationBuilder.DropTable(
                name: "tb_schedule_events");

            migrationBuilder.DropTable(
                name: "tb_team_management");

            migrationBuilder.DropTable(
                name: "tb_workers");

            migrationBuilder.DropTable(
                name: "tb_managers");

            migrationBuilder.DropTable(
                name: "tb_works");

            migrationBuilder.DropTable(
                name: "tb_administrators");

            migrationBuilder.DropTable(
                name: "tb_addresses");
        }
    }
}
