﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProchaskaHouseAPI.Models
{
    public class ShoppingListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Checked { get; set; }

    }
}