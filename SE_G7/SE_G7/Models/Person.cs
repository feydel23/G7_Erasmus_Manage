using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_G7.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set;}    
        public string Phone { get; set; }
        public string Home_university { get; set; }
        public string Faculty_address { get; set; }
        public string Field_of_study { get; set; }



        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
