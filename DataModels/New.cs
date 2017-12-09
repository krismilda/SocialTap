using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class New
    {
        [ForeignKey("SocialTapUser")]
        public string User_Id { get; set; }
        public virtual SocialTapUser SocialTapUser { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        [Key]
        public int Id {get; set;}
    }
}
