﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Model
{
    public class StudentContact
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public Student Student { get; set; }
        public long StudentId { get; set; }
    }
}
