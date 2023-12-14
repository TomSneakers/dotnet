using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;


namespace BookStoreAPI.Entities;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper? _mapper;

    public PublisherController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Publisher>>> GetPublishers()
    {
        var publishers = await _dbContext.Publishers.ToListAsync();
        return Ok(publishers);
    }
    // GET: api/<PublisherController>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublisherById(int id)
    {
        // Vérifiez si le publisher existe dans la base de données
        Publisher? publisher = await _dbContext.Publishers.Include(a => a.Books).FirstOrDefaultAsync(b => b.Id == id);

        if (publisher == null)
        {
            return NotFound();
        }

        var publisherDto = _mapper?.Map<PublisherDto>(publisher); // Vérifier la nullité de _mapper
        if (publisherDto == null)
        {
            return BadRequest();
        }

        return Ok(publisherDto);
    }
    //Post
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(PublisherCreateRequestDto))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Publisher>> PostPublisher([FromBody] PublisherCreateRequestDto publisherCreateRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var publisher = _mapper?.Map<Publisher>(publisherCreateRequestDto); // Convert PublisherCreateRequestDto to Publisher

        if (publisher == null)
        {
            return BadRequest();
        }

        await _dbContext.Publishers.AddAsync(publisher);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(PostPublisher), new { id = publisher.Id }, publisherCreateRequestDto);
    }

    //Put
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePublisher(int id, Publisher publisher)
    {
        if (id != publisher.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(publisher).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
    //Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePublisher(int id)
    {
        var publisher = await _dbContext.Publishers.FindAsync(id);
        if (publisher is null)
        {
            return NotFound();
        }
        _dbContext.Publishers.Remove(publisher);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}



