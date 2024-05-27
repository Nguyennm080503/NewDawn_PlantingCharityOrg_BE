using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageFee = table.Column<double>(type: "float", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageID);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantFee = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantID);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    CollaboratorID = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.CollaboratorID);
                    table.ForeignKey(
                        name: "FK_Collaborator_UserInformation_CollaboratorID",
                        column: x => x.CollaboratorID,
                        principalTable: "UserInformation",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantCode",
                columns: table => new
                {
                    PlantCodeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCode", x => x.PlantCodeID);
                    table.ForeignKey(
                        name: "FK_PlantCode_Plant_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plant",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantCode_UserInformation_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "UserInformation",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingNew",
                columns: table => new
                {
                    NewsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerCreateID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingNew", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_PostingNew_UserInformation_OwnerCreateID",
                        column: x => x.OwnerCreateID,
                        principalTable: "UserInformation",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BannerMember",
                columns: table => new
                {
                    BannerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerMember", x => x.BannerID);
                    table.ForeignKey(
                        name: "FK_BannerMember_Collaborator_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberRegisterPackage",
                columns: table => new
                {
                    MemberRegisterPackagenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageID = table.Column<int>(type: "int", nullable: true),
                    RegisterID = table.Column<int>(type: "int", nullable: true),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackageFee = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRegisterPackage", x => x.MemberRegisterPackagenID);
                    table.ForeignKey(
                        name: "FK_MemberRegisterPackage_Collaborator_RegisterID",
                        column: x => x.RegisterID,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberRegisterPackage_Package_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Package",
                        principalColumn: "PackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    PaymentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmout = table.Column<double>(type: "float", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Collaborator_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_UserInformation_AccountID",
                        column: x => x.AccountID,
                        principalTable: "UserInformation",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantTracking",
                columns: table => new
                {
                    TrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantCodeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTracking", x => x.TrackingID);
                    table.ForeignKey(
                        name: "FK_PlantTracking_PlantCode_PlantCodeID",
                        column: x => x.PlantCodeID,
                        principalTable: "PlantCode",
                        principalColumn: "PlantCodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactionDetail",
                columns: table => new
                {
                    PaymentDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactionDetail", x => x.PaymentDetailID);
                    table.ForeignKey(
                        name: "FK_PaymentTransactionDetail_PaymentTransaction_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "PaymentTransaction",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransactionDetail_Plant_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plant",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetail",
                columns: table => new
                {
                    ImageDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingID = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetail", x => x.ImageDetailID);
                    table.ForeignKey(
                        name: "FK_ImageDetail_PlantTracking_TrackingID",
                        column: x => x.TrackingID,
                        principalTable: "PlantTracking",
                        principalColumn: "TrackingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerMember_MemberID",
                table: "BannerMember",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetail_TrackingID",
                table: "ImageDetail",
                column: "TrackingID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRegisterPackage_PackageID",
                table: "MemberRegisterPackage",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRegisterPackage_RegisterID",
                table: "MemberRegisterPackage",
                column: "RegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_AccountID",
                table: "PaymentTransaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactionDetail_PaymentID",
                table: "PaymentTransactionDetail",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactionDetail_PlantID",
                table: "PaymentTransactionDetail",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantCode_OwnerID",
                table: "PlantCode",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantCode_PlantID",
                table: "PlantCode",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTracking_PlantCodeID",
                table: "PlantTracking",
                column: "PlantCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_PostingNew_OwnerCreateID",
                table: "PostingNew",
                column: "OwnerCreateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerMember");

            migrationBuilder.DropTable(
                name: "ImageDetail");

            migrationBuilder.DropTable(
                name: "MemberRegisterPackage");

            migrationBuilder.DropTable(
                name: "PaymentTransactionDetail");

            migrationBuilder.DropTable(
                name: "PostingNew");

            migrationBuilder.DropTable(
                name: "PlantTracking");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PaymentTransaction");

            migrationBuilder.DropTable(
                name: "PlantCode");

            migrationBuilder.DropTable(
                name: "Collaborator");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "UserInformation");
        }
    }
}
