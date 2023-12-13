
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;



namespace BookStoreAPI.Entities;


[ApiController]
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
    public async Task<ActionResult<List<GenreDto>>> GetGenres()
    {
        var genres = await _dbContext.Genres.ToListAsync();
        var genreDtos = _mapper?.Map<List<GenreDto>>(genres);
        return Ok(genreDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenre(int id)
    {
        GenreDto? genre = await _dbContext.Genres.FindAsync(id);

        if (genre == null)
        {
            return NotFound();
        }

        var genreDto = _mapper?.Map<GenreDto>(genre);
        return Ok(genreDto);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(GenreDto))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<GenreDto>> PostGenre([FromBody] GenreDto genreDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var genre = _mapper?.Map<GenreDto>(genreDto);

        if (genre != null)
        {
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
        }

        var createdGenreDto = _mapper?.Map<GenreDto>(genre);
        return CreatedAtAction(nameof(GetGenre), new { id = createdGenreDto?.Id }, createdGenreDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutGenre(int id, [FromBody] GenreDto updatedGenreDto)
    {
        GenreDto? existingGenre = await _dbContext.Genres.FindAsync(id);
        if (existingGenre == null)
        {
            return NotFound();
        }

        if (_mapper != null)
        {
            _mapper.Map(updatedGenreDto, existingGenre);
        }

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        GenreDto? existingGenre = await _dbContext.Genres.FindAsync(id);
        if (existingGenre == null)
        {
            return NotFound();
        }

        _dbContext.Genres.Remove(existingGenre);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}