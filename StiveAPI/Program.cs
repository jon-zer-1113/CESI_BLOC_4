// "Program.cs" est le point d'entrée de l'application, (configure les différents composants pour exécuter l'application: les services, les middlewares, et les contrôleurs.)
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StiveAPI.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Ajoute les contrôleurs au pipeline d'injection de dépendances de l'application.
// Signifie que lorsqu'un contrôleur est demandé, le système d'injection de dépendances peut fournir une instance du contrôleur en utilisant les dépendances déclarées dans le constructeur.


builder.Services.AddDbContext<StiveContext>(opt =>
{
opt.UseInMemoryDatabase("db_stive");
opt.EnableSensitiveDataLogging();
});
// Ajoute le contexte de base de données au conteneur d’injection de dépendances.
// Spécifie que le contexte de base de données utilise une base de données locale. (Ici, on se connecte à la base de donnnées (via la chaine de connexion, que l'on peut retrouver dans les propriétés de ma Db (Explorateur de serveurs...))


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Ajoutent des services à l'application qui permettent de générer de la documentation pour les API de l'application.

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure le pipeline de requête HTTP.
// (condition qui détermine si le pipeline de requête HTTP doit inclure le middleware Swagger pour générer une documentation API dans le cas où l'application est en mode développement.)


app.UseHttpsRedirection();
// Redirige automatiquement les requêtes HTTP vers HTTPS.


app.UseAuthorization();
// Ajoute un middleware d'autorisation pour contrôler l'accès aux ressources protégées.


app.MapControllers();
// Ajoute un middleware pour gérer les requêtes HTTP aux contrôleurs définis dans l'application.


app.Run();
// Indique à l'application de démarrer le traitement des requêtes HTTP.
