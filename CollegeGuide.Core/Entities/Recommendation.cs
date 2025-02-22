using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Entities
{
    public class Recommendation : BaseEntity
    {
        public int Rec_Id { get; set; }
        public float Score { get; set; }
        public string Section { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
        public int Col_Id { get; set; }
        public int Uni_Id { get; set; }
        public College College { get; set; }
    }
}
