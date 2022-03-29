using RoboticRover.Data.Entity;

namespace RoboticRover.Business.Abstract
{
    public interface IRoverStepService
    {
        public Coordinates DoJob(Coordinates coordinates);
    }
}
