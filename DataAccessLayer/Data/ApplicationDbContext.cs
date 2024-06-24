using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> bookDatials { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        public DbSet<Fluent_Book> Fluent_books { get; set; }

        public DbSet<Fluent_BookDetail> Fluent_bookDatials { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }


        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        //{
            
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-CH8SV7T;Database=Console;TrustServerCertificate=True;Trusted_Connection=True;")
                .LogTo(Console.WriteLine, new[]
                {
                   DbLoggerCategory.Database.Command.Name
                }, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(a => a.Price).HasPrecision(10, 5);


            modelBuilder.Entity<BookAuthorMap>().HasKey(a => new { a.Author_Id, a.Book_Id });


            modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(a => new { a.Author_Id, a.Book_Id });
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(a => a.Book).WithMany(a => a.BookAuthorMap)
                .HasForeignKey(a => a.Book_Id);
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(a => a.Author).WithMany(a => a.BookAuthorMap)
                .HasForeignKey(a => a.Author_Id);


            modelBuilder.Entity<Fluent_Book>().HasKey(a => a.BookId);
            modelBuilder.Entity<Fluent_Book>().Property(a => a.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(a => a.ISBN).HasMaxLength(20);
            modelBuilder.Entity<Fluent_Book>().Ignore(a => a.PriceRange);
            modelBuilder.Entity<Fluent_Book>().HasOne(a => a.Publisher).WithMany(a=>a.Books)
                .HasForeignKey(a => a.Publisher_Id);

            modelBuilder.Entity<Fluent_Author>().HasKey(a => a.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(a => a.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(a => a.FullName);

            modelBuilder.Entity<Fluent_BookDetail>().HasKey(a => a.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(a => a.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(a => a.Book).WithOne(a => a.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(a => a.Book_Id);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(a => a.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(a => a.Name).IsRequired();
            

            modelBuilder.Entity<Book>().HasData(
                new Book
                { BookId = 1,Title="Englist",ISBN= "123asd",Price= 250 , Publisher_Id=1},
                new Book
                { BookId = 2 , Title ="Urdu", ISBN= "1234asd",Price = 300, Publisher_Id = 2 }
                );

            var booklist= new Book[]
            {
                new Book {BookId = 3,Title="Pak Study" , ISBN = "12345asd",Price= 2, Publisher_Id=3},
                new Book {BookId = 4 ,Title= "Maths", ISBN =  "123456asd",Price=1000, Publisher_Id=2 },
            };

            modelBuilder.Entity<Book>().HasData( booklist );


            modelBuilder.Entity<Publisher>()
                .HasData(
                new Publisher
                { Publisher_Id = 1, Name = "Asif", Location = "Pehsawar" },
                 new Publisher
                 { Publisher_Id = 2, Name = "Asif Ali", Location = "Mardan" },
                 new Publisher
                 { Publisher_Id = 3, Name = "Asif Khan", Location = "Katlang" }
                      );

        }

    }
}
   