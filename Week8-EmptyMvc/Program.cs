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

/* * Açýklamalar:
 * * Controller: MVC tasarým deseninde, kullanýcý isteklerini iþleyen ve modele/veritabanýna eriþip verileri düzenleyen sýnýflardýr. 
 * * Action: Bir controller içinde tanýmlanan ve kullanýcýnýn belirli bir iþlemini gerçekleþtiren yöntemlerdir. 
 * * Model: Uygulamadaki iþ mantýðýný, veritabanýný ve iþ kurallarýný temsil eder.
 * * View: Kullanýcýya gösterilecek olan arayüzdür. Genellikle Razor View Engine kullanýlarak oluþturulur. 
 * * Razor: .NET'te dinamik HTML sayfalarý oluþturmayý saðlayan bir þablonlama motorudur. 
 * * RazorView: Razor kullanýlarak oluþturulan bir view dosyasýný ifade eder. 
 * * wwwroot: Statik dosyalarýn (CSS, JavaScript, görseller) saklandýðý klasördür. 
 * * builder.Build(): Uygulama yapýlandýrmasýný tamamlar ve çalýþtýrýlabilir bir web uygulamasý nesnesi oluþturur. 
 * * app.Run(): Uygulamayý baþlatýr ve HTTP isteklerini dinlemeye baþlar. */