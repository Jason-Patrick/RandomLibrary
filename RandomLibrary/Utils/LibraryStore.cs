using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLibrary.Utils
{
    internal class LibraryStore
    {
        public delegate void LibraryUpdatedHandler();
        public event LibraryUpdatedHandler LibraryUpdated;

        private List<Book> library;
        private PreferencesStore store;

        public LibraryStore()
        {
            store = new PreferencesStore();
            if (!store.Exists("books"))
            {
                library = new List<Book>();
                return;
            }

            library = store.Get<List<Book>>("books");
        }


        public Book? GetBook(string id)
        {
            return (from book in library where book.id == id select book).FirstOrDefault();
        }

        public Book? GetRandomBook()
        {
            var random = new Random();
            var unreads = GetUnreadBooks();
            if (unreads.Count > 0)
            {
                int index = random.Next(unreads.Count);
                return unreads[index];
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            return library;
        }

        public List<Book> GetReadBooks()
        {
            return (from book in library where book.isRead == true select book).ToList();
        }

        public List<Book> GetUnreadBooks()
        {
            return (from book in library where book.isRead == false select book).ToList();
        }

        public void AddBook(BookResp book)
        {
            library.Add(book.GetBook());
            store.Set("books", library);
            LibraryUpdated();
        }

        public void RemoveBook(string id)
        {
            var filteredLib = (from book in library where book.id != id select book).ToList();
            library = filteredLib;
            store.Set("books", library);
            LibraryUpdated();
        }

        public void MarkBookRead(string id)
        {
            foreach (var book in library.Where(book => book.id == id))
            {
                book.isRead = true;
            }
            store.Set("books", library);
            LibraryUpdated();

        }

        public void MarkBookUnread(string id)
        {
            foreach (var book in library.Where(book => book.id == id))
            {
                book.isRead = false;
            }
            store.Set("books", library);
            LibraryUpdated();

        }
    }
}
