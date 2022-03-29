using RoboticRover.Business.Abstract;
using RoboticRover.Data.Entity;
using RoboticRover.Data.Enum;

namespace RoboticRover.Business.Concrete
{
    public class TurnRight : IRoverStepService
    {
        public Coordinates DoJob(Coordinates coordinates)
        {
            switch (coordinates.Directions)
            {
                case Directions.North:
                    coordinates.Directions = Directions.East;
                    break;

                case Directions.East:
                    coordinates.Directions = Directions.South;
                    break;

                case Directions.South:
                    coordinates.Directions = Directions.West;
                    break;

                case Directions.West:
                    coordinates.Directions = Directions.North;
                    break;
            }
            return coordinates;
        }
    }
}
