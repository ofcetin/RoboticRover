using RoboticRover.Data.Entity;

namespace RoboticRover.Business.Abstract
{
    public interface IRoverMovementService
    {
        Coordinates DoMovement(IRoverStepService roverStepService, Coordinates coordinates);
    }
}
