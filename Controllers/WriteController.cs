using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeFirst.Controllers
{
    public class WriteController : Controller
    {
        PersonContext db;
       public WriteController(PersonContext context)
       {
            db = context;
       }
        [HttpPost]
        public string SaveDataDB([FromBody] object user) // объект user упакован в тип данных object
        {
            // Десериализация объекта user из json формата к модели Person
            Person person = JsonConvert.DeserializeObject<Person>(user.ToString());

            if(person != null && person.Name != null)
            {
                db.Persons.Add(new Person
                {
                    Name = person.Name,
                    Age = person.Age
                });

                db.SaveChanges();
                return "1";
            }
            else
            {
                return "0";
            }
        }

        [HttpGet]
        public IQueryable GetData()
        {
            var persons = db.Persons.Where(person => person.PersonId > 0);
            return persons;
        }

    }
}
