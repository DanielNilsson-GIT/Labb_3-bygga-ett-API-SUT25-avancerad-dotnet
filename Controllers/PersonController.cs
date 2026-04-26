using Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO.InterestDTO;
using static Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO.WebsiteDTO;

namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly InterestDBContext _ctx;

        //Konstruktor för min context
        public PersonController(InterestDBContext ctx)
        {

            _ctx = ctx;
        }


        [HttpGet(Name = "GetAllPersons")]
        public async Task<ActionResult<IEnumerable<PersonDTO.CreatePersonRequest>>> GetAll()
        {
            var result = await _ctx.persons
                .Select(p => new PersonDTO.CreatePersonRequest
                {
                    Name = p.FirstName + " " + p.LastName,
                    Phone = p.Phone

                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("GetInterestsByPersonId/{id}", Name = "GetInterestsByPersonId")]
        public async Task<ActionResult<InterestDTO>> GetInterestsByPersonId(int id)
        {
            var result = await _ctx.persons
        .Where(p => p.Id == id)
        .Select(p => new InterestDTO.CreateInterestByPersonRequest
        {
            PersonId = p.Id,
            PersonName = p.FirstName + " " + p.LastName,
            Interests = p.PersonInterests.Select(pi => pi.Interest.Title).ToList()
        })
        .FirstOrDefaultAsync();  //First or default eftersom jag hämtar en enskild person

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        //Hämta alla länkar kopplade till en specifik person

        [HttpGet("GetLinksByPersonId/{id}", Name = "GetLinksByPersonId")]

        public async Task<ActionResult<WebsiteDTO>> GetLinksByPersonId(int id)
        {
            var result = await _ctx.persons.Where(p => p.Id == id)
                .Select(p => new WebsiteDTO.WebsitesByPerson
                {
                    PersonId = id,
                    PersonName = p.FirstName + " " + p.LastName,
                    Websites = p.Websites.Select(pw => pw.WebSiteURL).ToList()

                }).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        //Koppla en person till ett nytt intresse
        [HttpPost("AddNewInterest/Person{id}", Name = "AddNewInterest")]
        public async Task<ActionResult<Interest>> AddNewInterest(int id, AddNewIntererstRequest newInterest)
        {
            var personToConnect = await _ctx.persons.FindAsync(id);

            if (personToConnect == null)
            {
                return NotFound();
            }

            var interestToAdd = new Interest
            {

                Title = newInterest.Title,
                Description = newInterest.Descripiton,

            };

            //Skapa ny rad i personinterst
            var personInterestRow = new PersonInterest
            {
                InterestId = interestToAdd.Id,
                Interest = interestToAdd,
                Person = personToConnect,
                PersonId = personToConnect.Id

            };



            await _ctx.personInterests.AddAsync(personInterestRow);
            await _ctx.SaveChangesAsync();

            return Ok(newInterest);

        }
        //Lägga till nya länkar för en specifik person och ett specifikt intresse
        [HttpPost("AddNewLink/{PersonId}/{InterestId}", Name = "AddNewLink")]
        public async Task<ActionResult<Website>> AddnewLink(int PersonId, int InterestId, AddNewWebsiteRequest newWebSite)
        {
            //Hittar person och intresse för validering.
            var person = await _ctx.persons.Where(p => p.Id == PersonId).FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound("Person not found");
            }

            var interest = await _ctx.interests.Where(i => i.Id == InterestId).FirstOrDefaultAsync();

            if (interest == null)
            {
                return NotFound("Interest not found");
            }

            var WebsiteToAdd = new Website
            {

                WebSiteURL = newWebSite.WebsiteURL,
                InterestId = InterestId,
                PersonId = PersonId

            };


            await _ctx.websites.AddAsync(WebsiteToAdd);
            await _ctx.SaveChangesAsync();

            //ReturDTO för att undkomma evighetsloop-problematiken. 

            var response = new WebsiteResponseDTO
            {
                Id = WebsiteToAdd.Id,
                InterestId = WebsiteToAdd.InterestId,
                PersonId = WebsiteToAdd.PersonId,
                WebsiteURL = WebsiteToAdd.WebSiteURL

            };

            return Ok(response);

        }
    }






}


