using El_Catalan_Hospital.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.BLL.Services;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using El_Catalan_Hospital.BLL.BusinessLoginLayer.Contract;
using El_Catalan_Hospital.models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "El Catalan Hospital API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configure Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
    options.User.RequireUniqueEmail = true;
});

// Add Database Context
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("El_Catalan_Connection")));

// Add Identity
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

// Registering Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<GenericRepository<Patient>>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IReceptionistRepo, ReceptionistRepo>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();

// Add Authentication
var configuration = builder.Configuration;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = configuration.GetValue<bool>("JWT:ValidateIssuer"),
        ValidateAudience = configuration.GetValue<bool>("JWT:ValidateAudience"),
        ValidateLifetime = configuration.GetValue<bool>("JWT:ValidateLifetime"),
        ValidateIssuerSigningKey = configuration.GetValue<bool>("JWT:ValidateIssuerSigningKey"),
        ValidIssuer = configuration["JWT:Issuer"],
        ValidAudience = configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
    };
});

// Register application services
builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
builder.Services.AddScoped(typeof(IAdminService), typeof(AdminService));
builder.Services.AddScoped(typeof(ISecurityService), typeof(SecurityService));
builder.Services.AddScoped(typeof(IDoctorService), typeof(DoctorService));
builder.Services.AddScoped(typeof(IReceptionistService), typeof(ReceptionistService));
builder.Services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));



// Adding AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Build the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "El Catalan Hospital API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
