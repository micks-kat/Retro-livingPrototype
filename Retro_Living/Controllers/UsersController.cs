using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retro_Living.Models;

namespace Retro_Living.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RetroLivingContext _context;

        public UsersController(RetroLivingContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.user_id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.user_id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.user_id == id);
        }




        [HttpGet("Login")]
        public async Task<ActionResult<dynamic>> Login([FromBody]User user)
        {
            try
            {

                var check = _context.User.Any(e => e.user_email_address == user.user_email_address && e.user_password == user.user_password);

                if (check == false)
                {
                    return false;
                }
                else
                {
                    var checkUser = await _context.User.FirstOrDefaultAsync<User>(e => e.user_email_address == user.user_email_address);

                    return checkUser;
                }


            }
            catch (NullReferenceException e)
            {

                Console.WriteLine(e.StackTrace);

                return null;
            }


        }

        [HttpPost("Register")]
        public async Task<ActionResult<dynamic>> Register([FromBody]User user)
        {
            var checkUser = _context.User.Any(e => e.user_email_address == user.user_email_address);

            if (checkUser == true)
            {
                return false;
            }
            else
            {

                try
                {

                    _context.User.Add(user);
                    await _context.SaveChangesAsync();

                    return user;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return null;
                }

            }
        }


        // GET: api/Users
        [HttpGet("ReadUser")]
        public async Task<ActionResult<dynamic>> ReadUser([FromBody]User user)
        {
            try
            {

                var checkUser = _context.User.Any(e => e.user_email_address == user.user_email_address);

                if (checkUser == true)
                {
                    var readUser = await _context.User.FirstOrDefaultAsync<User>(e => e.user_email_address == user.user_email_address);
                    return readUser;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;

            }


        }


        [HttpPost("UpdateUser")]
        public async Task<ActionResult<dynamic>> UpdateUser([FromBody]User user)
        {
            try
            {

                var database = await _context.User.FirstOrDefaultAsync<User>(e => e.user_email_address == user.user_email_address);

                if (database != null)
                {
                    database.user_first_name = user.user_first_name;
                    database.user_last_name = user.user_last_name;
                    database.user_gender = user.user_gender;
                    database.user_dob = user.user_dob;
                    database.user_nationality = user.user_nationality;
                    database.user_email_address = user.user_email_address;
                    database.user_contacts = user.user_contacts;
                    database.user_password = user.user_password;
                    database.user_address = user.user_address;


                    await _context.SaveChangesAsync();

                }

                return database;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }



        }



    }
}
