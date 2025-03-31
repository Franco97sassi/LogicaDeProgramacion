using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retos_de_Programacion
{
    // Clases básicas
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public int AvailableCopies { get; set; }

        public Book(string title, string author, int copies)
        {
            Title = title;
            Author = author;
            AvailableCopies = copies;
        }
    }

    public class User
    {
        public string Name { get; }
        public string Id { get; }
        public string Email { get; }

        public User(string name, string id, string email)
        {
            Name = name;
            Id = id;
            Email = email;
        }
    }

    public class Loan
    {
        public User User { get; }
        public Book Book { get; }
        public DateTime LoanDate { get; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        public Loan(User user, Book book, DateTime loanDate)
        {
            User = user;
            Book = book;
            LoanDate = loanDate;
            IsReturned = false;
        }
    }

    // Clases con responsabilidades separadas
    public class BookManager
    {
        private List<Book> books = new List<Book>();

        public void AddBook(string title, string author, int copies)
        {
            books.Add(new Book(title, author, copies));
        }

        public Book FindBook(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(books);
        }
    }

    public class UserManager
    {
        private List<User> users = new List<User>();

        public void AddUser(string name, string id, string email)
        {
            users.Add(new User(name, id, email));
        }

        public User FindUser(string id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(users);
        }
    }

    public class LoanManager
    {
        private List<Loan> loans = new List<Loan>();
        private BookManager bookManager;
        private UserManager userManager;

        public LoanManager(BookManager bookManager, UserManager userManager)
        {
            this.bookManager = bookManager;
            this.userManager = userManager;
        }

        public void LoanBook(string userId, string bookTitle)
        {
            var user = userManager.FindUser(userId);
            var book = bookManager.FindBook(bookTitle);

            if (user == null || book == null || book.AvailableCopies <= 0)
            {
                throw new InvalidOperationException("Cannot process loan");
            }

            book.AvailableCopies--;
            loans.Add(new Loan(user, book, DateTime.Now));
        }

        public void ReturnBook(string userId, string bookTitle)
        {
            var loan = loans.FirstOrDefault(l =>
                l.User.Id == userId && l.Book.Title == bookTitle && !l.IsReturned);

            if (loan != null)
            {
                loan.Book.AvailableCopies++;
                loan.IsReturned = true;
                loan.ReturnDate = DateTime.Now;
            }
        }

        public List<Loan> GetActiveLoans()
        {
            return loans.Where(l => !l.IsReturned).ToList();
        }
    }

    // Clase coordinadora (opcional)
    public class LibrarySystem
    {
        public BookManager BookManager { get; }
        public UserManager UserManager { get; }
        public LoanManager LoanManager { get; }

        public LibrarySystem()
        {
            BookManager = new BookManager();
            UserManager = new UserManager();
            LoanManager = new LoanManager(BookManager, UserManager);
        }
    }
}
