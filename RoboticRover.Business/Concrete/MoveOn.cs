using RoboticRover.Business.Abstract;
using RoboticRover.Data.Entity;
using RoboticRover.Data.Enum;

namespace RoboticRover.Business.Concrete
{
    public class MoveOn : IRoverStepService
    {
        private List<int> surfaceCoor = new List<int>();

        public MoveOn(List<int> surfaceCoor)
        {
            this.surfaceCoor = surfaceCoor;
        }

        public Coordinates DoJob(Coordinates coordinates)
        {
            switch (coordinates.Directions)
            {
                case Directions.North:
                    if (coordinates.PointY >= surfaceCoor[1])
                        return null;
                    else
                        coordinates.PointY += 1;
                    break;

                case Directions.East:
                    if (coordinates.PointX >= surfaceCoor[0])
                        return null;
                    else
                        coordinates.PointX += 1;
                    break;

                case Directions.South:
                    if (coordinates.PointY != 0)
                        coordinates.PointY -= 1;
                    else
                        return null;
                    break;

                case Directions.West:
                    if (coordinates.PointX != 0)
                        coordinates.PointX -= 1;
                    else
                        return null;
                    break;
            }
            return coordinates;
        }
    }
}
