using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDB.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "CuentaCliente",
                columns: table => new
                {
                    CuentaClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCuenta = table.Column<int>(type: "int", nullable: false),
                    Clabe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCliente", x => x.CuentaClienteId);
                    table.ForeignKey(
                        name: "FK_CuentaCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoTarjeta = table.Column<int>(type: "int", nullable: false),
                    EstatusTarjeta = table.Column<int>(type: "int", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesVigencia = table.Column<int>(type: "int", nullable: false),
                    AnualidaVigencia = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CuentaClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_Tarjeta_CuentaCliente_CuentaClienteId",
                        column: x => x.CuentaClienteId,
                        principalTable: "CuentaCliente",
                        principalColumn: "CuentaClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaPrestamo",
                columns: table => new
                {
                    PrestamoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MontoPrestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstatusPrestamo = table.Column<int>(type: "int", nullable: false),
                    FechaLiquidar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaPrestamo", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_TarjetaPrestamo_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransaccionPago",
                columns: table => new
                {
                    TransaccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstatusTarjeta = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarjetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionPago", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_TransaccionPago_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCliente_ClienteId",
                table: "CuentaCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_CuentaClienteId",
                table: "Tarjeta",
                column: "CuentaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaPrestamo_TarjetaId",
                table: "TarjetaPrestamo",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionPago_TarjetaId",
                table: "TransaccionPago",
                column: "TarjetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarjetaPrestamo");

            migrationBuilder.DropTable(
                name: "TransaccionPago");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "CuentaCliente");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
