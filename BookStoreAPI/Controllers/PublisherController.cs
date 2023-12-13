using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Entities;


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
    public async Task<ActionResult<Publisher>> GetPublisherById(int id)
    {
        var publisher = await _dbContext.Publishers.FindAsync(id);
        if (publisher is null)
        {
            return NotFound();
        }
        return Ok(publisher);
    }
    //Post
    [HttpPost]
    public async Task<ActionResult<Publisher>> CreatePublisher(Publisher publisher)
    {
        await _dbContext.Publishers.AddAsync(publisher);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);
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



