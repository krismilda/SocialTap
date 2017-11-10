using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Scan
    {
        public int Id { get; set; }
        public SocialTapUser User { get; set; } 
        public DateTime Date { get; set; }
        public Restaurant Place { get; set; }
        public int Percentage { get; set; }
    }
}
