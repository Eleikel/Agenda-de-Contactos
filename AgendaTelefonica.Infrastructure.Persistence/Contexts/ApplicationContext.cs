using AgendaTelefonica.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region ==> Tables

            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Email>()
                .ToTable("Emails");

            modelBuilder.Entity<Phone>()
                .ToTable("Phones");
            #endregion


            #region ==> Primary Keys
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);

            modelBuilder.Entity<Email>()
                .HasKey(email => email.Id);

            modelBuilder.Entity<Phone>()
                .HasKey(phone => phone.Id);
            #endregion


            #region ==> Relationships

            modelBuilder.Entity<User>()
                .HasMany<Phone>(user => user.Phones)
                .WithOne(phone => phone.User)
                .HasForeignKey(phone => phone.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany<Email>(user => user.Emails)
                .WithOne(email => email.User)
                .HasForeignKey(email => email.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region ==> Property Configuration

            #region User

            modelBuilder.Entity<User>().
                Property(user => user.Name)
                .IsRequired();

            modelBuilder.Entity<User>().
                Property(user => user.DocumentId)
                .IsRequired();

            #endregion

            #region Email

            modelBuilder.Entity<Email>().
                Property(email => email.EmailAddress)
                .IsRequired();

            #endregion

            #region User

            modelBuilder.Entity<Phone>().
                Property(phone => phone.PhoneNumber)
                .IsRequired();

            #endregion

            #endregion
        }


    }
}
