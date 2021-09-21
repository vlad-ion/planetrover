using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NotAPlanetRover.Models;

namespace NotAPlanetRover.Controllers
{
    public class RoverController : IRoverController
    {
        public RoverController(IRover rover, ILogger<RoverController> logger)
        {
            m_rover = rover;
            m_logger = logger;


            m_commands = new Dictionary<char, ICommand>
            {
                { 'f', new Forward() },
                { 'b', new Backward() },
                { 'l', new RotateLeft() },
                { 'r', new RotateRight() }
            };
        }

        ///<inheritdoc/>
        public void Navigate(string commands)
        {
            foreach (char command in commands)
            {
                if (m_commands.TryGetValue(char.ToLowerInvariant(command), out var commandObj))
                {
                    bool couldExecute = commandObj.Execute(m_rover);
                    if (!couldExecute)
                    {
                        //rover encountered an obstacle and stopped moving
                        break;
                    }
                }
                else
                {
                    m_logger.LogWarning($"Invalid command {command} received, skipping.");
                }
            }
        }

        ///<inheritdoc/>
        public Position GetRoverPosition()
        {
            return m_rover.Position;
        }

        ///<inheritdoc/>
        public uint MapHeight { get { return m_rover.MapHeight; } }

        ///<inheritdoc/>
        public uint MapWidth { get { return m_rover.MapWidth; } }

        private IRover m_rover;

        private ILogger<RoverController> m_logger;

        private Dictionary<char, ICommand> m_commands;
    }
}
