using System;
using System.Collections.Generic;

class Book
{
    private string title;
    private string author;
    private string isbn;
    private int copiesAvailable;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string ISBN
    {
        get { return isbn; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ISBN cannot be empty.");
            if (value.Length != 13)
                throw new ArgumentException("ISBN must be 13 characters long.");
            if (!IsDigitsOnly(value))
                throw new ArgumentException("ISBN must contain only digits.");
            isbn = value;
        }
    }

    public int CopiesAvailable
    {
        get { return copiesAvailable; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Copies available cannot be negative.");
            copiesAvailable = value;
        }
    }

    public Book(string title, string author, string isbn, int copiesAvailable)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        CopiesAvailable = copiesAvailable;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Copies Available: {CopiesAvailable}");
    }

    public bool BorrowBook()
    {
        if (copiesAvailable > 0)
        {
            copiesAvailable--;
            return true;
        }
        return false;
    }

    public void ReturnBook()
    {
        copiesAvailable++;
    }

    private bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(string isbn)
    {
        var bookToRemove = books.Find(b => b.ISBN == isbn);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void DisplayAllBooks()
    {
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }

    public Book SearchBook(string isbn)
    {
        return books.Find(b => b.ISBN == isbn);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display All Books");
            Console.WriteLine("4. Search Book");
            Console.WriteLine("5. Borrow Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN (13 characters): ");
                    string isbn = Console.ReadLine();
                    Console.Write("Enter Copies Available: ");
                    int copiesAvailable;
                    while (!int.TryParse(Console.ReadLine(), out copiesAvailable) || copiesAvailable < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer for copies available: ");
                    }
                    try
                    {
                        Book book = new Book(title, author, isbn, copiesAvailable);
                        library.AddBook(book);
                        Console.WriteLine("Book added successfully.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    Console.Write("Enter ISBN of the book to remove: ");
                    string removeIsbn = Console.ReadLine();
                    library.RemoveBook(removeIsbn);
                    break;

                case "3":
                    library.DisplayAllBooks();
                    break;

                case "4":
                    Console.Write("Enter ISBN to search: ");
                    string searchIsbn = Console.ReadLine();
                    Book foundBook = library.SearchBook(searchIsbn);
                    if (foundBook != null)
                    {
                        foundBook.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case "5":
                    Console.Write("Enter ISBN of the book to borrow: ");
                    string borrowIsbn = Console.ReadLine();
                    Book bookToBorrow = library.SearchBook(borrowIsbn);
                    if (bookToBorrow != null && bookToBorrow.BorrowBook())
                    {
                        Console.WriteLine("Book borrowed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No copies available to borrow.");
                    }
                    break;

                case "6":
                    Console.Write("Enter ISBN of the book to return: ");
                    string returnIsbn = Console.ReadLine();
                    Book bookToReturn = library.SearchBook(returnIsbn);
                    if (bookToReturn != null)
                    {
                        bookToReturn.ReturnBook();
                        Console.WriteLine("Book returned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

