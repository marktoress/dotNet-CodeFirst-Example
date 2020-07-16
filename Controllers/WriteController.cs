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
        public string SaveDataDB([FromBody] User user)
        {
            // Присваивание объекту Person значений из объекта User 
            Person person = new Person 
            {
                Name = user.Name,
                Age = Convert.ToInt32(user.Age) // Преобразуем user.age в число, т.к. person.age 
            };                                  // имеет числовой тип данных

            if(person != null && person.Name != null)
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

        [HttpGet]
        public IQueryable GetData()
        {
            var persons = db.Persons.Where(person => person.PersonId > 0);
            return persons;
        }

    }
}
