using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discgolf.Shared
{
    public class Score
    {
        public string Date { get; set; } = DateTime.Today.ToString("D");
        public int Hole { get; set; }
        public int Katherine { get; set; }
        public int Robert { get; set; }

    }
}