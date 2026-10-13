//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using DdlAuditApi.Data;

//var builder = WebApplication.CreateBuilder(args);

////// 1. إضافة DbContext
////builder.Services.AddDbContext<AuditDbContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditDbConnection")));

////// 2. تفعيل CORS للسماح لـ Vue.js بالاتصال
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowVueApp",
////        policy => policy.WithOrigins("http://localhost:5173") // منفذ Vue/Vite الافتراضي
////                        .AllowAnyHeader()
////                        .AllowAnyMethod());
////});

//// 1. إضافة خدمة CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowVueApp", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});



//// 2. تفعيل سياسة CORS (تأكد من وضعها قبل app.UseAuthorization)


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();
//app.UseCors("AllowVueApp");

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors("AllowVueApp");
//app.UseAuthorization();
//app.MapControllers();

//app.Run();
using Microsoft.EntityFrameworkCore;
using DdlAuditApi.Data; // تأكد من استدعاء Namespace الخاص بـ AuditDbContext

var builder = WebApplication.CreateBuilder(args);

// 1. تسجيل DbContext وقراءة الاتصال من appsettings.json
builder.Services.AddDbContext<AuditDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditDbConnection")));

// 2. تسجيل الكنترولرات
builder.Services.AddControllers();

// 3. إضافة سياسة CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// إضافة خدمات Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// تفعيل Swagger في بيئة التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4. تفعيل سياسة CORS
app.UseCors("AllowVueApp");

app.UseAuthorization();
app.MapControllers();

app.Run();