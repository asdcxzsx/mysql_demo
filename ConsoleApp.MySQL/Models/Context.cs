using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.MySQL.Models
{
    public class Context: DbContext
    {
        public DbSet<DataLog> DataLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.;Database=NB_IoT;Trusted_Connection=True;");//"Server=Aron1;Database=pubs;Uid=sa;Pwd=asdasd;"
                optionsBuilder.UseMySQL("server=localhost;database=Test;user=root;password=2683").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DataLog>(entity =>
            {
                //entity.HasKey(e => e.Id);
                //entity.Property(e => e.Type).IsRequired();
                entity.HasIndex(x => x.Type);
            });
            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasKey(e => e.ISBN);
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasOne(d => d.Publisher)
            //        .WithMany(p => p.Books);
            //});
        }
    }
}
