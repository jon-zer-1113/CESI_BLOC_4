using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StiveAPI.Models;

namespace StiveAPI.Controllers
{
    [Route("stive_api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // On commence par déclarer une instance de la classe StiveContext nommée "_context" et la passe en tant que paramètre au constructeur de la classe UsersController.
        // Le constructeur enregistre la valeur du paramètre context dans la propriété _context pour pouvoir y accéder depuis d'autres méthodes de la classe UsersController (CRUD).
        private readonly StiveContext _context;

        public UsersController(StiveContext context)
        {
            _context = context;
        }


        // Point de terminaison d'API (url) GET, exemple: stive_api/users
        // Retourne une liste d'utilisateurs.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
              return await _context.Users.ToListAsync();
        }


        // Point de terminaison d'API (url) GET, exemple: stive_api/users/5
        // Retourne un utilisateur spécifique en fonction de son identifiant.
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
              var user = await _context.Users.FindAsync(id);

              if (user == null)
              {
                  return NotFound();
              }

              return user;
        }


        // Point de terminaison d'API (url) PUT, exemple: stive_api/users/5
        // Modifie un utilisateur existant.
        // AMELIORATION FUTUR : Ici, pour se protéger des attaques par surpostage, voir https://go.microsoft.com/fwlink/?linkid=2123754 et/ou utiliser DTO.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // Point de terminaison d'API (url) POST, exemple: stive_api/users
        // Ajoute un nouvel utilisateur.
        // AMELIORATION FUTUR : Ici, pour se protéger des attaques par surpostage, voir https://go.microsoft.com/fwlink/?linkid=2123754 et/ou utiliser DTO.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'StiveContext.Users'  is null.");
            }
              _context.Users.Add(user);
              await _context.SaveChangesAsync();

              return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }


        // Point de terminaison d'API (url) DELETE, exemple: stive_api/users/5
        // Supprime un utilisateur existant.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // Enfin, la méthode "UserExists" permet de vérifier si un utilisateur existe déjà dans la base de données en fonction de son identifiant.
        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
