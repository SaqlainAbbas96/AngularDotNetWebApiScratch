using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string Employee { get; set; }
        public string ExperienceYear { get; set; }
        public string ExperienceDescription { get; set; }
    }
}