using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UsersController(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ~UsersController()
        {
            _dbContext.DisposeAsync();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        [HttpPost]
        public User Post(User user) // Create
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChangesAsync();
            
            return user;
        }

        [HttpPut]
        public User Put(User user) // Change
        {
            _dbContext.Entry(user).State = EntityState.Modified;

            _dbContext.SaveChangesAsync();

            return user;
        }
    }
}