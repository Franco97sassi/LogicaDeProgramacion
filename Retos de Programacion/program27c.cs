//using Retos_de_Programacion;

//public class Library
//{
//    private List<Book> books = new List<Book>();
//    private List<User> users = new List<User>();
//    private List<Loan> loans = new List<Loan>();

//    // Gestión de libros
//    public void AddBook(string title, string author, int copies)
//    {
//        books.Add(new Book(title, author, copies));
//    }

//    public Book FindBook(string title)
//    {
//        return books.FirstOrDefault(b => b.Title == title);
//    }

//    // Gestión de usuarios
//    public void AddUser(string name, string id, string email)
//    {
//        users.Add(new User(name, id, email));
//    }

//    public User FindUser(string id)
//    {
//        return users.FirstOrDefault(u => u.Id == id);
//    }

//    // Gestión de préstamos
//    public void LoanBook(string userId, string bookTitle)
//    {
//        var user = FindUser(userId);
//        var book = FindBook(bookTitle);

//        if (user == null || book == null || book.AvailableCopies <= 0)
//        {
//            throw new InvalidOperationException("Cannot process loan");
//        }

//        book.AvailableCopies--;
//        loans.Add(new Loan(user, book, DateTime.Now));
//    }

//    public void ReturnBook(string userId, string bookTitle)
//    {
//        var loan = loans.FirstOrDefault(l =>
//            l.User.Id == userId && l.Book.Title == bookTitle && !l.IsReturned);

//        if (loan != null)
//        {
//            loan.Book.AvailableCopies++;
//            loan.IsReturned = true;
//            loan.ReturnDate = DateTime.Now;
//        }
//    }
//}