using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWithMySql.Models.Students
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string Gender { get; set; }
        public string E_Mail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Permanent_Address { get; set; }

    }
}
