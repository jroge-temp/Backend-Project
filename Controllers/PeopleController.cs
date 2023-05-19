using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Backend_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        [HttpGet]
        public List<Person> GetPeople()
        {
            var peopleInMysqlDb = new List<Person>();
            using (var connection = new MySqlConnection("server=localhost;port=3306;database=people;user=root;password=123"))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM people", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var person = new Person
                            {
                                fullname = reader.GetString("fullname"),
                                nickname = reader.GetString("nickname"),
                            };
                            peopleInMysqlDb.Add(person);
                        }
                    }
                }
            }
            return peopleInMysqlDb;
        }

        [HttpPost]
        public Person CreateAPerson([FromBody] Person person)
        {
            using (var connection = new MySqlConnection("server=localhost;port=3306;database=people;user=root;password=123"))
            {
                connection.Open();
                using (var command = new MySqlCommand($"INSERT INTO people(fullname, nickname) VALUES('{person.fullname}', '{person.nickname}')", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return person;

        }
    }
}