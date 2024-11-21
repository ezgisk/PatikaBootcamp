var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerOrders}/{action=Index}/{id?}");

app.Run();

/* * A��klamalar:
 * * Controller: MVC tasar�m deseninde, kullan�c� isteklerini i�leyen ve modele/veritaban�na eri�ip verileri d�zenleyen s�n�flard�r. 
 * * Action: Bir controller i�inde tan�mlanan ve kullan�c�n�n belirli bir i�lemini ger�ekle�tiren y�ntemlerdir. 
 * * Model: Uygulamadaki i� mant���n�, veritaban�n� ve i� kurallar�n� temsil eder.
 * * View: Kullan�c�ya g�sterilecek olan aray�zd�r. Genellikle Razor View Engine kullan�larak olu�turulur. 
 * * Razor: .NET'te dinamik HTML sayfalar� olu�turmay� sa�layan bir �ablonlama motorudur. 
 * * RazorView: Razor kullan�larak olu�turulan bir view dosyas�n� ifade eder. 
 * * wwwroot: Statik dosyalar�n (CSS, JavaScript, g�rseller) sakland��� klas�rd�r. 
 * * builder.Build(): Uygulama yap�land�rmas�n� tamamlar ve �al��t�r�labilir bir web uygulamas� nesnesi olu�turur. 
 * * app.Run(): Uygulamay� ba�lat�r ve HTTP isteklerini dinlemeye ba�lar. */