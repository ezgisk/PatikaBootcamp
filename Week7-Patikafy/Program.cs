using static Program;

class Program
{
    static void Main()
    {
        // Sanatçılar listesi
        List<Artist> artists = new List<Artist>
        {
            new Artist("Sıla", 12.5, 2000, "Pop"),
            new Artist("Sezen Aksu", 25, 1970, "Pop"),
            new Artist("Tarkan", 15.6, 1990, "Pop"),
            new Artist("Bergen", 5.0, 1980, "Arabesk"),
            new Artist("Barış Manço", 18.3, 1970, "Rock"),
            new Artist("Müzeyyen Senar", 10.2, 1940, "Türk Sanat Müziği"),
            new Artist("Candan Erçetin", 8.4, 1980, "Pop"),
            new Artist("Kenan Doğulu", 20.1, 2000, "Pop"),
            new Artist("Ahmet Kaya", 12.0, 1985, "Arabesk"),
            new Artist("Kıraç", 7.3, 1995, "Rock"),
            new Artist("Fikret Kızılok", 5.5, 1965, "Rock")
        };
        // Adı 'S' ile başlayan şarkıcılar
        var names = artists.Where(x => x.Name.StartsWith("S"));
        foreach (var artist in names)
        {
            Console.WriteLine(artist.Name);
        }
        Console.WriteLine("--------------------");
        // Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        var sales = artists.Where(x => x.AlbumSales > 10);
        foreach (var artist in sales)
        {
            Console.WriteLine(artist.Name);
        }
        Console.WriteLine("--------------------");
        // 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar
        var popArtistsBefore2000 = artists.Where(x => x.Year < 2000 && x.MusicType == "Pop");
        foreach (var artist in popArtistsBefore2000) 
        {
            Console.WriteLine(artist.Name); 
        }
        Console.WriteLine("--------------------");
        // En çok albüm satan şarkıcı
        var popularArtist = artists.OrderByDescending(x => x.AlbumSales);
        foreach(var artist in popularArtist)
        {
            Console.WriteLine(artist.Name);
        }
        Console.WriteLine("--------------------");
        // En yeni çıkış yapan ve en eski çıkış yapan şarkıcı
        var newestArtist = artists.OrderByDescending(x => x.Year).First();
        var oldestArtist = artists.OrderByDescending(x => x.Year).Last();
        Console.WriteLine($"En eski cikis yapan:{oldestArtist.Name} En yeni cikis yapan:{newestArtist.Name}");
        Console.ReadKey();
    }
    public class Artist
    {
        public string Name { get; set; }
        public string MusicType { get; set; }
        public int Year { get; set; }
        public double AlbumSales { get; set; }
        public Artist(string name, double albumSales, int year, string musicTypes)
        {
            Name = name;
            MusicType = musicTypes;
            Year = year;
            AlbumSales = albumSales;

        }
    }
}