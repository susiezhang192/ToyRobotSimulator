using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator
{
    public class Toy
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public DirectionType? Direction { get; set; }

        public bool IsPlaced()
        {
            if (X == null || Y == null || Direction == null)
                return false;
            else
                return true;
        }

        public void Place(int x, int y, DirectionType direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public void Move(int? x, int? y)
        {
            X = x;
            Y = y;
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case DirectionType.EAST:
                    Direction = DirectionType.NORTH;
                    break;
                case DirectionType.WEST:
                    Direction = DirectionType.SOUTH;
                    break;
                case DirectionType.NORTH:
                    Direction = DirectionType.WEST;
                    break;
                case DirectionType.SOUTH:
                    Direction = DirectionType.EAST;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case DirectionType.EAST:
                    Direction = DirectionType.SOUTH;
                    break;
                case DirectionType.WEST:
                    Direction = DirectionType.NORTH;
                    break;
                case DirectionType.NORTH:
                    Direction = DirectionType.EAST;
                    break;
                case DirectionType.SOUTH:
                    Direction = DirectionType.WEST;
                    break;
            }
        }

        public Position GetNextPosition()
        {

            var newPosition = new Position(X, Y);
            switch (Direction)
            {
                case DirectionType.NORTH:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case DirectionType.EAST:
                    newPosition.X = newPosition.X + 1;
                    break;
                case DirectionType.SOUTH:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                case DirectionType.WEST:
                    newPosition.X = newPosition.X - 1;
                    break;
            }
            return newPosition;
        }

        public string Report()
        {
            return X + "," + Y + "," + Direction;
        }

    }

    
}
