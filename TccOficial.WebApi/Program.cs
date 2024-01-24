using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TccOficial.App.Features.Autenticacao;
using TccOficial.App.Features.HorariosFeature.Handlers;
using TccOficial.App.Features.Login;
using TccOficial.App.Features.PessoaFeature.PessoaHandler;
using TccOficial.App.Features.PlanoFeature.PlanoHandler;
using TccOficial.App.Features.TurmaFeature.Handlers;
using TccOficial.Domain.IRepository;
using TccOficial.Infra.Context;
using TccOficial.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Api de Gerenciamento de aulas de E-sports", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<TccContext>(options =>
    options.UseNpgsql("Server=localhost;user id=postgres;password=tomorrowland;database=TccOficial;Pooling=false;Application Name=TccOfc"));

//Repository
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IPerfilRepository, PerfilRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPlanoRepository, PlanoRepository>();
builder.Services.AddTransient<IJogoRepository, JogoRepository>();
builder.Services.AddTransient<IPlanoJogoRepository, PlanoJogoRepository>();
builder.Services.AddTransient<IHorarioRepository, HorarioRepository>();
builder.Services.AddTransient<ITurmaRepository, TurmaRepository>();


//Handlers
builder.Services.AddTransient<PessoaHandle, PessoaHandle>();
builder.Services.AddTransient<PlanoHandle, PlanoHandle>();
builder.Services.AddTransient<LoginHandle, LoginHandle>();
builder.Services.AddTransient<HorarioHandle, HorarioHandle>(); 
builder.Services.AddTransient<TurmaHandle, TurmaHandle>();

builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyMethod()
                 .AllowAnyOrigin()
                 .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
