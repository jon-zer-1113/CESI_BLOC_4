// "Program.cs" est le point d'entr�e de l'application, (configure les diff�rents composants pour ex�cuter l'application: les services, les middlewares, et les contr�leurs.)
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StiveAPI.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Ajoute les contr�leurs au pipeline d'injection de d�pendances de l'application.
// Signifie que lorsqu'un contr�leur est demand�, le syst�me d'injection de d�pendances peut fournir une instance du contr�leur en utilisant les d�pendances d�clar�es dans le constructeur.


builder.Services.AddDbContext<StiveContext>(opt =>
{
opt.UseInMemoryDatabase("db_stive");
opt.EnableSensitiveDataLogging();
});
// Ajoute le contexte de base de donn�es au conteneur d�injection de d�pendances.
// Sp�cifie que le contexte de base de donn�es utilise une base de donn�es locale. (Ici, on se connecte � la base de donnn�es (via la chaine de connexion, que l'on peut retrouver dans les propri�t�s de ma Db (Explorateur de serveurs...))


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
