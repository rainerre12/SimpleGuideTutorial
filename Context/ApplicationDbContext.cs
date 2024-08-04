using Microsoft.EntityFrameworkCore;
using SimpleGuideTutorial.Model;

namespace SimpleGuideTutorial.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Topic entity
            modelBuilder.Entity<Topic>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Categories)
                .WithOne(c => c.topic)
                .HasForeignKey(c => c.TopicId);

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Descriptions)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId);

            // Configure Description entity
            modelBuilder.Entity<Description>()
             .HasKey(d => d.Id);

            modelBuilder.Entity<Description>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Description>()
                .HasOne(d => d.Image)
                .WithMany()
                .HasForeignKey(d => d.ImageId)
                .IsRequired(false); // Optional relationship to Image

            modelBuilder.Entity<Description>()
                .HasOne(d => d.Video)
                .WithMany()
                .HasForeignKey(d => d.VideoId)
                .IsRequired(false); // Optional relationship to Video

            // Configure Image entity
            modelBuilder.Entity<Image>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Description)
                .WithMany()
                .HasForeignKey(i => i.DescriptionId)
                .IsRequired(false); // Optional relationship to Description

            // Configure Video entity
            modelBuilder.Entity<Video>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Video>()
                .HasOne(v => v.Description)
                .WithMany()
                .HasForeignKey(v => v.DescriptionId)
                .IsRequired(false); // Optional relationship to Description
        }
    }
}
