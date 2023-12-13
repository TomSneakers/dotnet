
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
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            var authorDtos = _mapper?.Map<List<AuthorDto>>(authors); // Vérifier la nullité de _mapper
            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            AuthorDto? author = await _dbContext.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorDto = _mapper?.Map<AuthorDto>(author); // Vérifier la nullité de _mapper
            return Ok(authorDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthorDto>> PostAuthor([FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = _mapper?.Map<AuthorDto>(authorDto); // Vérifier la nullité de _mapper
            if (author == null)
            {
                return BadRequest();
            }

            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

            var createdAuthorDto = _mapper?.Map<AuthorDto>(author); // Vérifier la nullité de _mapper
            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthorDto?.Id }, createdAuthorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] AuthorDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _mapper?.Map(authorDto, author); // Vérifier la nullité de _mapper
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

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
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