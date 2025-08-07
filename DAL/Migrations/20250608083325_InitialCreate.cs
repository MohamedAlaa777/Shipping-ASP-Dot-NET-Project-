using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbCarriers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        CarrierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbCarriers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbCountries",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        CountryAName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        CountryEName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbCountries", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbPaymentMethods",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        MethdAName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        MethodEName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        Commission = table.Column<double>(type: "float", nullable: true),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbPaymentMethods", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbSetting",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        KiloMeterRate = table.Column<double>(type: "float", nullable: true),
            //        KilooGramRate = table.Column<double>(type: "float", nullable: true),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbSetting", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbShippingTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        ShippingTypeAName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        ShippingTypeEName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        ShippingFactor = table.Column<double>(type: "float", nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbShippingTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbSubscriptionPackages",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        PackageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        ShippimentCount = table.Column<int>(type: "int", nullable: false),
            //        NumberOfKiloMeters = table.Column<double>(type: "float", nullable: false),
            //        TotalWeight = table.Column<double>(type: "float", nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbSubscriptionPackages", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbCities",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        CityAName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        CityEName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbCities", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbCities_TbCountries",
            //            column: x => x.CountryId,
            //            principalTable: "TbCountries",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbUserSubscriptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SubscriptionDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbUserSubscriptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbUserSubscriptions_TbSubscriptionPackages",
            //            column: x => x.PackageId,
            //            principalTable: "TbSubscriptionPackages",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbUserReceivers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ReceiverName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbUserReceivers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbUserReceivers_TbCities",
            //            column: x => x.CityId,
            //            principalTable: "TbCities",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbUserSebders",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SenderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbUserSebders", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbUserSebders_TbCities",
            //            column: x => x.CityId,
            //            principalTable: "TbCities",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbShippments",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        ShippingDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ShippingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Width = table.Column<double>(type: "float", nullable: false),
            //        Height = table.Column<double>(type: "float", nullable: false),
            //        Weight = table.Column<double>(type: "float", nullable: false),
            //        Length = table.Column<double>(type: "float", nullable: false),
            //        PackageValue = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
            //        ShippingRate = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
            //        PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        UserSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        TrackingNumber = table.Column<double>(type: "float", nullable: true),
            //        ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbShippments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbShippments_TbPaymentMethods",
            //            column: x => x.PaymentMethodId,
            //            principalTable: "TbPaymentMethods",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TbShippments_TbShippingTypes",
            //            column: x => x.ShippingTypeId,
            //            principalTable: "TbShippingTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TbShippments_TbUserReceivers",
            //            column: x => x.ReceiverId,
            //            principalTable: "TbUserReceivers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TbShippments_TbUserSebders",
            //            column: x => x.SenderId,
            //            principalTable: "TbUserSebders",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TbShippmentStatus",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
            //        ShippmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        CurrentState = table.Column<int>(type: "int", nullable: false),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TbShippmentStatus", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TbShippmentStatus_TbCarriers",
            //            column: x => x.CarrierId,
            //            principalTable: "TbCarriers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_TbShippmentStatus_TbShippments",
            //            column: x => x.ShippmentId,
            //            principalTable: "TbShippments",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbCities_CountryId",
            //    table: "TbCities",
            //    column: "CountryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippments_PaymentMethodId",
            //    table: "TbShippments",
            //    column: "PaymentMethodId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippments_ReceiverId",
            //    table: "TbShippments",
            //    column: "ReceiverId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippments_SenderId",
            //    table: "TbShippments",
            //    column: "SenderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippments_ShippingTypeId",
            //    table: "TbShippments",
            //    column: "ShippingTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippmentStatus_CarrierId",
            //    table: "TbShippmentStatus",
            //    column: "CarrierId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbShippmentStatus_ShippmentId",
            //    table: "TbShippmentStatus",
            //    column: "ShippmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbUserReceivers_CityId",
            //    table: "TbUserReceivers",
            //    column: "CityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbUserSebders_CityId",
            //    table: "TbUserSebders",
            //    column: "CityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TbUserSubscriptions_PackageId",
            //    table: "TbUserSubscriptions",
            //    column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TbSetting");

            migrationBuilder.DropTable(
                name: "TbShippmentStatus");

            migrationBuilder.DropTable(
                name: "TbUserSubscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TbCarriers");

            migrationBuilder.DropTable(
                name: "TbShippments");

            migrationBuilder.DropTable(
                name: "TbSubscriptionPackages");

            migrationBuilder.DropTable(
                name: "TbPaymentMethods");

            migrationBuilder.DropTable(
                name: "TbShippingTypes");

            migrationBuilder.DropTable(
                name: "TbUserReceivers");

            migrationBuilder.DropTable(
                name: "TbUserSebders");

            migrationBuilder.DropTable(
                name: "TbCities");

            migrationBuilder.DropTable(
                name: "TbCountries");
        }
    }
}
