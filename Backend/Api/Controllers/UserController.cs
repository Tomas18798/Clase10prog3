using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly Context _context;

    public UserController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> Get()
    {
        var users = await _context.Users.Select(x =>
            new UserModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Name = x.Name,
                LastName = x.LastName,
                Age = x.Age,
                DateCreated = x.DateCreated,
                Address = new AddressModel
                {
                    Direction = x.Address.Direction,
                    ProvinceId = x.Address.ProvinceId,
                    ProvinceName = x.Address.Province.Name
                }
            }).ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> Get(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No se encontró el User con el id {id}");
        }
        var userModel = new UserModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Name = user.Name,
            LastName = user.LastName,
            Age = user.Age,
            DateCreated = user.DateCreated,
            Address = new AddressModel { Direction = user.Address.Direction, ProvinceId = user.Address.ProvinceId }
        };
        return Ok(userModel);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> Create(UserCreateModel user)
    {
        var newUser = new User
        {
            UserName = user.UserName,
            Password = user.Password,
            Name = user.Name,
            LastName = user.LastName,
            Address = new Address { Direction = user.Address.Direction, ProvinceId = user.Address.ProvinceId },
            Age = user.Age,
            DateCreated = DateTime.UtcNow
        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        var userModel = new UserModel
        {
            Id = newUser.Id,
            UserName = newUser.UserName,
            Name = newUser.Name,
            LastName = newUser.LastName,
            Age = newUser.Age,
            DateCreated = newUser.DateCreated,
            Address = new AddressModel
            {
                Direction = newUser.Address.Direction,
                ProvinceId = newUser.Address.ProvinceId,
                ProvinceName = newUser.Address.Province?.Name
            }
        };
        return Ok(userModel);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> Update(int id, UserCreateModel request)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No se encontró la persona con el id {id}");
        }

        user.UserName = request.UserName;
        user.Password = request.Password;
        user.Name = request.Name;
        user.LastName = request.LastName;
        user.Address = new Address { Direction = request.Address.Direction, ProvinceId = request.Address.ProvinceId };
        user.Age = user.Age;


        _context.Update(user);
        await _context.SaveChangesAsync();

        var userModel = new UserModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Name = user.Name,
            LastName = user.LastName,
            Age = user.Age,
            DateCreated = user.DateCreated,
            Address = new AddressModel
            {
                Direction = user.Address.Direction,
                ProvinceId = user.Address.ProvinceId,
                ProvinceName = user.Address.Province?.Name
            }
        };
        return Ok(userModel);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserModel>> Login(UserLoginModel userLoginModel)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password);
        if (user == null)
        {
            return Unauthorized("Usuario o Contraseña incorrecta");
        }

        var userModel = new UserModel
        {
            Id = user.Id,
            UserName = user.UserName,
            Name = user.Name,
            LastName = user.LastName,
            Age = user.Age,
            DateCreated = user.DateCreated,
            Address = new AddressModel
            {
                Direction = user.Address.Direction,
                ProvinceId = user.Address.ProvinceId,
                ProvinceName = user.Address.Province?.Name
            }
        };
        return Ok(userModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No se encontró el User con el id {id}");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok();
    }
}