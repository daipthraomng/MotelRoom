using Microsoft.EntityFrameworkCore;
using MotelRoom.Entity;
using MotelRoom.Entity.AddressEntity;
using MotelRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<ImageRoom> ImageRooms { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<District>().ToTable("District");
            modelBuilder.Entity<Street>().ToTable("Street");
            modelBuilder.Entity<Ward>().ToTable("Ward");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Message>().ToTable("Message");
        }
    }
}
