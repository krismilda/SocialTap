﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMasterDetail
{
    public class Tweet
    {
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public int FavoriteCount { get; set; }
    }
}
