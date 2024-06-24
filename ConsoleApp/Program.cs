using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;

//Console.WriteLine("Welcome");

Console.WriteLine("1: Add Book ");

Console.WriteLine("2: Get All Books");
Console.WriteLine("3: Get Book ");
Console.WriteLine("4: Update Book");
Console.WriteLine("5: delete Book");

int aa = Convert.ToInt32(Console.ReadLine());

switch (aa)
{
    case 1:
        AddBooks();
        break;
        case 2:
        GetAllBooks();
        break;
        case 3:
        GetBooks();
        break;
        case 4:
        UpdateBooks();
        break;
        case 5:
        DeleteBook();
        break;
        default:
        Console.WriteLine("You Enter Wrong Number");
        break;
}



//GetBooks();
////UpdateBooks();
////DeleteBook();

async void DeleteBook()
{

    using var context = new ApplicationDbContext();
    var book = context.books.Find(4);
    context.books.Remove(book);
    await context.SaveChangesAsync();



}
 void UpdateBooks()
{
    try
    {
        using var context = new ApplicationDbContext();
        var book = context.books.Find(5);
        book.Price = 200;
         context.SaveChanges();

    }
    catch (Exception e)
    {

    }
}

 void GetBooks()
{

    try
    {
        using var context = new ApplicationDbContext();
        var book =  context.books.Skip(1).Take(3).ToList();
        //var book = context.books.Where(a => a.Publisher_Id == 2).FirstOrDefault();
        // var book = context.books.Where(a=>a.Price >100).OrderBy(a => a.Title).ThenByDescending(a => a.ISBN);
        //Console.WriteLine($"Book Name : {book.Title} ---- Book ISBN : {book.ISBN} ---- Book Price : {book.Price} ---- Publisher : {book.Publisher_Id}");
        foreach (var item in book)
        {
            Console.WriteLine($"Book Name : {item.Title} ---- Book ISBN : {item.ISBN} ---- Book Price : {item.Price} ---- Publisher : {item.Publisher_Id}");
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void AddBooks()
{
    Book book1 = new Book()
    {
        Title = "New English ",
        ISBN = "1234567asd",
        Price = 150,
        Publisher_Id = 1
    };
    using var context = new ApplicationDbContext();
    var book = context.books.Add(book1);
    context.SaveChanges();



}

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var book = context.books.ToList();

    foreach (var item in book)
    {
        Console.WriteLine($"Book Name : {item.Title} ---- Book ISBN : {item.ISBN} ---- Book Price : {item.Price} ---- Publisher : {item.Publisher_Id}");
    }

}

