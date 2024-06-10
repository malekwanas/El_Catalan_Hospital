using El_Catalan_Hospital.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using El_Catalan_Hospital.BLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using El_Catalan_Hospital.API.Repository.Contract;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.BLL.Services;
using El_Catalan_Hospital.API.Repository;
using El_Catalan_Hospital.API.Helpers;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("El_Catalan_Connection")));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
builder.Services.AddScoped(typeof(IGenericRepositoryUser<>), typeof(GenericRepositoryUser<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddIdentity<AppUser, IdentityRole>
(options =>
{

}).AddEntityFrameworkStores<DatabaseContext>();

var app = builder.Build();
app.UseAuthentication();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

