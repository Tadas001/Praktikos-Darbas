using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;
using WebApi.Requests;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UsersDbContext _dbContext;

    public UsersController(ILogger<UsersController> logger, UsersDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetUsers")]
    [ProducesResponseType(typeof(IList<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var users = await _dbContext.Users.ToListAsync();

            return Ok(users);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Get failed");
            
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(UserRequest request)
    {
        try
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                Email = request.Email
            };

            user = (await _dbContext.Users.AddAsync(user)).Entity;
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Get failed");
            
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(int id, UserRequest request)
    {
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest(new { Error = "User not exist" });
            }

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.BirthDate = request.BirthDate;
            user.Email = request.Email;

            user = _dbContext.Users.Update(user).Entity;
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Get failed");
            
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return Ok();
            }
            
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Get failed");
            
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}