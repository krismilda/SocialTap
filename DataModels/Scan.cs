using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class Scan
    {
        public int Id { get; set; }
        public String Username { get; set; } //todo pakeist i User ir permigruot duombazej
        public DateTime Date { get; set; }
        public Restaurant Place { get; set; }
        public int Percentage { get; set; }
    }
}
