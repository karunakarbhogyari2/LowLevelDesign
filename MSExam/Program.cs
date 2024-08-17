namespace Library
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string PublicationYear { get; set; } = default!;
        public bool IsBorrowed { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = default!;
        public List<Book> BorrowedBooks { get; set; }
        public User()
        {
            BorrowedBooks = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }
        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(BorrowedBooks.First(c => c.BookID == book.BookID));
        }
    }
    public class Libray
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public Libray()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(int bookId)
        {
            var book = Books.First(c => c.BookID == bookId);
            Books.Remove(book);
        }
        public List<Book> SearchBooks(string keyword)
        {
            return Books.Where(c => c.Title.Contains(keyword) || c.Author.Contains(keyword)).ToList();
        }
        public void BorrowBook(int bookID, int userID)
        {
            var book = Books.First(c => c.BookID == bookID);
            var user = Users.First(c => c.UserID == userID);

            if (!book.IsBorrowed)
            {
                book.IsBorrowed = true;
                user.BorrowBook(book);
            }
        }
        public void ReturnBook(int bookID, int userID)
        {
            var user = Users.First(c => c.UserID == userID);
            var book = user.BorrowedBooks.FirstOrDefault(c => c.BookID == bookID);
            if (book is not null)
            {
                book.IsBorrowed = false;
                user.ReturnBook(Books.First(c => c.BookID == bookID));
            }
        }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void RemoveUser(int userID)
        {
            Users.Remove(Users.First(c => c.UserID == userID));
        }
        public User GetUserDetails(int userID)
        {
            return Users.First(c => c.UserID == userID);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var library = new Libray();

            library.AddBook(new Book
            {
                BookID = 1,
                Title = "Geeta",
                Author = "Vinayak",
                IsBorrowed = false
            });

            library.AddBook(new Book
            {
                BookID = 2,
                Title = "Ramayan",
                Author = "Valmiki",
                IsBorrowed = false
            });

            library.AddUser(new User { Name = "Karunakar", UserID = 100 });

            library.AddUser(new User { Name = "Haritha", UserID = 101 });

            library.BorrowBook(1, 100);

            library.ReturnBook(1, 100);
        }
    }
}
