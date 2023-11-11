using AutoMapper;
using LoremIpsumLogistica.Aplicacao.Interfaces;
using LoremIpsumLogistica.Aplicacao.Servicos;
using LoremIpsumLogistica.Dominio.Interfaces.Repositorios;
using LoremIpsumLogistica.Dominio.Interfaces.Servicos;
using LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho;
using LoremIpsumLogistica.Dominio.Servicos;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Context;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Repositorios;
using LoremIpsumLogistica.Infraestrutura.Repositorio.UnidadeDeTrabalho;
using LoremIpsumLogistica.UI.Api.AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);




#region DB Context e Inversão de dependência
#region - Repositorios
builder.Services.AddScoped(typeof(Repositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();


builder.Services.AddScoped<IRepositorioDeClientes, RepositorioDeClientes>();
builder.Services.AddScoped<IRepositorioDeClientesEnderecos, RepositorioDeClientesEnderecos>();
#endregion

#region Servicos de aplicacao
builder.Services.AddTransient<IServicoDeAplicacaoDeClientes, ServicoDeAplicacaoDeClientes>();
builder.Services.AddTransient<IServicoDeAplicacaoDeClientesEnderecos, ServicoDeAplicacaoDeClientesEnderecos>();

/*Acessando usuario logado em qualquer camada*/
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

#region Servicos de dominio
builder.Services.AddTransient<IServicoDeDominioDeClientes, ServicoDeDominioDeClientes>();
builder.Services.AddTransient<IServicoDeDominioDeClientesEnderecos, ServicoDeDominioDeClientesEnderecos>();
#endregion Servicos

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LoremDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
#endregion DB Context


// Add services to the container.
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LoremIpsum Logística",
        Description = "Teste Técnico InvitaTech",
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

#region Automapper 
var config = new MapperConfiguration(config =>
{
    config.AddProfile(new DominioParaModel());
    config.AddProfile(new DTOParaModel());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion Automapper 


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");

});
//}

app.UseHttpsRedirection();
app.UseRouting();


// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


// Obtém o serviço de configuração do aplicativo

// Obtém a cultura padrão da seção "Localization" no arquivo appsettings.json
var defaultCulture = builder.Configuration.GetSection("Localization")["DefaultCulture"];

// Configura a cultura padrão para a aplicação
//var cultureInfo = new CultureInfo(defaultCulture);
//CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
//CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var ci = new CultureInfo(defaultCulture);
ci.NumberFormat.NumberDecimalSeparator = "."; // Defining my preferrence for number
ci.NumberFormat.CurrencyDecimalSeparator = ",";

// Configuring Number Seperator Using Localization middleware
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
    }
});




app.Run();
