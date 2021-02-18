using Microsoft.EntityFrameworkCore;
using PaymentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentDomain.Data
{
    public partial class DataContext: DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G9TP7E4;Database=Payment;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        //protected  override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //     modelBuilder.Entity<Payment>(entity =>
        //    {
        //        entity.HasKey(e => e.id);

        //        entity.Property(e => e.CreditCardNumber).HasColumnName("CreditCardNumber");

        //        entity.Property(e => e.CardHolder).HasColumnName("CardHolder");
        //        entity.Property(e => e.ExpirationDate).HasColumnName("ExpirationDate");
        //        entity.Property(e => e.SecurityCode).HasColumnName("SecurityCode");
        //        entity.Property(e => e.Amount).HasColumnName("Amount");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
