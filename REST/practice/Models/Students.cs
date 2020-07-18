using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Students
    {
        [Key]
        public int Student_Id { get; set; }
        public int Group_Id { get; set; }
        public string Student_Name { get; set; }

    }
}
