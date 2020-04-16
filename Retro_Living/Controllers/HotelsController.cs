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
    public class HotelsController : ControllerBase
    {
        private readonly RetroLivingContext _context;

        public HotelsController(RetroLivingContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return await _context.Hotel.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.h_id)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.h_id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.h_id == id);
        }



        [HttpPost("RegisterHotel/{userid}")]
        public async Task<ActionResult<dynamic>> RegisterHotel([FromBody]Hotel hotel, int userid)
        {
            try
            {

                var checkUser = await _context.User.FirstOrDefaultAsync<User>(e => e.user_id.Equals(userid));

                Hotel createHotel = new Hotel();

                _context.Hotel.Add(hotel);
                await _context.SaveChangesAsync();

                createHotel = await _context.Hotel.FirstOrDefaultAsync<Hotel>(e => e.h_name.Equals(hotel.h_name));

                User_Hotel userHotel = new User_Hotel();

                userHotel.user_id = userid;
                userHotel.h_id = createHotel.h_id;

                _context.User_Hotel.Add(userHotel);
                await _context.SaveChangesAsync();

                return createHotel;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }


        }

        [HttpPost("UpdateHotel")]
        public async Task<ActionResult<dynamic>> UpdateHotel([FromBody]Hotel hotel)
        {
            try
            {

                var gethotel = await _context.Hotel.FirstOrDefaultAsync<Hotel>(e => e.h_name == hotel.h_name);

                if (gethotel != null)
                {
                    gethotel.h_name = hotel.h_name;
                    gethotel.h_contacts = hotel.h_contacts;
                    gethotel.h_email_address = hotel.h_email_address;
                    gethotel.h_description = hotel.h_description;
                    gethotel.h_address = hotel.h_address;

                    await _context.SaveChangesAsync();
                }

                return gethotel;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }


        [HttpGet("GetHotel")]
        public async Task<ActionResult<Hotel>> GetHotel([FromBody]Hotel hotel)
        {
            try
            {

                var hotels = await _context.Hotel.FirstOrDefaultAsync<Hotel>(e => e.h_name == hotel.h_name);

                if (hotel == null)
                {
                    return NotFound();
                }

                return hotels;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }



    }
}
