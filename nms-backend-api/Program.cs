
using nms_backend_api.Controllers;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Concrete;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MyContext>();
            builder.Services.AddTransient< StudentRepository>();
            builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddTransient<ClassRepository>();
            builder.Services.AddTransient<IStudentAttendenceRepository, StudentAttendenceRepository>();
            builder.Services.AddTransient<ITeacherAttendenceRepository, TeacherAttendenceRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<ExaminationRepository>();
            builder.Services.AddTransient<ScheduleClassRepository>();
            builder.Services.AddTransient<AssignClass>();

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //enable cors to the project
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                {
                    options.AllowAnyOrigin()    //allow any client url
                    .AllowAnyMethod() //allow any http method
                    .AllowAnyHeader(); //allow any header
                });
            });
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

            app.UseAuthorization();
            //add cors middleware
            app.UseCors("AllowOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}
