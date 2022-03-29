using RoboticRover.Business.Abstract;
using RoboticRover.Data.Entity;

namespace RoboticRover.Business.Concrete
{
    public class RoverMovementManager : IRoverMovementService
    {
        public Coordinates DoMovement(IRoverStepService roverStepService, Coordinates coordinates)
        {
            return roverStepService.DoJob(coordinates);
        }
    }
}
