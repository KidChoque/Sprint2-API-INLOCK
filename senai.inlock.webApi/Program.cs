using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Valida quem está solicitando 
            ValidateIssuer = true,

            //Valida quem está recebendo
            ValidateAudience = true,

            //Define se o tempo de expiração será validado
            ValidateLifetime = true,

            //Forma de criptografia e valida a chave de autenticação 
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("*filmes-chave-autenticadcao-webapi-dev")),

            //Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //Nome do issuer ( de onde está vindo)
            ValidIssuer = "senai.inlock.webApi_",

            // Nome do audience (para onde está indo)
            ValidAudience = "senai.inlock.webApi_"


        };
    });




//Adiciona o serviço do Swagger
builder.Services.AddSwaggerGen(options =>
{

    //Adiciona informações sonbre a API e o swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API-Filmes-Lucas.S.Machado",
        Description = "API que guarda e cadastra estúdios e seus jogos - Introdução a API - SPRINT 2",
        Contact = new OpenApiContact
        {
            Name = "Lucas -KidChoque- Machado",
            Url = new Uri("https://github.com/KidChoque")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  //  options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    //Usando a autenticaçao no Swagger

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var app = builder.Build();




//Inicia a configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Termina a configuração do Swagger


app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();



