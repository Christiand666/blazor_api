using Bibliotek_Blazor_API.Data;
using Bibliotek_Blazor_API.Models;
using Bibliotek_Blazor_API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bibliotek_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BibliotekContext _db;
        private LoginVerification _loginVerification;

        public BooksController(BibliotekContext db)
        {
            _db = db;
            _loginVerification = new LoginVerification(db);
        }

        // GET: api/<BooksController>
        [Route("bookGenreSearch")]
        [HttpGet]
        public IEnumerable<Book>? GetBooksByGenre(string genre, string userToken)
        {
            UserToken ut = Newtonsoft.Json.JsonConvert.DeserializeObject<UserToken>(userToken);

            if (_loginVerification.VerifyUserToken(ut))
            {
                var bookList = _db.Books.Where(x => x.Genre == genre).ToList();

                foreach (var b in bookList)
                {
                    var isAlreadyBooked = _db.Bookings.Any(x => x.FK_BookId == b.Id && x.Enddate > DateTime.Now);
                    b.IsBooked = isAlreadyBooked;
                }

                return bookList;
            }
            else
            {
                return null;
            }
        }

        [Route("bookbook")]
        [HttpGet]
        public bool BookBook(int bookId, int bookingPeriod, string userToken)
        {
            UserToken ut = Newtonsoft.Json.JsonConvert.DeserializeObject<UserToken>(userToken);

            try
            {
                if (_loginVerification.VerifyUserToken(ut))
                {
                    var booking = new Booking
                    {
                        FK_BookId = bookId,
                        FK_UserId = ut.UserId,
                        Startdate = DateTime.Now,
                        Enddate = DateTime.Now.AddDays(bookingPeriod)
                    };

                    //Tjekker om den allerede er booket
                    var isAlreadyBooked = _db.Bookings.Any(b => b.FK_BookId == bookId && b.Enddate > DateTime.Now);
                    if (isAlreadyBooked)
                        return false;

                    _db.Bookings.Add(booking);
                    _db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
