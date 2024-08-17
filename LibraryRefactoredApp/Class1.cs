namespace LibraryRefactoredApp
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
        public int Age { get; set; }
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

    public class Class1
    {

    }
}
