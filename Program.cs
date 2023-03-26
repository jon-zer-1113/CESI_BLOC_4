// "Program.cs" est le point d'entr�e de l'application, (configure les diff�rents composants pour ex�cuter l'application: les services, les middlewares, et les contr�leurs.)
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using B4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using B4_API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
// Ajoute le middleware d'authentification � l'application en utilisant le sch�ma d'authentification JwtBearer, qui est un protocole d'authentification bas� sur des jetons JWT (JSON Web Token).

builder.Services.AddControllers();
// Ajoute les contr�leurs au pipeline d'injection de d�pendances de l'application.
// Signifie que lorsqu'un contr�leur est demand�, le syst�me d'injection de d�pendances peut fournir une instance du contr�leur en utilisant les d�pendances d�clar�es dans le constructeur.

builder.Services.AddDbContext<ApiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Ajoute le contexte de base de donn�es au conteneur d�injection de d�pendances.
// Sp�cifie que le contexte de base de donn�es utilise une base de donn�es SQL sERVER. (Ici, on se connecte � la base de donnn�es (via la chaine de connexion, que l'on peut retrouver dans le fichier "appsettings.json")

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Ajoutent des services � l'application qui permettent de g�n�rer de la documentation pour les API de l'application.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure le pipeline de requ�te HTTP.
// (condition qui d�termine si le pipeline de requ�te HTTP doit inclure le middleware Swagger pour g�n�rer une documentation API dans le cas o� l'application est en mode d�veloppement.)

app.UseHttpsRedirection();
// Redirige automatiquement les requ�tes HTTP vers HTTPS.

app.UseAuthorization();
// Ajoute un middleware d'autorisation pour contr�ler l'acc�s aux ressources prot�g�es.

app.MapControllers();
// Ajoute un middleware pour g�rer les requ�tes HTTP aux contr�leurs d�finis dans l'application.

app.Run();
// Indique � l'application de d�marrer le traitement des requ�tes HTTP.