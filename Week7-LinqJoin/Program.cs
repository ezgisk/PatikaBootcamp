using System;

class GFG
{
    public static void Main(String[] args)
    {
        // Yazarlar listesi
        List<Authors> authors = new List<Authors>
        {
            new Authors { AuthorId = 1, AuthorName = "Ahmet Ümit" },
            new Authors { AuthorId = 2, AuthorName = "Orhan Pamuk" },
            new Authors { AuthorId = 3, AuthorName = "Elif Şafak" }
        };

        // Kitaplar (Books) listesi
        List<Books> books = new List<Books>
        {
            new Books { BookId = 1, Title = "Beyoğlu Rapsodisi", AuthorId = 1 },
            new Books { BookId = 2, Title = "Kırmızı Saçlı Kadın", AuthorId = 2 },
            new Books { BookId = 3, Title = "10 Dakika 38 Saniye", AuthorId = 3 },
            new Books { BookId = 4, Title = "Kar", AuthorId = 2 }
        };

        // Joinle birlestirme
        var titleAuthor = from book in books
                          join author in authors on book.AuthorId equals author.AuthorId
                          select new
                          {
                              BookTitle = book.Title,
                              AuthorName = author.AuthorName
                          };
        foreach (var result in titleAuthor)
        {
            Console.WriteLine($"Kitap: {result.BookTitle}, Yazar: {result.AuthorName}");
        }
        Console.ReadKey();
    }
}

class Authors
{
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}
class Books
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}
