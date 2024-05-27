using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; } //Represents our table name when table is created in db
        public DbSet<ActivityAttendee> ActivityAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityAttendee>(x => x.HasKey(y => new {y.AppUserId, y.ActivityId}));

            //This is our configuration for many to many relationship.
            builder.Entity<ActivityAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(v => v.Activities)
                .HasForeignKey(y => y.AppUserId);

             builder.Entity<ActivityAttendee>()
                .HasOne(u => u.Activity)
                .WithMany(v => v.Attendees)
                .HasForeignKey(y => y.ActivityId);
        }
    }
}