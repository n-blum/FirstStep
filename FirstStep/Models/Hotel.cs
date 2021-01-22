using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstStep.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Sterne { get; set; }
        public int RegionId { get; set; }
        public Detail Detail { get; set; }
    }
}