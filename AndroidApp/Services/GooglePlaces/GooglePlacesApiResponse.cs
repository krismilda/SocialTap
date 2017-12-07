﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp
{
    public struct GooglePlacesApiResponse
    {
        public List <Object> html_attributions { get; set; }
        public List<LocationData> results { get; set; }
        public string status { get; set; }
    }
}
