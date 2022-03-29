using Microsoft.Extensions.DependencyInjection;
using RoboticRover.Business.Abstract;
using RoboticRover.Business.Concrete;
using RoboticRover.Core.Enum;
using RoboticRover.Data.Enum;
using System;

namespace RoboticRover.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the surface area coordinates");
            var surfacePoints = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the first coordinates of the rover");
            var roverFirstLocation = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the steps that the rover will follow");
            var steps = Console.ReadLine();


            RoverManager roverManager = new RoverManager(new RoverMovementManager());

            var coordinates = roverManager.ExecuteRoverStep(surfacePoints, roverFirstLocation, steps);


            if (coordinates != null)
                Console.WriteLine(coordinates.PointX + " " + coordinates.PointY + " " + coordinates.Directions.GetKey());
            else
                Console.WriteLine("Entered the wrong steps");
         }
    }
}
