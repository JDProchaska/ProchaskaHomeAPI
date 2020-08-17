using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProchaskaHouseAPI.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Person { get; set; }
        public DateTime Added { get; set; }
        public DateTime Done { get; set; }
    }
}