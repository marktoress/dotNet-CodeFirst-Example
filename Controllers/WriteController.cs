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
       // List<Person> list = new List<Person>();

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
            //list = db.Persons.Where(person => person.PersonId > 0).ToList();
            //List<Person> newList = new List<Person>();

            //int k = list.Count - 1;
            //for(int i = k; i > -1; i--)
            //{
            //    if (i == k - 10)
            //    {
            //        break;
            //    }
            //    newList.Add(list[i]);
            //}

            return db.Persons.OrderByDescending(p => p.PersonId).Take(3);

            
        }

    }
}
