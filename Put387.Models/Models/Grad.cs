using System;
using System.Collections.Generic;
using System.Text;

namespace Put387.Model.Models
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
