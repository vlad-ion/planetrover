﻿
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotAPlanetRover.Controllers;

namespace NotAPlanetRover
{
    class Worker : BackgroundService
    {
        public Worker(IRoverController roverController, ILogger<Worker> logger)
        {
            m_roverController = roverController;
            m_logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancelToken)
        {
            while (!cancelToken.IsCancellationRequested)
            {
                var position = m_roverController.GetRoverPosition();
                m_logger.LogInformation($"Rover now at {position}");

                //Not really needed, just to keep some delay between command lines
                await Task.Delay(100, cancelToken);

                Console.WriteLine("Insert command sequence and press enter:");
                string? commands = Console.ReadLine();
                m_roverController.Navigate(commands ?? "");
            }
        }

        private readonly IRoverController m_roverController;

        private ILogger<Worker> m_logger;
    }
}
