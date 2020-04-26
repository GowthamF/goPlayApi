using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goPlayApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GoPlayDBContext _context;

        public UserController(GoPlayDBContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var _user = await _context.Users.Where(f => f.EmailAddress == user.EmailAddress && f.Password == user.Password).FirstOrDefaultAsync();

            if(_user != null)
            {
                return Ok(_user);
            }

            return BadRequest("Incorrect User Name or Password");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var _user = await _context.Users.Where(f =>f.EmailAddress == user.EmailAddress).FirstOrDefaultAsync();

            if (_user == null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created(Request.Path + $"/{user.UserId}", user);
            }

            return BadRequest("User Name or Email Address already exists");
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(User user,int id)
        {
            var _user = await _context.Users.Where(f => f.UserId == id).FirstOrDefaultAsync();

            if (_user != null)
            {
                _user.UserFirstName = user.UserFirstName;
                _user.UserLastName = user.UserLastName;
                _user.Password = user.Password;
                await _context.SaveChangesAsync();
                return Ok(_user);
            }

            return NotFound("User does not exists");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var _user = await _context.Users.Where(f => f.UserId == id).FirstOrDefaultAsync();

            if (_user != null)
            {
                _context.Users.Remove(_user);
                await _context.SaveChangesAsync();
                return Ok(_user);
            }

            return NotFound("User does not exists");
        }

    }
}