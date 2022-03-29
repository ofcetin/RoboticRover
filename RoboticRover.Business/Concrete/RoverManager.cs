using RoboticRover.Business.Abstract;
using RoboticRover.Core.Enum;
using RoboticRover.Data.Entity;
using RoboticRover.Data.Enum;
using System.Collections.Generic;

namespace RoboticRover.Business.Concrete
{
    public class RoverManager : IRoverService
    {
        private readonly IRoverMovementService roverMovementService;
        public RoverManager(IRoverMovementService roverMovementService)
        {
            this.roverMovementService = roverMovementService;
        }

        public Coordinates ExecuteRoverStep(string[] surfacePoints, string[] firstLocation, string steps)
        {
            var points = new List<int>();
            foreach (var m in surfacePoints)
            {
                points.Add(Convert.ToInt32(m));
            }
            var coordinates = new Coordinates();
            coordinates.PointX = Convert.ToInt32(firstLocation[0]);
            coordinates.PointY = Convert.ToInt32(firstLocation[1]);
            coordinates.Directions = EnumExtensions.EnumParseKey<Directions>(firstLocation[2]);

            IRoverStepService roverStepService;
            List<string> stepsList = new List<string>();
            foreach (var item in steps)
            {
                stepsList.Add(item.ToString());
            }

            foreach (var dir in stepsList)
            {
                switch (EnumExtensions.EnumParseKey<Steps>(dir))
                {
                    case Steps.Left:
                        roverStepService = new TurnLeft();
                        break;

                    case Steps.Right:
                        roverStepService = new TurnRight();
                        break;

                    case Steps.Move:
                        roverStepService = new MoveOn(points);
                        break;

                    default:
                        return null;
                }
                var c = this.roverMovementService.DoMovement(roverStepService, coordinates);

                if (c == null)
                    return null;

                coordinates.Directions = c.Directions;
                coordinates.PointX = c.PointX;
                coordinates.PointY = c.PointY;
            }
            return coordinates;
        }
    }
}
