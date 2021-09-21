﻿using NotAPlanetRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAPlanetRover.Controllers
{
    public class RoverController : IRoverController
    {
        public RoverController(IRover rover)
        {
            m_rover = rover;
        }

        ///<inheritdoc/>
        public void Navigate(string commands)
        {
            //TODO
        }

        ///<inheritdoc/>
        public Position GetRoverPosition()
        {
            return m_rover.Position;
        }

        private IRover m_rover;
    }
}