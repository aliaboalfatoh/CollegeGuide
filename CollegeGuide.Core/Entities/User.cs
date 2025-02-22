using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollegeGuide.Core.Entities
{
    public class User 
    {
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public List<Recommendation> Recommendations { get; set; } = new();

    }
}

