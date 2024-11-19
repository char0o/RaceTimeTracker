using Microsoft.AspNetCore.Mvc;
using RacetimeTrackerAPI.Controllers.Viewmodels;
using RacetimeTrackerAPI.Services;

namespace RacetimeTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly PasswordHashingService _passwordHashingService;

    public UserController(UserService userService)
    {
        _userService = userService;
        _passwordHashingService = new PasswordHashingService();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<UserVM>> Get()
    {
        return Ok(this._userService.GetUsers()
            .Select(u => new UserVM(u)));
    }

    [HttpGet("{id}")]
    public ActionResult<UserVM> Get(int id)
    {
        DTOs.User? user = this._userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(new UserVM(user));
    }

    [HttpPost]
    public ActionResult Post([FromBody] UserVM userVm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        userVm.Password = this._passwordHashingService.HashPassword(userVm.ToDTO(), userVm.Password);
        int id = this._userService.AddUser(userVm.ToDTO());
        return this.Created(string.Empty, new { id = id });
    }
}