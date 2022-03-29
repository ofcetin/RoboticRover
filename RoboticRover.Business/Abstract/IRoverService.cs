using RoboticRover.Data.Entity;

namespace RoboticRover.Business.Abstract
{
    public interface IRoverService
    {
        Coordinates ExecuteRoverStep(string[] surfacePoints, string[] roverFirstLocation, string steps);
    }
}
