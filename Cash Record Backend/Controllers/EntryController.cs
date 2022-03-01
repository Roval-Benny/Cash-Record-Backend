using Cash_Record_Backend.Business;
using Cash_Record_Backend.Data.Entities;
using Cash_Record_Backend.Data.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cash_Record_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _service;
        private readonly UserManager<User> _userManager;

        public EntryController(IEntryService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        // GET: api/<EntryController>
        [HttpGet]
        public IActionResult GetAllEntries()
        {
            try
            {

                return Ok(_service.GetAllEntry(User.Identity.Name));
            }catch(EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EntryController>/5
        [HttpGet("{month}/{year}")]
        public IActionResult GetAllEntriesByMonth(int month,int year)
        {
            try
            {
                return Ok(_service.GetAllEntrieByMonth(User.Identity.Name, month, year));
            }catch(EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(InvalidMonthException ex)
            {
                return BadRequest(ex.Message.ToString());
            }catch(InvalidYearException ex)
            {
                return BadRequest(ex.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{year}")]
        public IActionResult GetAllEntriesByYear(int year)
        {
            try
            {
                return Ok(_service.GetAllEntriesByYear(User.Identity.Name,year));
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch (InvalidYearException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // POST api/<EntryController>
        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] Entry entry)
        {
            try
            {
                entry.User = await _userManager.FindByNameAsync(User.Identity.Name);
                return Ok(_service.AddEntry(entry));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
