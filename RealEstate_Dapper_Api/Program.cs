using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);


//Transient ba??ml?l?k enjeksiyonu, her talep edildi?inde yeni bir nesne örne?i olu?turur.
// Bu sat?rda, her bir "Context" nesnesi için yeni bir örnek olu?turulur.
// "Context" nesnesi genellikle veritaban? ba?lant?s?n? temsil eder ve her ba?lant?
// için ayr? bir ba?lant? nesnesi olu?turulmas? veritaban? i?lemlerini izole eder.
builder.Services.AddTransient<Context>();

// Bu sat?rda, "ICategoryRepository" arayüzü için her bir talepte yeni bir
// "CategoryRepository" s?n?f? örne?i olu?turulur. Bu, her "CategoryRepository"
// kullan?m?nda yeni bir ba??ml?l?k örne?i sa?lar ve ba??ml?l?klar?n izole edilmesini
// ve veri payla??m?n?n önlenmesini sa?lar.
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
