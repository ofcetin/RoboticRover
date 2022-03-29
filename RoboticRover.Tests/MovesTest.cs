using RoboticRover.Business.Abstract;
using RoboticRover.Business.Concrete;
using RoboticRover.Data.Entity;
using RoboticRover.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoboticRover.Tests
{
    public class MovesTest
    {
        IRoverStepService roverStepServiceTurnLeft;
        IRoverStepService roverStepServiceTurnRight;
        IRoverStepService roverStepServiceMoveOn;
        Coordinates c;

        public MovesTest()
        {
            roverStepServiceTurnLeft = new TurnLeft();
            roverStepServiceTurnRight = new TurnRight();
            roverStepServiceMoveOn = new MoveOn(new List<int> { 5, 5 });

            c = new Coordinates
            {
                PointX = 1,
                PointY = 2,
                Directions = Directions.North
            };
        }

        public static IEnumerable<object[]> datas => new List<object[]> {
    new object[]{ Directions.North },
    new object[]{ Directions.East },
    new object[]{ Directions.South },
    new object[]{ Directions.West }
};

        [Theory]
        [MemberData(nameof(datas))]
        public void TurnLeft_Success_Test(Directions dir)
        {
            #region Arrange
            if (dir == Directions.North)
                c.Directions = Directions.North;
            else if (dir == Directions.East)
                c.Directions = Directions.East;
            else if (dir == Directions.West)
                c.Directions = Directions.West;
            else if (dir == Directions.South)
                c.Directions = Directions.South;
            #endregion

            #region Act
            Coordinates result = roverStepServiceTurnLeft.DoJob(c);
            #endregion

            #region Assert
            Assert.Equal(c, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(datas))]
        public void TurnLeft_Fail_Test(Directions dir)
        {
            #region Arrange
            if (dir == Directions.North)
                c.Directions = Directions.East;
            else if (dir == Directions.East)
                c.Directions = Directions.West;
            else if (dir == Directions.West)
                c.Directions = Directions.South;
            else if (dir == Directions.South)
                c.Directions = Directions.North;
            #endregion

            #region Act
            Coordinates result = roverStepServiceTurnLeft.DoJob(c);
            #endregion

            #region Assert
            Assert.NotEqual(c, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(datas))]
        public void TurnRight_Success_Test(Directions dir)
        {
            #region Arrange
            if (dir == Directions.North)
                c.Directions = Directions.North;
            else if (dir == Directions.East)
                c.Directions = Directions.East;
            else if (dir == Directions.West)
                c.Directions = Directions.West;
            else if (dir == Directions.South)
                c.Directions = Directions.South;
            #endregion

            #region Act
            Coordinates result = roverStepServiceTurnRight.DoJob(c);
            #endregion

            #region Assert
            Assert.Equal(c, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(datas))]
        public void TurnRight_Fail_Test(Directions dir)
        {
            #region Arrange
            if (dir == Directions.North)
                c.Directions = Directions.East;
            else if (dir == Directions.East)
                c.Directions = Directions.West;
            else if (dir == Directions.West)
                c.Directions = Directions.South;
            else if (dir == Directions.South)
                c.Directions = Directions.North;
            #endregion

            #region Act
            Coordinates result = roverStepServiceTurnRight.DoJob(c);
            #endregion

            #region Assert
            Assert.NotEqual(c, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(datas))]
        public void MoveOn_Success_Test(Directions dir)
        {
            #region Arrange
            if (dir == Directions.North)
                c.Directions = Directions.North;
            else if (dir == Directions.East)
                c.Directions = Directions.East;
            else if (dir == Directions.West)
                c.Directions = Directions.West;
            else if (dir == Directions.South)
                c.Directions = Directions.South;
            #endregion

            #region Act
            Coordinates result = roverStepServiceMoveOn.DoJob(c);
            #endregion

            #region Assert
            Assert.Equal(c, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(datas))]
        public void MoveOn_Fail_Test(Directions dir)
        {
            #region Arrange
            var coor = new Coordinates
            {
                PointX = 1,
                PointY = 2,
                Directions = Directions.North
            };

            if (dir == Directions.North)
            {
                coor.PointY = 6;
                coor.Directions = Directions.East;
            }
            else if (dir == Directions.East)
            {
                coor.PointX = 6;
                coor.Directions = Directions.West;
            }
            else if (dir == Directions.West)
            {
                coor.PointY = 0;
                coor.Directions = Directions.South;
            }
            else if (dir == Directions.South)
            {
                coor.PointX = 0;
                coor.Directions = Directions.North;
            }
            #endregion

            #region Act
            Coordinates result = roverStepServiceTurnRight.DoJob(c);
            #endregion

            #region Assert
            Assert.Null(result);
            #endregion
        }
    }
}