using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class New
    {
        public int Id { get; set; }
        public SocialTapUser User { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
