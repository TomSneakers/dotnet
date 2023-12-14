using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
namespace BookStoreAPI.Entities;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class GenreController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper? _mapper;

    public GenreController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Genre>>> GetGenres()
    {
        var genres = await _dbContext.Genres.ToListAsync();
        return Ok(genres);
    }
    // GET: api/<GenreController>
    [HttpGet("{id}")]
    public async Task<ActionResult<GenreDto>> GetGenreById(int id)
    {
        var genre = await _dbContext.Genres
            .Where(g => g.Id == id)
            .ProjectTo<GenreDto>(_mapper?.ConfigurationProvider)
            .FirstOrDefaultAsync();

        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }
    //Post
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(GenreCreateRequestDto))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Genre>> PostGenre([FromBody] GenreCreateRequestDto genreCreateRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var genre = _mapper?.Map<Genre>(genreCreateRequestDto); // Convert AuthorCreateRequestDto to Author

        if (genre == null)
        {
            return BadRequest();
        }

        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(PostGenre), new { id = genre.Id }, genreCreateRequestDto);
    }

    //Put
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateGenre(int id, Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(genre).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    //Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenre(int id)
    {
        var genre = await _dbContext.Genres.FindAsync(id);
        if (genre is null)
        {
            return NotFound();
        }
        _dbContext.Genres.Remove(genre);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}