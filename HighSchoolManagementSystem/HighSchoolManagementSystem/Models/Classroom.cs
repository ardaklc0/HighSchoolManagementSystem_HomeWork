﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student>? Students { get; set; } = new List<Student>() { };
    }  
}
