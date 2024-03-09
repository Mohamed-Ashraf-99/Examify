using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Feature.Repository;
using ExaminationBLL.Mapping.DepartmentMapp;

// using ExaminationBLL.Mapping.DepartmentMapp;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();



//Session
builder.Services.AddSession();

//Scope
builder.Services.AddScoped<IReportRepo, ReportRepo>();

builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<ILoginRepo, LoginManager>();
builder.Services.AddScoped<DepartmentMapper>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentManager>();
//
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<IExamRepo, ExamRepo>();
builder.Services.AddScoped<IpreExam, PreExamManager>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped(typeof(IInstructorRepo), typeof(InstructorRepo));
builder.Services.AddScoped(typeof(IGenerateExamRepo), typeof(GenerateExamRepo));
builder.Services.AddScoped(typeof(IGetExamResultRepo), typeof(GetExamResultRepo));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();