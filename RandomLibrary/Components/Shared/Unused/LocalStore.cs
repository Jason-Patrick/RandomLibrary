using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RandomLibrary.Utils;
using static MudBlazor.CategoryTypes;

namespace RandomLibrary.Components.Shared.Unused
{
    internal static class LocalStore
    {
        private static string path = FileSystem.Current.AppDataDirectory;
        private static string booksFile = "books.json";
        private static string booksPath = Path.Combine(path, booksFile);

        static LocalStore()
        {
            if (!File.Exists(booksPath))
            {
                File.Create(booksPath).Dispose();
            }
        }

        public static async Task WriteBookAsync(Book book)
        {
            List<Book>? list = null;
            using (Stream inStream = File.OpenRead(booksPath))
            {
                using StreamReader reader = new StreamReader(inStream);
                string jsonData = await reader.ReadToEndAsync();
                if (jsonData != string.Empty)
                {
                    list = JsonSerializer.Deserialize<List<Book>>(jsonData);
                    inStream.Close();
                }
            }

            string bookJson = string.Empty;
            if (list is not null)
            {
                list.Add(book);
                bookJson = JsonSerializer.Serialize(list);
            }
            else
            {
                bookJson = JsonSerializer.Serialize(new List<Book>([book]));
            }

            using (Stream outStream = File.OpenWrite(booksPath))
            {
                using StreamWriter streamWriter = new StreamWriter(outStream);
                await streamWriter.WriteAsync(bookJson);
            }
        }

        public static async Task<List<Book>> GetBooksAsync()
        {
            Stream inStream = File.OpenRead(booksPath);

            using StreamReader reader = new StreamReader(inStream);
            string jsonData = await reader.ReadToEndAsync();

            if (jsonData == string.Empty)
            {
                return new List<Book>();
            }

            var list = JsonSerializer.Deserialize<List<Book>>(jsonData);

            inStream.Close();

            return list != null ? list : new List<Book>();
        }


    }

}
