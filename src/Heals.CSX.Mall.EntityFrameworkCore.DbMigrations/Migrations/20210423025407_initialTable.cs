using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Heals.CSX.Mall.Migrations
{
    public partial class initialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ClinicCode = table.Column<string>(maxLength: 32, nullable: false),
                    ClinicName = table.Column<string>(maxLength: 64, nullable: false),
                    Contacts = table.Column<string>(maxLength: 32, nullable: false),
                    Phone = table.Column<string>(maxLength: 16, nullable: false),
                    CustomerName = table.Column<string>(maxLength: 32, nullable: false),
                    CustomerAccount = table.Column<string>(maxLength: 32, nullable: false),
                    Remarks = table.Column<string>(maxLength: 1024, nullable: false),
                    HealsRemarks = table.Column<string>(maxLength: 1024, nullable: false),
                    Street = table.Column<string>(maxLength: 64, nullable: false),
                    City = table.Column<string>(maxLength: 32, nullable: false),
                    State = table.Column<string>(maxLength: 32, nullable: false),
                    Country = table.Column<string>(maxLength: 32, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    ApplicationName = table.Column<string>(maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(maxLength: 4000, nullable: true),
                    Comments = table.Column<string>(maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_BackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    JobName = table.Column<string>(maxLength: 128, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false, defaultValue: (short)0),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false, defaultValue: false),
                    Priority = table.Column<byte>(nullable: false, defaultValue: (byte)15)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_BackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_ProductItemOrdereds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductSeqId = table.Column<string>(maxLength: 16, nullable: false),
                    ProductName = table.Column<string>(maxLength: 256, nullable: false),
                    PictureUri = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_ProductItemOrdereds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ClinicId = table.Column<Guid>(nullable: true),
                    ClinicCode = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ProductID = table.Column<string>(maxLength: 16, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: false),
                    PictureUri = table.Column<string>(maxLength: 256, nullable: false),
                    Specification = table.Column<string>(maxLength: 512, nullable: false),
                    SupplierName = table.Column<string>(maxLength: 64, nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    SRP = table.Column<decimal>(nullable: false),
                    Color = table.Column<string>(maxLength: 32, nullable: false),
                    StockLevel = table.Column<int>(nullable: false),
                    Bundled = table.Column<bool>(nullable: false),
                    CatalogTypeId = table.Column<short>(nullable: false),
                    CatalogBrand = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderNo = table.Column<string>(maxLength: 32, nullable: false),
                    BuyerId = table.Column<Guid>(nullable: false),
                    ShipToAddressId = table.Column<Guid>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    TargetDeliveryDate = table.Column<DateTimeOffset>(nullable: true),
                    ActualDeliveryDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_Orders_M_Addresses_ShipToAddressId",
                        column: x => x.ShipToAddressId,
                        principalTable: "M_Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_AuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_AuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_AuditLogActions_M_AuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "M_AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_EntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityTenantId = table.Column<Guid>(nullable: true),
                    EntityId = table.Column<string>(maxLength: 128, nullable: false),
                    EntityTypeFullName = table.Column<string>(maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_EntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_EntityChanges_M_AuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "M_AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ItemOrderedId = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_OrderItems_M_ProductItemOrdereds_ItemOrderedId",
                        column: x => x.ItemOrderedId,
                        principalTable: "M_ProductItemOrdereds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_M_OrderItems_M_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "M_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "M_EntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    EntityChangeId = table.Column<Guid>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_EntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_M_EntityPropertyChanges_M_EntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "M_EntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_AuditLogActions_AuditLogId",
                table: "M_AuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_M_AuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime",
                table: "M_AuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_M_AuditLogs_TenantId_ExecutionTime",
                table: "M_AuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_M_AuditLogs_TenantId_UserId_ExecutionTime",
                table: "M_AuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_M_BackgroundJobs_IsAbandoned_NextTryTime",
                table: "M_BackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_M_EntityChanges_AuditLogId",
                table: "M_EntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_M_EntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "M_EntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_M_EntityPropertyChanges_EntityChangeId",
                table: "M_EntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_M_OrderItems_ItemOrderedId",
                table: "M_OrderItems",
                column: "ItemOrderedId");

            migrationBuilder.CreateIndex(
                name: "IX_M_OrderItems_OrderId",
                table: "M_OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Orders_ShipToAddressId",
                table: "M_Orders",
                column: "ShipToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_M_Settings_Name_ProviderName_ProviderKey",
                table: "M_Settings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_AuditLogActions");

            migrationBuilder.DropTable(
                name: "M_BackgroundJobs");

            migrationBuilder.DropTable(
                name: "M_EntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "M_OrderItems");

            migrationBuilder.DropTable(
                name: "M_Products");

            migrationBuilder.DropTable(
                name: "M_Settings");

            migrationBuilder.DropTable(
                name: "M_EntityChanges");

            migrationBuilder.DropTable(
                name: "M_ProductItemOrdereds");

            migrationBuilder.DropTable(
                name: "M_Orders");

            migrationBuilder.DropTable(
                name: "M_AuditLogs");

            migrationBuilder.DropTable(
                name: "M_Addresses");
        }
    }
}
