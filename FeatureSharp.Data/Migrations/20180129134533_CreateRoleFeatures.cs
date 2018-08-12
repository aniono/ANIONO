using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FeatureSharp.Data.Migrations
{
    public partial class CreateRoleFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleFeatures",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    FeatureID = table.Column<Guid>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFeatures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleFeatures_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFeatures_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeatures_FeatureID",
                table: "RoleFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeatures_RoleID",
                table: "RoleFeatures",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleFeatures");
        }
    }
}
