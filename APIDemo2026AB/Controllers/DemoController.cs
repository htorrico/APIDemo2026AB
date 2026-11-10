using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo2026AB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        public List<string> GetPeople()
        {

            List<string> people = new List<string>();

            people.Add("Hugo");
            people.Add("Paco");
            people.Add("Luis");

            return people;
        }

        [HttpGet]
        public List<string> GetCountries()
        {

            List<string> countries = new List<string>();

            countries.Add("Perù");
            countries.Add("Brasil");
            countries.Add("Bolivia");

            return countries;
        }




        [HttpPost]
        public string PostPerson()
        {
          
            return "registrado correctamente";
        }

    }
}
