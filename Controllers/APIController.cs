using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{                                // маршрутизация Api
    [Route("api/apiController")]
    [ApiController]
    public class APIController : ControllerBase
    {
        PersonContext db;
        public APIController(PersonContext context)
        {
            db = context;
        }

        [Route("joker")]
        [HttpPost]
        public string Post([FromBody] User user)
        {
            Person person = new Person
            {
                Name = user.Name,
                Age = Convert.ToInt32(user.Age) // Преобразуем user.age в число, т.к. person.age 
            };                                  // имеет числовой тип данных

            if (person != null && person.Name != null)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return "1";
            }
            else
            {
                return "0";
            }
        }

        [HttpPost]
        public string Post()
        {
            return null;
        }
    }
}
