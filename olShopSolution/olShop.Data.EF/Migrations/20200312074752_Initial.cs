using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace olShop.Data.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertistmentPages",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertistmentPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SeoPageTitle = table.Column<string>(maxLength: 256, nullable: true),
                    SeoAlias = table.Column<string>(maxLength: 256, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Website = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Other = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    URL = table.Column<string>(maxLength: 250, nullable: false),
                    ParentId = table.Column<string>(maxLength: 128, nullable: true),
                    IconCss = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Resources = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 255, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    HomeOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    GroupAlias = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value1 = table.Column<string>(nullable: true),
                    Value2 = table.Column<int>(nullable: true),
                    Value3 = table.Column<bool>(nullable: true),
                    Value4 = table.Column<DateTime>(nullable: true),
                    Value5 = table.Column<decimal>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertistmentPositions",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    PageId = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertistmentPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertistmentPositions_AdvertistmentPages_PageId",
                        column: x => x.PageId,
                        principalTable: "AdvertistmentPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Content = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerAddress = table.Column<string>(maxLength: 256, nullable: false),
                    CustomerMobile = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerMessage = table.Column<string>(maxLength: 256, nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    BillStatus = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    CustomerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AppUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    FunctionId = table.Column<string>(maxLength: 128, nullable: false),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanRead = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    PromotionPrice = table.Column<decimal>(nullable: true),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: true),
                    HotFlag = table.Column<bool>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    Tags = table.Column<string>(maxLength: 256, nullable: true),
                    Unit = table.Column<string>(maxLength: 256, nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(maxLength: 256, nullable: true),
                    SeoKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    SeoDescription = table.Column<string>(maxLength: 256, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(nullable: false),
                    TagId = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertistments",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    PositionId = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertistments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertistments_AdvertistmentPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "AdvertistmentPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementUsers",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<string>(maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    HasRead = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementUsers_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 250, nullable: true),
                    Caption = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuantities_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuantities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuantities_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    TagId = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholePrices",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    FromQuantity = table.Column<int>(nullable: false),
                    ToQuantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WholePrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvertistmentPages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "home", "Home" },
                    { "product-cate", "Product category" },
                    { "product-detail", "Product detail" }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("af186d00-6d93-4721-ac73-46a8d968c8ed"), "9b164ca9-e990-4343-a3d2-5d3ac848f716", "Top manager", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("af186d00-6d93-4721-ac73-46a8d968c8ed"), new Guid("a389bfc2-ed92-4fb5-8705-fd0cb5b48b48") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "Birthday", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a389bfc2-ed92-4fb5-8705-fd0cb5b48b48"), 0, null, 0m, new DateTime(1993, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "15e58982-fc32-4a0c-b800-d72594c5d66d", new DateTime(2020, 3, 12, 14, 47, 50, 906, DateTimeKind.Local).AddTicks(9823), new DateTime(2020, 3, 12, 14, 47, 50, 907, DateTimeKind.Local).AddTicks(9824), "prohotvulcan@gmail.com", true, "Administrator", false, null, "prohotvulcan@gmail.com", null, "AQAAAAEAACcQAAAAEA1mSwcp7AdxIMy9gwquiihbrgA50CVFrwUwWgfNuuHtK2sgjhXtqgUiY3A8bj0xUA==", null, false, null, 1, false, "admin" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "#000000", "Black" },
                    { 2, "#FFFFFF", "White" },
                    { 3, "#ff0000", "Red" },
                    { 4, "#1000ff", "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "Lat", "Lng", "Name", "Other", "Phone", "Status", "Website" },
                values: new object[] { "DefaultContactId", "Mau Than - Xuan Khanh - Ninh Kieu - Can Tho", "onlineshop@gmail.com", 10.028727399999999, 105.7763564, "Online Shop", null, "0961 313 760", 1, "http://www.thoitranganhduc.com/" });

            migrationBuilder.InsertData(
                table: "Footers",
                columns: new[] { "Id", "Content" },
                values: new object[] { "DefaultFooterId", "Footer" });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "IconCss", "Name", "ParentId", "SortOrder", "Status", "URL" },
                values: new object[,]
                {
                    { "READER", "fa-bar-chart-o", "Reader Report", "REPORT", 3, 1, "/admin/report/reader" },
                    { "ACCESS", "fa-bar-chart-o", "Visitor Report", "REPORT", 2, 1, "/admin/report/visitor" },
                    { "REVENUES", "fa-bar-chart-o", "Revenue report", "REPORT", 1, 1, "/admin/report/revenues" },
                    { "REPORT", "fa-bar-chart-o", "Report", null, 5, 1, "/" },
                    { "ADVERTISMENT", "fa-clone", "Advertisment", "UTILITY", 6, 1, "/admin/advertistment/index" },
                    { "CONTACT", "fa-clone", "Contact", "UTILITY", 4, 1, "/admin/contact/index" },
                    { "ANNOUNCEMENT", "fa-clone", "Announcement", "UTILITY", 3, 1, "/admin/announcement/index" },
                    { "FEEDBACK", "fa-clone", "Feedback", "UTILITY", 2, 1, "/admin/feedback/index" },
                    { "FOOTER", "fa-clone", "Footer", "UTILITY", 1, 1, "/admin/footer/index" },
                    { "UTILITY", "fa-clone", "Utilities", null, 4, 1, "/" },
                    { "PAGE", "fa-table", "Page", "CONTENT", 2, 1, "/admin/page/index" },
                    { "BLOG", "fa-table", "Blog", "CONTENT", 1, 1, "/admin/blog/index" },
                    { "SLIDE", "fa-clone", "Slide", "UTILITY", 5, 1, "/admin/slide/index" },
                    { "BILL", "fa-chevron-down", "Bill", "PRODUCT", 3, 1, "/admin/bill/index" },
                    { "SYSTEM", "fa-desktop", "System", null, 1, 1, "/" },
                    { "ROLE", "fa-home", "Role", "SYSTEM", 1, 1, "/admin/role/index" },
                    { "FUNCTION", "fa-home", "Function", "SYSTEM", 2, 1, "/admin/function/index" },
                    { "ACTIVITY", "fa-home", "Activity", "SYSTEM", 4, 1, "/admin/activity/index" },
                    { "USER", "fa-home", "User", "SYSTEM", 3, 1, "/admin/user/index" },
                    { "SETTING", "fa-home", "Configuration", "SYSTEM", 6, 1, "/admin/setting/index" },
                    { "PRODUCT", "fa-chevron-down", "Product Management", null, 2, 1, "/" },
                    { "PRODUCT_CATEGORY", "fa-chevron-down", "Category", "PRODUCT", 1, 1, "/admin/productcategory/index" },
                    { "PRODUCT_LIST", "fa-chevron-down", "Product", "PRODUCT", 2, 1, "/admin/product/index" },
                    { "ERROR", "fa-home", "Error", "SYSTEM", 5, 1, "/admin/error/index" },
                    { "CONTENT", "fa-table", "Content", null, 3, 1, "/" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "HomeFlag", "HomeOrder", "Image", "Name", "ParentId", "SeoAlias", "SeoDescription", "SeoKeywords", "SeoPageTitle", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Men shirt", null, "men-shirt", null, null, null, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Women shirt", null, "women-shirt", null, null, null, 2, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Men shoes", null, "men-shoes", null, null, null, 3, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Woment shoes", null, "women-shoes", null, null, null, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "XS" },
                    { 5, "S" },
                    { 4, "M" },
                    { 2, "XL" },
                    { 1, "XXL" },
                    { 3, "L" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Content", "Description", "DisplayOrder", "GroupAlias", "Image", "Name", "Status", "Url" },
                values: new object[,]
                {
                    { 14, null, null, 11, "brand", "/client-side/images/brand11.png", "Slide 11", true, "#" },
                    { 13, null, null, 10, "brand", "/client-side/images/brand10.png", "Slide 10", true, "#" },
                    { 12, null, null, 9, "brand", "/client-side/images/brand9.png", "Slide 9", true, "#" },
                    { 11, null, null, 8, "brand", "/client-side/images/brand8.png", "Slide 8", true, "#" },
                    { 10, null, null, 7, "brand", "/client-side/images/brand7.png", "Slide 7", true, "#" },
                    { 9, null, null, 6, "brand", "/client-side/images/brand6.png", "Slide 6", true, "#" },
                    { 8, null, null, 5, "brand", "/client-side/images/brand5.png", "Slide 5", true, "#" },
                    { 7, null, null, 4, "brand", "/client-side/images/brand4.png", "Slide 4", true, "#" },
                    { 5, null, null, 2, "brand", "/client-side/images/brand2.png", "Slide 2", true, "#" },
                    { 4, null, null, 1, "brand", "/client-side/images/brand1.png", "Slide 1", true, "#" },
                    { 3, null, null, 2, "top", "/client-side/images/slider/slide-3.jpg", "Slide 3", true, "#" },
                    { 2, null, null, 1, "top", "/client-side/images/slider/slide-2.jpg", "Slide 2", true, "#" },
                    { 1, null, null, 0, "top", "/client-side/images/slider/slide-1.jpg", "Slide 1", true, "#" },
                    { 6, null, null, 3, "brand", "/client-side/images/brand3.png", "Slide 3", true, "#" }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "Name", "Status", "Value1", "Value2", "Value3", "Value4", "Value5" },
                values: new object[,]
                {
                    { "HomeMetaKeyword", "Home Keyword", 1, "shopping, sales", null, null, null, null },
                    { "HomeTitle", "Home's title", 1, "Online Shop home", null, null, null, null },
                    { "HomeMetaDescription", "Home Description", 1, "Home", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AdvertistmentPositions",
                columns: new[] { "Id", "Name", "PageId" },
                values: new object[,]
                {
                    { "home-left", "Bên trái", "home" },
                    { "product-cate-left", "Bên trái", "product-cate" },
                    { "product-detail-left", "Bên trái", "product-detail" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Content", "DateCreated", "DateModified", "Description", "HomeFlag", "HotFlag", "Image", "Name", "OriginalPrice", "Price", "PromotionPrice", "SeoAlias", "SeoDescription", "SeoKeywords", "SeoPageTitle", "Status", "Tags", "Unit", "ViewCount" },
                values: new object[,]
                {
                    { 18, 4, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 18", 1000m, 1000m, null, "san-pham-18", null, null, null, 1, null, null, null },
                    { 17, 4, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 17", 1000m, 1000m, null, "san-pham-17", null, null, null, 1, null, null, null },
                    { 16, 4, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 16", 1000m, 1000m, null, "san-pham-16", null, null, null, 1, null, null, null },
                    { 15, 3, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 15", 1000m, 1000m, null, "san-pham-15", null, null, null, 1, null, null, null },
                    { 14, 3, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 14", 1000m, 1000m, null, "san-pham-14", null, null, null, 1, null, null, null },
                    { 13, 3, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 13", 1000m, 1000m, null, "san-pham-13", null, null, null, 1, null, null, null },
                    { 12, 3, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 12", 1000m, 1000m, null, "san-pham-12", null, null, null, 1, null, null, null },
                    { 11, 3, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 11", 1000m, 1000m, null, "san-pham-11", null, null, null, 1, null, null, null },
                    { 10, 2, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 10", 1000m, 1000m, null, "san-pham-10", null, null, null, 1, null, null, null },
                    { 9, 2, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 9", 1000m, 1000m, null, "san-pham-9", null, null, null, 1, null, null, null },
                    { 8, 2, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 8", 1000m, 1000m, null, "san-pham-8", null, null, null, 1, null, null, null },
                    { 7, 2, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 7", 1000m, 1000m, null, "san-pham-7", null, null, null, 1, null, null, null },
                    { 6, 2, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 6", 1000m, 1000m, null, "san-pham-6", null, null, null, 1, null, null, null },
                    { 5, 1, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 5", 1000m, 1000m, null, "san-pham-5", null, null, null, 1, null, null, null },
                    { 4, 1, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 4", 1000m, 1000m, null, "san-pham-4", null, null, null, 1, null, null, null },
                    { 3, 1, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 3", 1000m, 1000m, null, "san-pham-3", null, null, null, 1, null, null, null },
                    { 2, 1, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 2", 1000m, 1000m, null, "san-pham-2", null, null, null, 1, null, null, null },
                    { 1, 1, null, new DateTime(2020, 3, 12, 14, 47, 50, 946, DateTimeKind.Local).AddTicks(9846), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 1", 1000m, 1000m, null, "san-pham-1", null, null, null, 1, null, null, null },
                    { 19, 4, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 19", 1000m, 1000m, null, "san-pham-19", null, null, null, 1, null, null, null },
                    { 20, 4, null, new DateTime(2020, 3, 12, 14, 47, 50, 947, DateTimeKind.Local).AddTicks(9847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Product 20", 1000m, 1000m, null, "san-pham-20", null, null, null, 1, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertistmentPositions_PageId",
                table: "AdvertistmentPositions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertistments_PositionId",
                table: "Advertistments",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserId",
                table: "Announcements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillId",
                table: "BillDetails",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ColorId",
                table: "BillDetails",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ProductId",
                table: "BillDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_SizeId",
                table: "BillDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_BlogId",
                table: "BlogTags",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_TagId",
                table: "BlogTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FunctionId",
                table: "Permissions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ColorId",
                table: "ProductQuantities",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_ProductId",
                table: "ProductQuantities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantities_SizeId",
                table: "ProductQuantities",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_ProductId",
                table: "ProductTags",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_WholePrices_ProductId",
                table: "WholePrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertistments");

            migrationBuilder.DropTable(
                name: "AnnouncementUsers");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductQuantities");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "WholePrices");

            migrationBuilder.DropTable(
                name: "AdvertistmentPositions");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AdvertistmentPages");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
