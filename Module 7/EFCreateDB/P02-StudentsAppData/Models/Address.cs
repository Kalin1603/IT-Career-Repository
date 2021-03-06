﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_StudentsAppData.Models
{
   public class Address
    {
        public Address()
        {
            this.Students = new HashSet<Student>();
            this.Schools = new HashSet<School>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<School> Schools { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
