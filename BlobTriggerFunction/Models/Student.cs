using System;
using System.Collections.Generic;
using System.Text;

namespace BlobTriggerFunction.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddMinutes { get; set; }
    }
}
