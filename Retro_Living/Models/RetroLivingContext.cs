using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Retro_Living.Models;

namespace Retro_Living.Models
{
    public class RetroLivingContext: DbContext
    {

        public RetroLivingContext(DbContextOptions<RetroLivingContext> options) : base(options)
        {
            Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Book>()
         .HasKey(t => new { t.p_id, t.b_id, t.user_id });

            modelBuilder.Entity<User_Book>()
            .HasOne(pt => pt.user)
            .WithMany(p => p.user_book)
            .HasForeignKey(pt => pt.user_id);

            modelBuilder.Entity<User_Book>()
                .HasOne(pt => pt.pay)
                .WithMany(t => t.user_book)
                .HasForeignKey(pt => pt.p_id);

            modelBuilder.Entity<User_Book>()
                .HasOne(pt => pt.book)
                .WithMany(t => t.user_book)
                .HasForeignKey(pt => pt.b_id);


            modelBuilder.Entity<Invoice>()
           .HasOne(s => s.user)
           .WithMany(g => g.user_invoice);

            modelBuilder.Entity<Invoice>()
            .HasOne(s => s.pay)
            .WithMany(g => g.pay_invoice);

            modelBuilder.Entity<Invoice>()
           .HasOne(s => s.book)
           .WithMany(g => g.book_invoice);


            modelBuilder.Entity<Room>()
           .HasOne(s => s.Book)
           .WithMany(g => g.room);

            modelBuilder.Entity<Hotel_Room>()
          .HasKey(t => new { t.room_id, t.h_id });

            modelBuilder.Entity<Hotel_Room>()
            .HasOne(pt => pt.room)
            .WithMany(p => p.hotel_room)
            .HasForeignKey(pt => pt.room_id);

            modelBuilder.Entity<Hotel_Room>()
            .HasOne(pt => pt.hotel)
            .WithMany(p => p.hotel_room)
            .HasForeignKey(pt => pt.h_id);


            modelBuilder.Entity<User_Hotel>()
           .HasKey(t => new { t.user_id, t.h_id });

            modelBuilder.Entity<User_Hotel>()
            .HasOne(pt => pt.user)
            .WithMany(p => p.user_hotels)
            .HasForeignKey(pt => pt.user_id);

            modelBuilder.Entity<User_Hotel>()
           .HasOne(pt => pt.hotel)
           .WithMany(t => t.user_hotels)
           .HasForeignKey(pt => pt.h_id);
        }

        public DbSet<Retro_Living.Models.User> User { get; set; }

        public DbSet<Retro_Living.Models.Hotel> Hotel { get; set; }

        public DbSet<Retro_Living.Models.User_Hotel> User_Hotel { get; set; }

        public DbSet<Retro_Living.Models.Room> Room { get; set; }

        public DbSet<Retro_Living.Models.Hotel_Room> hotel_rooms { get; set; }

        public DbSet<Retro_Living.Models.Book> Book { get; set; }

        public DbSet<Retro_Living.Models.Invoice> Invoice { get; set; }

        public DbSet<Retro_Living.Models.Payment> Payment { get; set; }

    }
}
