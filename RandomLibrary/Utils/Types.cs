namespace RandomLibrary.Utils
{
    // start JSON serial
    public class Thumbnails
    {
        public string smallThumbnail { get; set; } = "";
        public string thumbnail { get; set; } = "";
    }

    public class VolumeInfo
    {
        public string title { get; set; } = "";
        public List<string> authors { get; set; } = new List<string>();
        public List<string> categories { get; set; } = new List<string>();
        public string publisher { get; set; } = "";
        public string publishedDate { get; set; } = "";
        public string description { get; set; } = "";
        public string language { get; set; } = "";
        public uint pageCount { get; set; } = 0;
        public Thumbnails imageLinks { get; set; } = new Thumbnails();
    }

    public class BookJson
    {
        public string kind { get; set; } = "";
        public string id { get; set; } = "";
        public string etag { get; set; } = "";
        public string selfLink { get; set; } = "";
        public VolumeInfo volumeInfo { get; set; } = new VolumeInfo();

    }

    public class BookResp
    {
        public string kind { get; set; } = "";
        public uint totalItems { get; set; } = 0;
        public List<BookJson> items { get; set; } = new List<BookJson>();


        public Book GetBook()
        {
            var book = new Book();
            book.title = items[0].volumeInfo.title;
            book.authors = items[0].volumeInfo.authors;
            book.categories = items[0].volumeInfo.categories;
            book.publisher = items[0].volumeInfo.publisher;
            book.publishedDate = items[0].volumeInfo.publishedDate;
            book.description = items[0].volumeInfo.description;
            book.language = items[0].volumeInfo.language;
            book.pageCount = items[0].volumeInfo.pageCount;
            book.imageLinks = items[0].volumeInfo.imageLinks;
            book.id = items[0].id;
            book.etag = items[0].etag;
            book.isRead = false;

            return book;
        }
    }

    // end JSON serial

    public class Book
    {

        public bool isRead { get; set; } = false;
        public string title { get; set; } = "";
        public List<string> authors { get; set; } = new List<string>();
        public List<string> categories { get; set; } = new List<string>();
        public string publisher { get; set; } = "";
        public string publishedDate { get; set; } = "";
        public string description { get; set; } = "";
        public string language { get; set; } = "";
        public uint pageCount { get; set; } = 0;
        public Thumbnails imageLinks { get; set; } = new Thumbnails();

        public string id { get; set; } = "";
        public string etag { get; set; } = "";
    }
}
