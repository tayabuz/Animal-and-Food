using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public class Food
    {
        public string NameFood { get; set; }
        public Uri ImagePathFood { get; set; }
        public string Description { get; set; }

        public enum Type
        {
            Meat, Fish, Sweets
        };

        public Type foodType;

    }
}
