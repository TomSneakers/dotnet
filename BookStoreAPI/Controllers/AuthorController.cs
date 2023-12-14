
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStoreAPI.Entities
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper? _mapper;

        public AuthorController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return Ok(authors);
        }


        // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
        // ActionResult designe le type de retour de la méthode de controller d'api



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            // Vérifiez si le livre existe dans la base de données
            var author = await _dbContext.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            var authorDto = _mapper?.Map<AuthorDto>(author); // Vérifier la nullité de _mapper
            if (authorDto == null)
            {
                return BadRequest();
            }

            return Ok(authorDto);
        }

        //Methode Post
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Author>> PostAuthor([FromBody] AuthorCreateRequestDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var author = _mapper?.Map<Author>(authorDto); // Convert AuthorCreateRequestDto to Author
            
            if (author == null)
            {
                return BadRequest();
            }
            
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        //Methode Put
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(author).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        //Methode Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async

        Task<IActionResult> DeleteAuthor(int id)
        {
            Author? author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _dbContext.Authors.Any(e => e.Id == id);
        }
    }
}