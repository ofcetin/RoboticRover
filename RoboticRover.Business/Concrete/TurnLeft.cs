using RoboticRover.Business.Abstract;
using RoboticRover.Data.Entity;
using RoboticRover.Data.Enum;

namespace RoboticRover.Business.Concrete
{
    public class TurnLeft : IRoverStepService
    {
        public Coordinates DoJob(Coordinates coordinates)
        {
            switch (coordinates.Directions)
            {
                case Directions.North:
                    coordinates.Directions = Directions.West;
                    break;

                case Directions.East:
                    coordinates.Directions = Directions.North;
                    break;

                case Directions.South:
                    coordinates.Directions = Directions.East;
                    break;

                case Directions.West:
                    coordinates.Directions = Directions.South;
                    break;
            }
            return coordinates;
        }
    }
}
