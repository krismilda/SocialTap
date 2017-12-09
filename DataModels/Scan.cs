using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class Scan
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SocialTapUser")]
        public string User_Id { get; set; }
        public SocialTapUser SocialTapUser { get; set; } 
        public DateTime Date { get; set; }

        [ForeignKey("Restaurant")]
        public int Place_Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public int Percentage { get; set; }
        public double Millimeters { get; set; }
        public string Drink { get; set; }
        public double Price { get; set; }
    }
}
