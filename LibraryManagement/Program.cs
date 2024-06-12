
using BUSINESS.Interfaces;
using BUSINESS.Services;
using DAL.DataAccess;
using ENTITIES.Profiles;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDbContext")));
            builder.Services.AddScoped<IBook, BookService>();
            builder.Services.AddScoped<IUser, UserService>();

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(BookProfile));
            builder.Services.AddAutoMapper(typeof(UserProfile));

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
        }
    }
}
