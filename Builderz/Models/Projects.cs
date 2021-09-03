using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Builderz.Models
{
    public class Projects
    {
        public int Id { get; set; }

        [Display(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [Display(Name = "ProjectType")]
        public string ProjectType { get; set; }


        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
