﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Game.Fabrique
{
    public class Zone : ZoneAbstrait
    {
        public int row { get; set; }
        public int column { get; set; }

        public Zone() : base() { }
    }
}
