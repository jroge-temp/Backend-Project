using Microsoft.AspNetCore.Mvc;

namespace Backend_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        [HttpGet]
        public List<Person> GetPeople()
        {
            using (var db = new PeopleDataContext())
            {
                return db.People.ToList();
            }
        }

        [HttpPost]
        public Person CreateAPerson([FromBody] Person person)
        {
            using (var db = new PeopleDataContext())
            {
                db.People.Add(person);
                db.SaveChanges();
                return person;
            }
        }
    }
}