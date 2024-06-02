using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAO
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<BannerMember> BannerMember { get; set; }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<ImageDetail> ImageDetail { get; set; }
        public DbSet<MemberRegisterPackage> MemberRegisterPackage { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PaymentTransaction> PaymentTransaction { get; set; }
        public DbSet<PaymentTransactionDetail> PaymentTransactionDetail { get; set; }
        public DbSet<PlantCode> PlantCode { get; set; }
        public DbSet<PlantTracking> PlantTracking { get; set; }
        public DbSet<PostingNews> PostingNew { get; set; }
        public DbSet<PostingDetail> PostingDetail { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }


        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var strConn = config["ConnectionStrings:SQLClient"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BannerMember>()
                .HasKey(b => b.BannerID);

            modelBuilder.Entity<BannerMember>()
                .Property(b => b.BannerID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<Collaborator>()
               .HasKey(collaborator => collaborator.CollaboratorID);


            modelBuilder.Entity<ImageDetail>()
               .HasKey(img => img.ImageDetailID);

            modelBuilder.Entity<ImageDetail>()
                .Property(img => img.ImageDetailID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<MemberRegisterPackage>()
              .HasKey(m => m.MemberRegisterPackagenID);

            modelBuilder.Entity<MemberRegisterPackage>()
                .Property(m => m.MemberRegisterPackagenID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<Package>()
              .HasKey(p => p.PackageID);

            modelBuilder.Entity<Package>()
                .Property(p => p.PackageID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<PaymentTransaction>()
              .HasKey(p => p.TransactionID);

            modelBuilder.Entity<PaymentTransaction>()
                .Property(p => p.TransactionID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<PaymentTransactionDetail>()
              .HasKey(p => p.PaymentDetailID);

            modelBuilder.Entity<PaymentTransactionDetail>()
                .Property(p => p.PaymentDetailID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<PlantCode>()
              .HasKey(p => p.PlantCodeID);

            modelBuilder.Entity<PlantCode>()
                .Property(p => p.PlantCodeID)
                .IsRequired();

            modelBuilder.Entity<PlantTracking>()
              .HasKey(p => p.TrackingID);

            modelBuilder.Entity<PlantTracking>()
                .Property(p => p.TrackingID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<PostingNews>()
             .HasKey(p => p.NewsID);

            modelBuilder.Entity<PostingNews>()
                .Property(p => p.NewsID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<PostingDetail>()
               .HasKey(b => b.PostingDetailID);

            modelBuilder.Entity<PostingDetail>()
                .Property(b => b.PostingDetailID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<UserInformation>()
             .HasKey(u => u.AccountID);

            modelBuilder.Entity<UserInformation>()
                .Property(u => u.AccountID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); 


            //one collaborator have many banner
            modelBuilder.Entity<BannerMember>()
                .HasOne(b => b.Collaborator)
                .WithMany(a => a.BannerMembers)
                .HasForeignKey(a => a.MemberID)
                .OnDelete(DeleteBehavior.Restrict);

            // one collaborator have many membershipregister
            modelBuilder.Entity<MemberRegisterPackage>()
                .HasOne(membership => membership.Register)
                .WithMany(account => account.UserMemberRegistrations)
                .HasForeignKey(membership => membership.RegisterID)
                .OnDelete(DeleteBehavior.Restrict);

            // one package have many membershipregister
            modelBuilder.Entity<MemberRegisterPackage>()
               .HasOne(m => m.Package)
               .WithMany(m => m.RegisterPackages)
               .HasForeignKey(m => m.PackageID)
               .OnDelete(DeleteBehavior.Restrict);

            // one payment have many paymentTransactionDetail
            modelBuilder.Entity<PaymentTransactionDetail>()
               .HasOne(p => p.PaymentTransaction)
               .WithMany(p => p.PaymentTransactionDetails)
               .HasForeignKey(p => p.PaymentID)
               .OnDelete(DeleteBehavior.Restrict);

            // one detail have many plantcode
            modelBuilder.Entity<PlantCode>()
               .HasOne(p => p.PaymentTransactionDetail)
               .WithMany(p => p.PlantCodes)
               .HasForeignKey(p => p.PaymentTransactionDetailID)
               .OnDelete(DeleteBehavior.Restrict);

            //one plantcode have many planttracking
            modelBuilder.Entity<PlantTracking>()
                .HasOne(p => p.PlantCode)
                .WithMany(p => p.PlantTrackings)
                .HasForeignKey(p => p.PlantCodeID)
                .OnDelete(DeleteBehavior.Restrict);

            //one planttracking have many plant image detail
            modelBuilder.Entity<ImageDetail>()
               .HasOne(img => img.PlantTracking)
               .WithMany(p => p.PlantImageDetails)
               .HasForeignKey(t => t.TrackingID)
               .OnDelete(DeleteBehavior.Restrict);

            //one user have many payment
            modelBuilder.Entity<PaymentTransaction>()
               .HasOne(p => p.UserInformation)
               .WithMany(p => p.UserTransactions)
               .HasForeignKey(p => p.AccountID)
               .OnDelete(DeleteBehavior.Restrict);

            //one user have many plantcode
            modelBuilder.Entity<PlantCode>()
               .HasOne(p => p.UserInformation)
               .WithMany(p => p.UserPlants)
               .HasForeignKey(p => p.OwnerID)
               .OnDelete(DeleteBehavior.Restrict);

            // one user have many postingNews
            modelBuilder.Entity<PostingNews>()
                .HasOne(p => p.UserInformation)
                .WithMany(p => p.UserPostings)
                .HasForeignKey(p => p.OwnerCreateID)
                .OnDelete(DeleteBehavior.Restrict);

            //one posting have many detail
            modelBuilder.Entity<PostingDetail>()
               .HasOne(p => p.PostingNews)
               .WithMany(p => p.Details)
               .HasForeignKey(p => p.PostingNewsID)
               .OnDelete(DeleteBehavior.Restrict);

            // one user have one collaborator

            modelBuilder.Entity<UserInformation>()
                .HasOne(u => u.Collaborator)
                .WithOne(c => c.UserInformation)
                .HasForeignKey<Collaborator>(c => c.CollaboratorID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
