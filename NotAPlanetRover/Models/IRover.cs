using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAPlanetRover.Models
{
    public interface IRover
    {
        //Current rover position
        public Position Position { get; }
    }
}
