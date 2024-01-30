using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalEquipmentSupplySystem.DataAccess.Migrations
{
    public partial class AddRowVersionToEquipmentReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EquipmentReservation",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EquipmentReservation");
        }
    }
}
