﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Theme
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Article Article { get; set; }
    }
}
