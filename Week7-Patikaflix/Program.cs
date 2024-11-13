class Program
{
    static void Main()
    {
        List<Dizi> diziler = new List<Dizi>();
        List<Komedi> komedi = new List<Komedi>();

        string devamEt;

        // Kullanıcıdan diziler alıyoruz
        do
        {
            Console.WriteLine("Dizi Adı: ");
            string diziAdi = Console.ReadLine();

            Console.WriteLine("Dizi Türü: ");
            string diziTuru = Console.ReadLine();

            Console.WriteLine("Yönetmen: ");
            string yönetmen = Console.ReadLine();

            Dizi newDizi = new Dizi(diziAdi, diziTuru, yönetmen);
            diziler.Add(newDizi);

            // Eğer dizi komedi türündeyse, komedi listesine ekliyoruz
            if (diziTuru.ToLower() == "komedi")
            {
                Komedi komediDizi = new Komedi(diziAdi, diziTuru, yönetmen);
                komedi.Add(komediDizi);
            }

            // Kullanıcıya yeni dizi ekleyip eklemek istemediğini soruyoruz
            Console.WriteLine("Başka bir dizi eklemek ister misiniz? (Evet/Hayır)");
            devamEt = Console.ReadLine();

        } while (devamEt.ToLower() == "evet");

        // Komedi dizilerini sıralıyoruz (Önce Dizi adı, sonra Yönetmen'e göre)
        var komediDizileri = komedi.OrderBy(k => k.Name).ThenBy(k => k.Director).ToList();

        // Komedi dizilerini yazdırıyoruz
        Console.WriteLine("\nSıralanmış Komedi Dizileri:");
        foreach (var komediDizi in komediDizileri)
        {
            komediDizi.Yazdir();
        }
        Console.ReadKey();
    }
    
}


class Dizi
{
    public string Name { get; set; }
    public int YearConstruction { get; set; }
    public string Type { get; set; }
    public int YearStartPublishing { get; set; }
    public string Director { get; set; }
    public int FirstPlatformPublishedOn { get; set; }
    public Dizi(string name, string type, string director)
    {
        Name = name;
        Type = type;
        Director = director;

    }
    public void Yazdir()
    {
        Console.WriteLine($"Dizi Adı: {Name}, Yönetmen: {Director}");
    }

}
class Komedi
{
    public string Name { get; set; }
    public int YearConstruction { get; set; }
    public string Type { get; set; }
    public int YearStartPublishing { get; set; }
    public string Director { get; set; }
    public int FirstPlatformPublishedOn { get; set; }
    public Komedi(string name, string type, string director)
    {
        Name = name;
        Type = type;
        Director = director;

    }
    public void Yazdir()
    {
        Console.WriteLine($"Dizi Adı: {Name}, Yönetmen: {Director}");
    }
}