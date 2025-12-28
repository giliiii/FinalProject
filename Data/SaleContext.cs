using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class SaleContext : DbContext

    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options) { }
        public DbSet<Basket> Basket => Set<Basket>();
        public DbSet<Card> Card => Set<Card>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Donor> Donor => Set<Donor>();
        public DbSet<Gift> Gift => Set<Gift>();
        public DbSet<Maneger> Manager => Set<Maneger>();
        public DbSet<User> User => Set<User>();
        public DbSet<Winner> Winner => Set<Winner>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Basket configuration
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.Id);

            });
            //Card configuration
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id);
          
            });
            //User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.CardsList)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(e => e.BasketsList)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);               
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);        
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(10);
                entity.Property(e => e.Adress).HasMaxLength(50);
                entity.HasIndex(e => e.Email).IsUnique();

            });
            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.GiftsList)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            //donor configuration
            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(20);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.GiftsList)
                    .WithOne(e => e.Donor)
                    .HasForeignKey(e => e.DonorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //Gift configuration
            modelBuilder.Entity<Gift>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Description).HasMaxLength(300);
                entity.Property(e => e.Cost).IsRequired().HasDefaultValue(30);
                entity.HasCheckConstraint("CK_Gift_Cost", "Cost >= 10 AND Cost <= 100");
                entity.Property(e => e.Picture).HasMaxLength(50);
                entity.Property(e => e.WinnerName).HasDefaultValue("").HasMaxLength(30);
                entity.HasMany(e => e.CardsList)
                    .WithOne(e => e.Gift)
                    .HasForeignKey(e => e.GiftId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            //Manager configuration
            modelBuilder.Entity <Maneger>(entity => {   
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(20);
            });
            //Winner configuration
            modelBuilder.Entity<Winner>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Gift)
                    .WithMany()
                    .HasForeignKey(e => e.GiftId)
                    .OnDelete(DeleteBehavior.Restrict);

            });


        }
    }
}
