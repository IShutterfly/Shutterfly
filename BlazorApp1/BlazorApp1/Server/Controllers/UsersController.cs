using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
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
    }
}