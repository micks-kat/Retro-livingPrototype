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
    public class RoomsController : ControllerBase
    {
        private readonly RetroLivingContext _context;

        public RoomsController(RetroLivingContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            return await _context.Room.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.room_id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.room_id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.room_id == id);
        }

        [HttpPost("CreateRoom/{hid}")]
        public async Task<ActionResult<dynamic>> CreateRoom([FromBody]Room room, int hid)
        {
           var checkUser = await _context.Hotel.FirstOrDefaultAsync<Hotel>(e => e.h_id.Equals(hid));

            Room createRoom = new Room();

            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            createRoom = await _context.Room.FirstOrDefaultAsync<Room>(e => e.room_number.Equals(room.room_number));

            Hotel_Room hotelRoom = new Hotel_Room();

            hotelRoom.h_id = hid;
            hotelRoom.room_id = createRoom.room_id;

            _context.hotel_rooms.Add(hotelRoom);
            await _context.SaveChangesAsync();

            return createRoom;
        }


        [HttpPost("UpdateRoom")]
        public async Task<ActionResult<dynamic>> UpdateRoom([FromBody]Room room)
        {
            try
            {

                var checkRoom = await _context.Room.FirstOrDefaultAsync<Room>(e => e.room_number == room.room_number);

                if (checkRoom != null)
                {
                    checkRoom.room_number = room.room_number;
                    checkRoom.room_availability = room.room_availability;
                    checkRoom.room_type = room.room_type;

                    await _context.SaveChangesAsync();

                }
                return checkRoom;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }


        }


        [HttpGet("ReadRoom")]
        public async Task<ActionResult<dynamic>> ReadRoom([FromBody]Room room)
        {
            try
            {
                var checkRoom = await _context.Room.FirstOrDefaultAsync<Room>(e => e.room_number == room.room_number);

                if (checkRoom != null)
                {
                    return checkRoom;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }


    }
}
