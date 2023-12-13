using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<List<Genre>>> GetGenres()
    {
        var genres = await _dbContext.Genres.ToListAsync();
        return Ok(genres);
    }
    // GET: api/<GenreController>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        // Vérifiez si le genre existe dans la base de données
        Genre? genre = await _dbContext.Genres.FindAsync(id);

        if (genre == null)
        {
            return NotFound();
        }

        var genreDto = _mapper?.Map<GenreDto>(genre); // Vérifier la nullité de _mapper
        if (genreDto == null)
        {
            return BadRequest();
        }

        return Ok(genreDto);
    }
    //Post
    [HttpPost]
    public async Task<ActionResult<Genre>> CreateGenre(Genre genre)
    {
        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
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
