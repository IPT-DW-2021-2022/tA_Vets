using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Veterinarios.Data;
using Veterinarios.Models;

namespace Veterinarios.Controllers.API {
   [Route("api/[controller]")]
   [ApiController]
   public class AnimalsAPIController : ControllerBase {

      private readonly ApplicationDbContext _context;

      public AnimalsAPIController(ApplicationDbContext context) {
         _context = context;
      }

      // GET: api/AnimalsAPI
      [HttpGet]
      public async Task<ActionResult<IEnumerable<AnimalViewModel>>> GetAnimals() {
         return await _context.Animals
                              .Include(a=>a.Owner)
                              .Select(a => new AnimalViewModel {
                                 Id=a.Id,
                                 Name=a.Name,
                                 Breed=a.Breed,
                                 Specie=a.Species,
                                 Weight=a.Weight,
                                 Photo=a.Photo,
                                 OwnerName=a.Owner.Name
                              })
                              .ToListAsync();
      }

      // GET: api/AnimalsAPI/5
      [HttpGet("{id}")]
      public async Task<ActionResult<AnimalViewModel>> GetAnimal(int id) {
         var animal = await _context.Animals
                                    .Include(a => a.Owner)
                                    .Select(a => new AnimalViewModel {
                                       Id = a.Id,
                                       Name = a.Name,
                                       Breed = a.Breed,
                                       Specie = a.Species,
                                       Weight = a.Weight,
                                       Photo = a.Photo,
                                       OwnerName = a.Owner.Name
                                    })
                                    .Where(a => a.Id == id)
                                    .FirstOrDefaultAsync(); ;

         if (animal == null) {
            return NotFound();
         }

         return animal;
      }

      // PUT: api/AnimalsAPI/5
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public async Task<IActionResult> PutAnimal(int id, Animal animal) {
         if (id != animal.Id) {
            return BadRequest();
         }

         _context.Entry(animal).State = EntityState.Modified;

         try {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException) {
            if (!AnimalExists(id)) {
               return NotFound();
            }
            else {
               throw;
            }
         }

         return NoContent();
      }




      // POST: api/AnimalsAPI
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public async Task<ActionResult<Animal>> PostAnimal(Animal animal) {


         _context.Animals.Add(animal);

         await _context.SaveChangesAsync();

         return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
      }





      // DELETE: api/AnimalsAPI/5
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteAnimal(int id) {
         var animal = await _context.Animals.FindAsync(id);
         if (animal == null) {
            return NotFound();
         }

         _context.Animals.Remove(animal);
         await _context.SaveChangesAsync();

         return NoContent();
      }

      private bool AnimalExists(int id) {
         return _context.Animals.Any(e => e.Id == id);
      }
   }
}
