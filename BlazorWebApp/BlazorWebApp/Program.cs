using BlazorWebApp.Client.Pages;
using BlazorWebApp.Components;
using BlazorWebApp.Data;
using BlazorWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// agregado recientemente
builder.Services.AddDbContextFactory<NegocioContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("NegocioInformatica")));
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<CarritoStateService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<SesionUsuarioService>();
builder.Services.AddScoped<PromocionService>();
builder.Services.AddScoped<PedidoService>();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
