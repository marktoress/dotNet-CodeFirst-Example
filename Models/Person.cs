using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Person
    {
        [Key]
        public int  PersonId {get; set;}
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
